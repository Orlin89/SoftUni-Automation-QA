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
        
        test("registration with valid data", async () => {
            //Arrange
            await page.goto(host);
            await page.click("//a[@href='/register']");
            await page.waitForSelector("//form");

            //Act
            let random = Math.floor(Math.random() * 1000);
            user.email = `email_${random}@abv.bg`;

            await page.locator("//input[@id='email']").fill(user.email);
            await page.locator("//input[@name='password']").fill(user.password);
            await page.locator("//input[@class='conf-pass']").fill(user.confirmPass);
            await page.click("//button[text()='Register']");

            //Assert
            if(page.locator("//a[@href='/logout']").isVisible())
            {
                await expect(page.locator("//a[@href='/logout']")).toBeVisible();
                expect(page.url()).toBe(host + "/");
            }
            else (
                test.fail()
            )
        })

        test("login with valid data", async () => {
            //Arrange
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");

            //Act
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[text()='Login']");

            //Asserts
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();
            expect(page.url()).toBe(host + "/");
        })

        test("logout from the application", async ()=> {
            //Arrange
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");

            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[text()='Login']");

            //Act
            await page.click("//a[text()='Logout']");

            //asserts
            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            expect(page.url()).toBe(host + "/")
        })
    });

    describe("navbar", () => {
        test("navigation for logged in users", async () => {
            //Arrange
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");

            //Act
            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[text()='Login']");

            //Asserts
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[text()='Catalog']")).toBeVisible();
            await expect(page.locator("//a[text()='Search']")).toBeVisible();
            await expect(page.locator("//a[text()='Create Album']")).toBeVisible();
            await expect(page.locator("//a[text()='Logout']")).toBeVisible();

            await expect(page.locator("//a[text()='Login']")).toBeHidden();
            await expect(page.locator("//a[text()='Register']")).toBeHidden();
        })

        test("navigation for non-logged in users", async () => {
            //Arrange
            await page.goto(host);

            //Asserts
            await expect(page.locator("//a[text()='Home']")).toBeVisible();
            await expect(page.locator("//a[text()='Catalog']")).toBeVisible();
            await expect(page.locator("//a[text()='Search']")).toBeVisible();
            await expect(page.locator("//a[text()='Create Album']")).toBeHidden();
            await expect(page.locator("//a[text()='Logout']")).toBeHidden();

            await expect(page.locator("//a[text()='Login']")).toBeVisible();
            await expect(page.locator("//a[text()='Register']")).toBeVisible();
        })
    });

    describe("CRUD", () => {
        beforeEach(async () => {
            await page.goto(host);
            await page.click("//a[@href='/login']");
            await page.waitForSelector("//form");

            await page.fill("//input[@name='email']", user.email);
            await page.fill("//input[@id='password']", user.password);
            await page.click("//button[text()='Login']");
        })

        test("Create an album", async () => {
            //Arrange
            await page.click("//a[text()='Create Album']");
            await page.waitForSelector("//form");

            //Act
            let random = Math.floor(Math.random() * 10000);
            albumName = `AlbumName_${random}`;

            await page.locator("//input[@name='name']").fill(albumName);
            await page.locator("//input[@name='imgUrl']").fill("/images/pinkFloyd.jpg");
            await page.locator("//input[@name='price']").fill("15");
            await page.locator("//input[@name='releaseDate']").fill("19.01.2000");
            await page.locator("//input[@name='artist']").fill("SomeArtist");
            await page.locator("//input[@name='genre']").fill("Pop");
            await page.locator("//textarea[@name='description']").fill("SomeDescription");

            await page.click("//button[text()='Add New Album']");

            //Assert
            await expect(page.locator("//div[@class='card-box']//p[@class='name']", {hasText: albumName})).toHaveCount(1);
            expect(page.url()).toBe(host + "/catalog");
        })

        test("edit album", async () => {
            //arrange
            await page.click("//a[text()='Search']");
            await page.fill("//input[@id='search-input']", albumName);
            await page.click("//button[text()='Search']");
            albumName = "Edited_" + albumName;

            //Act
            await page.click("//a[@id='details']");
            await page.click("//a[@class='edit']");
            await page.waitForSelector('//form');
            await page.locator("//input[@id='name']").fill(albumName);
            await page.click("//button[@type='submit']");

            //Asserts
            await expect(page.locator("//h1", {hasText: albumName})).toHaveCount(1);
        })

        test("delete album", async () => {
            //arrange
            await page.click("//a[text()='Search']");
            await page.fill("//input[@id='search-input']", albumName);
            await page.click("//button[text()='Search']");

            //Act
            await page.click("//a[@id='details']");
            await page.click("//a[@class='remove']");

            //Asserts
            await expect(page.locator("//div[@class='card-box']//p[@class='name']", {hasText: albumName})).toHaveCount(0);
            expect(page.url()).toBe(host + "/catalog")
        })
    });
});