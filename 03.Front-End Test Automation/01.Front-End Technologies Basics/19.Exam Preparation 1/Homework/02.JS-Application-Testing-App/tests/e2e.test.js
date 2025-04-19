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

let albumName = "";

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
           
           // Arrange
           let random = Math.floor(Math.random() * 1000);
           user.email = `mail${random}abv.bg`
           await page.goto(host);

           // Act
           await page.click('//a[@href="/register"]');
           await page.waitForSelector('//a[@href="/register"]');
           await page.locator('#email').fill(user.email);
           await page.locator('#password').fill(user.password);
           await page.locator('#conf-pass').fill(user.confirmPass);
           await page.click('//button[@type="submit"]');

           // Assert
           await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
           expect(page.url()).toBe(host + '/');         
        });

        test('Login with Valid Data', async () => {
            
            // Arrange
            await page.goto(host);

            // Act
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Logout from the Application', async () => {
           
            // Arrange
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('//button[@type="submit"]');

            // Act
            await page.click('//a[@href="/logout"]');

            // Assert
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    });

    describe("navbar", () => {
        
        test('Navigation for Logged-In User', async () => {
            
            // Act
            await page.goto(host);
            await page.click('//a[@href="/login"]');
            await page.waitForSelector('//form');
            await page.locator('#email').fill(user.email);
            await page.locator('#password').fill(user.password);
            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/create"]')).toBeVisible();
            await expect(page.locator('//a[@href="/logout"]')).toBeVisible();

            await expect(page.locator('//a[@href="/login"]')).toBeHidden();
            await expect(page.locator('//a[@href="/register"]')).toBeHidden();
        });

        test('Navigation for Guest User', async () => {
            
            // Act
            await page.goto(host);

            // Assert
            await expect(page.locator('//a[@href="/"]')).toBeVisible();
            await expect(page.locator('//a[@href="/catalog"]')).toBeVisible();
            await expect(page.locator('//a[@href="/search"]')).toBeVisible();
            await expect(page.locator('//a[@href="/login"]')).toBeVisible();
            await expect(page.locator('//a[@href="/register"]')).toBeVisible();

            await expect(page.locator('//a[@href="/create"]')).toBeHidden();
            await expect(page.locator('//a[@href="logout"]')).toBeHidden();
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

        test('Create an Album', async () => {
           
            // Arrange
            let random = Math.floor(Math.random() * 1000);
            albumName = `albumName${random}`;

            // Act
            await page.click('//a[@href="/create"]');
            await page.waitForSelector('form');

            await page.locator('#name').fill(albumName);
            await page.locator('#imgUrl').fill('/images/pinkFloyd.jpg');
            await page.locator('#price').fill('15');
            await page.locator('#releaseDate').fill('02.10.2004');
            await page.locator('#artist').fill('some artist');
            await page.locator('#genre').fill('rock');
            await page.locator('//textarea[@name="description"]').fill('some description');

            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//div[@class="card-box"]//p[@class="name"]', {hasText: albumName})).toHaveCount(1);
            expect(page.url()).toBe(host + '/catalog');
        });

        test('Edit an Album', async () => {
            
            // Arrange
            await page.click('//a[@href="/search"]');
            await page.locator('#search-input').fill(albumName);
            await page.click('//button[@class="button-list"]');
            await page.locator('#details').first().click();
            //await page.locator('//div[@class="card-box"]').filter({ hasText: albumName }).locator('a#details').click();

            // Act
            await page.click('.edit');
            await page.waitForSelector('//form');

            albumName = `edited_${albumName}`;
            await page.locator('#name').fill(albumName);
            await page.click('//button[@type="submit"]');

            // Assert
            await expect(page.locator('//h1', {hasText: `Name: ${albumName}`})).toHaveCount(1);
        });

        test('Delete an Album', async () => {
            
            // Arrange
            await page.click('//a[@href="/search"]');
            await page.locator('#search-input').fill(albumName);
            await page.click('//button[@class="button-list"]');
            await page.locator('#details').first().click();

            // Act
            await page.click('//a[@class="remove"]');

            // Assert
            await expect(page.locator('//div[@class="card-box"]//p[@class="name"]', {hasText: albumName})).toHaveCount(0);
            expect(page.url()).toBe(host + '/catalog');
        });
    });
});