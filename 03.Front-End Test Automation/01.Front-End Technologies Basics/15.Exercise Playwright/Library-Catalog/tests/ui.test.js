const {test, expect} = require ('@playwright/test');

let random = Math.floor(Math.random() * 1000);
let email = `some_${random}@abv.bg`;
let password = '123456';

test("Verify 'All Books' link is visible", async({page}) => {
     
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const allBooksLink = await page.$('//a[@href="/catalog"]');
    const isVisibleLink = await allBooksLink.isVisible();
    expect(isVisibleLink).toBe(true);
});

test('Verify That the "Login" Button Is Visible', async({page}) => {
    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const loginButton = await page.$('//a[@href="/login"]');
    const isLoginButtonVisible = await loginButton.isVisible();
    expect(isLoginButtonVisible).toBe(true);
});

test('Verify That the "Register" Button Is Visible', async({page}) => {

    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    const registerButton = await page.locator('//a[@href="/register"]');
    const isRegisterButtonVisible = await registerButton.isVisible();
    expect(isRegisterButtonVisible).toBe(true);
});

test("Verify 'All Books' link is visible after login", async({page}) => {

    await page.goto('http://localhost:3000');
    await page.waitForSelector('nav.navbar');
    await page.click('//a[@href="/login"]');
    await page.waitForSelector('form');
    await page.fill('//input[@name="email"]', 'peter@abv.bg');
    await page.fill('//input[@name="password"]', '123456');
    await page.click('//input[@type="submit"]');
    const allBooksLink = await page.$('//a[@href="/catalog"]');
    const isVisibleLink = await allBooksLink.isVisible();
    expect(isVisibleLink).toBe(true);
});

test("Verify 'My Books' link is visible after login", async({page}) => {
    await page.goto('http://localhost:3000/login');
    await page.fill('//input[@name="email"]', 'peter@abv.bg');
    await page.fill('//input[@name="password"]', '123456');
    await page.click('//input[@type="submit"]');
    await page.waitForSelector('nav.navbar');
    const myBooksLInk = await page.locator('//a[@href="/profile"]');
    const isMyBooksLinkVisible = await myBooksLInk.isVisible();
    expect(isMyBooksLinkVisible).toBe(true); 
});

test("Verify That the User's Email Address Is Visible", async({page}) => {

    await page.goto('http://localhost:3000/login');
    await page.fill('//input[@name="email"]', 'peter@abv.bg');
    await page.fill('//input[@name="password"]', '123456');
    await page.click('//input[@type="submit"]');
    await page.waitForSelector('nav.navbar');
    const emailAddressLink = await page.locator("//span[text()='Welcome, peter@abv.bg']");
    const isEmailVisible = await emailAddressLink.isVisible();
    expect(isEmailVisible).toBe(true);
});

test('Submit the Form with Valid Credentials', async({page}) => {

    await page.goto('http://localhost:3000/login');
    await page.fill('//input[@name="email"]', 'peter@abv.bg');
    await page.fill('//input[@name="password"]', '123456');
    await page.click('//input[@type="submit"]');
    await page.locator('//a[@href="/catalog"]').waitFor();    //await page.$('//a[@href="/catalog"]');  
    expect(page.url()).toBe('http://localhost:3000/catalog')
});

test('Submit the Form with Empty Input Fields', async({page}) => {
    await page.goto('http://localhost:3000/login');
  
    page.on('dialog', async dialog => {
        expect(dialog.message()).toContain('All fields are required!');
        await dialog.accept();
    });

    await page.click('//input[@type="submit"]');

    await page.$('//a[@href="/login"]');
    expect(page.url()).toBe('http://localhost:3000/login');   // await expect(page).toHaveURL('http://localhost:3000/login');  
});

test('Submit the Register Form with Valid Values', async({page}) => {
    
    await page.goto('http://localhost:3000/register');
    await page.fill('//input[@name="email"]', email);
    await page.fill('//input[@name="password"]', password);
    await page.fill('//input[@name="confirm-pass"]', password);
    await page.click('//input[@type="submit"]');
    const userEmailLink = await page.locator(`//span[text()="Welcome, ${email}"]`);
    const isEmailLinkVisible = await userEmailLink.isVisible();
    await expect(userEmailLink).toBeVisible();
    await expect(page).toHaveURL('http://localhost:3000/catalog');   // await expect(page.url()).toBe('http://localhost:3000/catalog');      
});

test('Submit the Register Form with Empty Values', async({page}) => {
    
    await page.goto('http://localhost:3000/register');
    await page.waitForSelector('form');

    page.on('dialog', async dialog => {
        expect(dialog.message()).toContain('All fields are required!');
        dialog.accept();
    });
    
    //await page.waitForSelector('//input[@type="submit"]')
    await page.click('//input[@type="submit"]');
    await page.$('//a[@href="/register"]');
    await expect(page.url()).toBe('http://localhost:3000/register');
});

test('Submit the Register Form with Empty Email', async({page}) => {

    await page.goto('http://localhost:3000/register');
    await page.waitForSelector('form');
    await page.fill('//input[@name="password"]', password);
    await page.fill('//input[@name="confirm-pass"]', password);

    page.on('dialog', async dialog => {
       expect(dialog.message()).toBe('All fields are required!');
       dialog.accept();
    });

    await page.click('//input[@type="submit"]');
    await page.locator('//a[@href="register"]');

    await expect(page.url()).toBe('http://localhost:3000/register');
});

test('Submit the Register Form with Empty Password', async({page}) => {

    await page.goto('http://localhost:3000/register');
    await page.waitForSelector('form');
    await page.fill('//input[@name="email"]', email);
    await page.fill('//input[@name="confirm-pass"]', password);

    page.on('dialog', async dialog => {
        expect(dialog.type()).toContain('alert');
        expect(dialog.message()).toBe('All fields are required!');
        dialog.accept();
    });

    await page.click('//input[@type="submit"]');
    await page.waitForSelector('form');
    await expect(page.url()).toBe('http://localhost:3000/register');
});

test('Add book with correct data', async({page}) => {

    await page.goto('http://localhost:3000/login');
    await page.fill('input[name="email"]', 'peter@abv.bg');
    await page.fill('input[name="password"]', '123456');

    await Promise.all([
        page.click('input[type="submit"]'),
        page.waitForURL('http://localhost:3000/catalog')
    ]);

    await page.click('a[href="/create"]');
    await page.waitForSelector('#create-form');
    
    await page.fill('#title', 'Dark Angel');
    await page.fill('#description', 'Some description for Dark Angel');
    await page.fill('#image', '/ some path img');
    await page.selectOption('#type', 'Mistery');   
    await page.click('input.button.submit');       //await page.click('input[type="submit"]');  
    
    await page.waitForURL('http://localhost:3000/catalog');
    await expect(page.url()).toBe('http://localhost:3000/catalog');
});