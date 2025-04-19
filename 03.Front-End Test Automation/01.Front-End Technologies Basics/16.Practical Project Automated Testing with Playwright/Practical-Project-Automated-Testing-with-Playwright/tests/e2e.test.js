const { test, describe, beforeEach, afterEach, beforeAll, afterAll, expect } = require('@playwright/test');
const { chromium } = require('playwright');

const host = 'http://localhost:3000';

let browser;
let context;
let page;

let user = {
    email: "",
    password: "123456",
    confirmPass: "123456"
}

let game = {
    title: "",
    category: "",
    id: "",
    maxLevel: "99",
    imageURL: "https://blz-contentstack-images.akamaized.net/v3/assets/bltf408a0557f4e4998/bltf838e640c30eb9c6/66959c69ce31f781bc7d0fe7/WOW_11p0_TWW_EarlyAccessBanners_ProductAssetGallery-Logos-v1_1920x1080_enUS_JL01.png",
    summary: "This is amazing game"
}

describe('e2e tests', () => {

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

    let random = Math.floor(Math.random() * 1000);
    let email = `some${random}@abv.bg`;

    describe('authentication', () => {

        test('register with valid data redirects to correct page', async () => {

            await page.goto(host);
            await page.click('a[href="/register"]');
            await page.waitForSelector('form');

            let random = Math.floor(Math.random() * 1000);
            user.email = `some${random}@abv.bg`;

            await page.locator('#email').fill(user.email);
            await page.locator('#register-password').fill(user.password);
            await page.locator('#confirm-password').fill(user.confirmPass);
            await page.click('input[type="submit"]');

            await expect(page.locator('a[href="/logout"]')).toBeVisible();
            await expect(page.url()).toBe(host + '/');
        });

        test('register does not work with empty fields', async () => {

            await page.goto(host);
            await page.click('a[href="/register"]');
            await page.waitForSelector('form');

            await page.click('input[type="submit"]');

            await expect(page.url()).toBe(host + '/register');
        });

        test('login with valid data redirect to correct page', async () => {

            await page.goto(host);
            await page.click('a[href="/login"]');
            await page.waitForSelector('form');

            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);
            await page.click('input[type="submit"]');

            await expect(page.locator('nav >> text=Logout')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('login does not work with empty fields', async () => {
            await page.goto(host);
            await page.click('a[href="/login"]');
            await page.waitForSelector('form');
            await page.click('input[type="submit"]');
            expect(page.url()).toBe(host + '/login');
        });

        test('Logout from the Application', async () => {
            await page.goto(host);
            await page.click('a[href="/login"]');
            await page.waitForSelector('form');
            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);
            await page.click('input[type="submit"]');
            
            await page.locator('a[href="/logout"]').click();
            await expect(page.locator('a[href="/login"]')).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });
    });

    describe('navbar', () => {
        test('Navigation Bar for Logged-In User', async () => {
            await page.goto(host);
            await page.click('a[href="/login"]');
            await page.waitForSelector('form');

            await page.locator('#email').fill(user.email);
            await page.locator('#login-password').fill(user.password);
            await page.click('input[type="submit"]');

            await page.waitForURL(host + '/');
           
            await expect(page.locator('nav >> text=All games')).toBeVisible();
            await expect(page.locator('a[href="/catalog"]')).toBeVisible();
            await expect(page.locator('a[href="/create"]')).toBeVisible();
            await expect(page.locator('a[href="/logout"]')).toBeVisible();
            await expect(page.locator('a[href="/login"]')).toBeHidden();
            await expect(page.locator('a[href="/register"]')).toBeHidden();
        });

        test('Navigation Bar for Guest User', async () => {
           await page.goto(host);
           //await expect(page.locator('a[href="/catalog"]'), 'Catalog link should not be visible').toBeHidden();
           await expect(page.locator('a[href="/create"]')).toBeHidden();
           await expect(page.locator('a[href="/logout"]')).toBeHidden();

           await expect(page.locator('a[href="/login"]')).toBeVisible();
           await expect(page.locator('a[href="/register"]')).toBeVisible();
        });
    });

    describe('CRUD', () => {
        beforeEach(async () => {
           await page.goto(host);
           await page.click('a[href="/login"]');
           await page.waitForSelector('form');
           await page.locator('#email').fill(user.email);
           await page.locator('#login-password').fill(user.password);
           await page.click('input[type="submit"]');
        });
        
        test('create does NOT work with empty fields', async () => {
            await page.click('a[href="/create"]');
            await page.waitForSelector('#create');
            await page.click('input[type="submit"]');

            expect(page.url()).toBe(host + '/create');
        });

        test('create with valid data successfully creates the game', async () => {
            await page.click('a[href="/create"]');
            await page.waitForSelector('#create');

            let random = Math.floor(Math.random() * 1000);
            game.title = `Title ${random}`;
            game.category = `Category ${random}`;

            await page.locator('#title').fill(game.title);
            await page.locator('#category').fill(game.category);
            await page.locator('#maxLevel').fill(game.maxLevel);
            await page.locator('#imageUrl').fill(game.imageURL);
            await page.locator('#summary').fill(game.summary);
            
            await page.click('input[type="submit"]');

            await expect(page.locator('.game h3', { hasText: game.title })).toHaveCount(1);
            //await expect(page.locator(`//div[@class='game']//h3[text()="${game.title}"]`)).toBeVisible();
            expect(page.url()).toBe(host + '/');
        });

        test('Edit/Delete Buttons for Owner', async () => {
            await page.goto(host + '/catalog');
            await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);
            game.id = page.url().split('/').pop();

            await expect (page.locator('//div[@class="info-section"]//div[@class="buttons"]//a[text()="Edit"]')).toBeVisible();
            await expect(page.locator('//a[text()="Delete"]')).toBeVisible();
        });

        test('Edit/Delete Button for Non-Owner', async () => {
            await page.goto(host + '/catalog');
            await page.click('.allGames .allGames-info:has-text("MineCraft") .details-button');

            await expect(page.locator('//a[text()="Edit"]')).toBeHidden();
            await expect(page.locator('//a[text()="Delete"]')).toBeHidden();
        });

        test('Edit Button for Game Owner', async () => {
           await page.goto(host + '/catalog');
           await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);
           await page.click('//a[text()="Edit"]');
           await page.waitForSelector('form');

           game.title = `${game.title}_edited`;

           await page.locator('#title').fill(game.title);
           await page.click('//input[@type="submit"]');

           await expect(page.locator('.game-header h1', {hasText: game.title})).toHaveCount(1);                 // option 1
           await expect(page.locator(`.info-section .game-header:has-text("${game.title}")`)).toHaveCount(1);   // option 2
           expect(page.url()).toBe(host + `/details/${game.id}`);
        });

        test('Delete Button for Game Owner', async () => {
           await page.goto(host + '/catalog');
           await page.click(`.allGames .allGames-info:has-text("${game.title}") .details-button`);
           await page.click('//a[text()="Delete"]');

           await expect(page.locator(`.info-section .game-header:has-text("${game.title}")`)).toHaveCount(0);
           expect(page.url()).toBe(host + '/');
        });
    });

    describe('Home Page', () => {
       test('show home page', async () => {
          await page.goto(host);

          expect(page.locator('.welcome-message h2')).toHaveText('ALL new games are');
          expect(page.locator('.welcome-message h3')).toHaveText('Only in GamesPlay');
          expect(page.locator('#home-page h1')).toHaveText('Latest Games');

          const gameDivs = await page.locator('#home-page .game').all();

          expect(gameDivs.length).toBeGreaterThanOrEqual(3);
       });
    });
});