function sameNumbers(input) 
{
    let sum = 0;
    let lastDigit = input % 10; // Get the last digit
    let allSame = true; // Assume all digits are the same initially
    let temp = input; // Temporary variable to modify the input

    while (temp > 0) 
    {
        let currentDigit = temp % 10; // Extract the last digit
        sum += currentDigit; // Add the current digit to the sum
        
        // Check if the current digit is different from the last digit
        if (currentDigit !== lastDigit) 
        {
            allSame = false; // Set allSame to false if a different digit is found
        }
        
        temp = Math.floor(temp / 10); // Remove the last digit from temp
    }

    // Print whether all digits are the same
    console.log(allSame);
    
    // Print the sum of all digits
    console.log(sum);
}







function sameNumbers2(number)
{
    sum = 0;
    firstDigit = number % 10;
    otherDigits = 0;
    isSame = true;
  while(number > 0)
  {
    otherDigits = number % 10
    sum += otherDigits
    number = Math.floor(number / 10)
    if(firstDigit !== otherDigits)
    {
       isSame = false
    }
  }
  console.log(isSame)
  console.log(sum) 
}

