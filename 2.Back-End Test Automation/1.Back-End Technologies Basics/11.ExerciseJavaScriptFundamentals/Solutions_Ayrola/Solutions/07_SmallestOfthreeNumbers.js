function smallestOfThree(num1, num2, num3) {
    // Use Math.min to find the smallest of the three numbers
    let smallest = Math.min(num1, num2, num3);
    console.log(smallest);
}

// Test cases
smallestOfThree(2, 5, 3);  // Output: 2
smallestOfThree(600, 342, 123);  // Output: 123
smallestOfThree(25, 21, 4);  // Output: 4
smallestOfThree(2, 2, 2);  // Output: 2