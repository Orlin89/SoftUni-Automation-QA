function sumDigits(number) 
{
    let sum = 0;

    while (number > 0) {
        sum += number % 10; // Get the last digit
        number = Math.floor(number / 10); // Remove the last digit
    }

    console.log(sum);
}


function sumDigits2(number) 
{
    let sum = 0;
    let digits = number.toString().split('');

    for (let digit of digits) 
    {
        sum += parseInt(digit);
    }

    console.log(sum);
}