const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email : "",
    password : "123456",
    confirmPass : "123456",
};

let bookTitle = "";

describe("e2e tests", () => {
    beforeAll(async () => {
        browser = await chromium.launch();
    });

    afterAll(async () => {
        await browser.close();
    });

    beforeEach(async () => {
        context = await browser.newContext();
        page = await context.newPage();
    });

    afterEach(async () => {
        await page.close();
        await context.close();
    });

    
    describe("authentication", () => {
        
        test('Registration with Valid Data', async () => {
           
            await page.goto(host);
            await page.click('//a[@href="/register"]');
            await page.waitForSelector('//form');

            let random = Math.floor(Math.random() * 1000);
            user.email = `email_${random}@abv.bg`;

            await page.locator('//input[@type="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.locator('//input[@name="conf-pass"]').fill(user.confirmPass);
            
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Login with Valid Data', async () => {
            
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');

            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Logout from the Application', async () => {
            
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await page.click('//a[@href="/logout"]');

            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    });

    describe("navbar", () => {
    
        test('Navigation for Logged-In User', async () => {
            
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/collection"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/create"]')).toBeVisible();
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();

            await expect(page.locator('//a[@href="/login"]')).toBeHidden();
            await expect(page.locator('//a[@href="/register"]')).toBeHidden();
        });

        test('Navigation for Guest User', async () => {
            
            await page.goto(host);

            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/collection"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            await expect(page.locator('//a[@href="/register"]')).toBeVisible();

            await expect(page.locator('//a[@href="/create"]')).toBeHidden();
            await expect(page.locator('//a[@href="/logout"]')).toBeHidden();           
        });
    });

    describe("CRUD", () => {
        
        beforeEach(async () => {
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('//input[@name="email"]').fill(user.email);
            await page.locator('//input[@name="password"]').fill(user.password);
            await page.click('//button[@type="submit"]');
        });

        test('Create a Book', async () => {
            
            await page.click('//a[@href="/create"]');
            await page.waitForSelector('//form');

            let random = Math.floor(Math.random() * 1008);
            bookTitle = `bookTitle_${random}`;

            await page.locator('#title').fill(bookTitle);
            await page.locator('#coverImage').fill('Some cover image');
            await page.locator('#year').fill('2011');
            await page.locator('#author').fill('Some author');
            await page.locator('#genre').fill('Some genre');
            await page.locator('//textarea[@name="description"]').fill('Some description');

            await page.click('//button[@type="submit"]');

            await expect(page.locator(`//h2[text()="${bookTitle}"]`)).toHaveCount(1);
            await expect(page.locator(`//h2[text()="${bookTitle}"]`)).toBeVisible();
            expect(page.url()).toBe(host + '/collection');
        });

        test('Edit a Book', async () => {
            
            await page.click('//a[@href="/search"]');
            await page.locator('//input[@name="search"]').fill(bookTitle);
            await page.click('//button[@type="submit"]');
            await page.locator('//li//a').first().click();

            await page.click('//a[@class="edit-btn"]');
            await page.waitForSelector('//form');

            bookTitle = `Edited_${bookTitle}`;

            await page.locator('#title').fill(bookTitle);
            await page.click('//button[@class="save-btn"]');

            await expect(page.locator(`//h2[text()="${bookTitle}"]`)).toHaveCount(1);
            await expect(page.locator(`//h2[text()="${bookTitle}"]`)).toBeVisible();
        });

        test('Delete a Book Testing', async () => {
            
            await page.click('//a[@href="/search"]');
            await page.locator('//input[@name="search"]').fill(bookTitle);
            await page.click('//button[@type="submit"]');
            await page.locator('//li//a').first().click();

            await page.click('//a[@class="delete-btn"]');

            await expect(page.locator(`//h2[text()="${bookTitle}"]`)).toHaveCount(0);
            await expect(page.locator(`//h2[text()="${bookTitle}"]`)).toBeHidden();
            expect(page.url()).toBe(host + '/collection');
        });
    });
});