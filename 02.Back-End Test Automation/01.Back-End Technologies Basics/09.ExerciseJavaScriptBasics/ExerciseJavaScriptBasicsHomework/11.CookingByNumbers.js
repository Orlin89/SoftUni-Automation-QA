function cookingByNumbers(input) {
    // Parse the first element as a number
    let number = parseFloat(input[0]);

    // Define operations as functions
    const operations = {
        chop: () => number /= 2,
        dice: () => number = Math.sqrt(number),
        spice: () => number += 1,
        bake: () => number *= 3,
        fillet: () => number -= number * 0.2 // Subtracting 20% from the number
    };

    // Perform each operation in the input array, starting from the second element
    for (let i = 1; i < input.length; i++) {
        const operation = input[i];
        if (operations[operation]) {
            number = operations[operation](); // Execute the operation
            console.log(number); // Print the result of each operation
        }
    }
}







function cookingNumbers(arr)
{
    let currNum = Number(arr[0])
    
    for(let i = 1; i < arr.length; i++)
    {         
        if(arr[i] === 'chop')
        {
            currNum /= 2
        }
        else if(arr[i] === 'dice')
        {
            currNum = Math.sqrt(currNum)
        }
        else if(arr[i] === 'spice')
        {
            currNum ++
        }
        else if(arr[i] === 'bake')
        {
            currNum *= 3
        }
        else if(arr[i] === 'fillet')
        {
            currNum *= 0.8
        }
        console.log(currNum)
    }
}