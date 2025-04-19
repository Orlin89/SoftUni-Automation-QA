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

let petName = "";

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
           user.email = `email_${random}@abv.bg`

           await page.locator('#email').fill(user.email);
           await page.locator('#password').fill(user.password);
           await page.locator('#repeatPassword').fill(user.confirmPass);
           await page.click('//button[@type="submit"]');

           await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
           expect(page.url()).toBe(host + '/');
        });

        test('Login with Valid Data', async () => {
           
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Logout from the Application', async () => {
            
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
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
            
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('//button[@type="submit"]');

            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
            await expect(page.locator('//a[@href="/create"]')).toBeVisible();
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible(); 

            await expect(page.locator('//a[@href="/login"]')).toBeHidden();
            await expect(page.locator('//a[@href="/register"]')).toBeHidden();
        });

        test('Navigation for Guest User', async () => {
            
            await page.goto(host);
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
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
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('//button[@type="submit"]');
        });

        test('Create a Postcard Testing', async () => {
            
            await page.click('//a[@href="/create"]');
            await page.waitForSelector('//form');

            let random = Math.floor(Math.random() * 1008);
            petName = `petName_${random}`;

            await page.locator('#name').fill(petName);
            await page.locator('#breed').fill('shiba inu');
            await page.locator('#age').fill('2');
            await page.locator('#weight').fill('5');
            await page.locator('#image').fill('./image.dog.jpeg');

            await page.click('//button[@type="submit"]');

            await expect(page.locator('//div[@class="animals-board"]//h2[@class="name"]', {hasText: petName})).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test('Edit a Postcard Testing', async () => {
            
            await page.click('//a[@href="/catalog"]');
            
            await page.click(`//div[@class="animals-board"]//h2[text()="${petName}"]//following-sibling::div//a`);

            await page.click('.edit');
            await page.waitForSelector('form');
            petName = `Edited_${petName}`;
            await page.locator('#name').fill(petName);
            await page.click('.btn');

            await expect(page.locator('h1', {hasText: `Name: ${petName}`})).toHaveCount(1);
        });

        test('Delete a Postcard Testing', async () => {
            
            await page.click('//a[@href="/catalog"]');
            await page.click(`//div[@class="animals-board"]//h2[text()="${petName}"]//following-sibling::div//a`);
            await page.click('//a[@class="remove"]');

            await expect(page.locator('//div[@class="animals-board"]//h2[@class="name"]', {hasText: petName})).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
})