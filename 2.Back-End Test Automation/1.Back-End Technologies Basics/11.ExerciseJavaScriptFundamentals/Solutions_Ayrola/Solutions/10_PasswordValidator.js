function validatePassword(password) {
    let isValid = true;
    
    // Rule 1: Check the length of the password
    if (password.length < 6 || password.length > 10) {
        console.log("Password must be between 6 and 10 characters");
        isValid = false;
    }

    // Rule 2: Check if the password consists only of letters and digits
    if (!/^[A-Za-z0-9]+$/.test(password)) {
        console.log("Password must consist only of letters and digits");
        isValid = false;
    }

    // Rule 3: Check if the password has at least 2 digits
    let digitCount = (password.match(/\d/g) || []).length;
    if (digitCount < 2) {
        console.log("Password must have at least 2 digits");
        isValid = false;
    }

    // If all rules are fulfilled, the password is valid
    if (isValid) {
        console.log("Password is valid");
    }
}

// Test cases
validatePassword('logIn');
// Output:
// Password must be between 6 and 10 characters
// Password must have at least 2 digits

validatePassword('MyPass123');
// Output:
// Password is valid

validatePassword('Pa$$s$');
// Output:
// Password must consist only of letters and digits
// Password must have at least 2 digits