

// Main function to calculate based on the task description
function calculate(num1, num2, num3) {

    function sum(num1, num2) {
        return num1 + num2;
    }
    
    function subtract(sumResult, num3) {
        return sumResult - num3;
    }
    
    let resultSum = sum(num1, num2);
    let result = subtract(resultSum, num3);
    console.log(result);
}

// Test cases
calculate(23, 6, 10);  // Output: 19
calculate(1, -12, 1);  // Output: -12
calculate(17, 30, 42);  // Output: 5