function rotateArray(arr, rotations) {
    // Ensure that the number of rotations is within the bounds of the array's length
    let effectiveRotations = rotations % arr.length;

    // Use slice to take the part of the array to rotate and the remaining part
    let rotatedPart = arr.slice(effectiveRotations);
    let rotatedTail = arr.slice(0, effectiveRotations);

    // Concatenate the rotated parts
    return rotatedPart.concat(rotatedTail).join(' ');
}

// Test cases
let arr1 = [51, 47, 32, 61, 21];
let rotations1 = 2;
console.log(rotateArray(arr1, rotations1)); // Output: 32 61 21 51 47

let arr2 = [32, 21, 61, 1];
let rotations2 = 4;
console.log(rotateArray(arr2, rotations2)); // Output: 32 21 61 1

let arr3 = [2, 4, 15, 31];
let rotations3 = 5;
console.log(rotateArray(arr3, rotations3)); // Output: 4 15 31 2