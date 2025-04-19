function sumNumbers(number)
{
    let digits = number.toString().split('');
    let sumOfDigits = 0;

    for(let digit of digits)
    {
        sumOfDigits += Number(digit);
    }

    console.log(sumOfDigits);
}

sumNumber2(543)

function sumNumber2(number)
{
    let sum = 0;

    while(number > 0)
    {
        let lastDigit = number % 10;
        sum += lastDigit;

        number = Math.floor(number / 10);
    }

    console.log(sum)
}