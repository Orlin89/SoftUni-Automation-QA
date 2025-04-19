function sortNumbers(arr) {
    // Sort the array in ascending order
    let sortedAscending = [...arr].sort((a, b) => a - b);
    
    // Sort the array in descending order
    let sortedDescending = [...arr].sort((a, b) => b - a);

    let result = [];
    let length = arr.length;

    // Use two pointers to take elements from both arrays
    for (let i = 0; i < Math.ceil(length / 2); i++) {
        if (sortedAscending[i] !== undefined) {
            result.push(sortedAscending[i]);  // Push the smallest remaining number
        }
        if (sortedDescending[i] !== undefined && result.length < length) {
            result.push(sortedDescending[i]); // Push the largest remaining number
        }
    }

    return result;
}

// Test case
let arr = [11,91,18];
console.log(sortNumbers(arr)); 