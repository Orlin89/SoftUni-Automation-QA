function printNthElement(arr, step) {
    let result = [];
    // Start the loop at the first element and increment by the step value
    for (let i = 0; i < arr.length; i += step) {
        result.push(arr[i]);
    }
    return result;
}

// Test cases
let arr1 = ['5', '20', '31', '4', '20'];
let step1 = 2;
console.log(printNthElement(arr1, step1)); // Output: ['5', '31', '20']

let arr2 = ['dsa', 'asd', 'test', 'tset'];
let step2 = 2;
console.log(printNthElement(arr2, step2)); // Output: ['dsa', 'test']

let arr3 = ['1', '2', '3', '4', '5'];
let step3 = 6;
console.log(printNthElement(arr3, step3)); // Output: ['1']