function sameNumbers(number)
{
    let stringNumber = "" + number;
    let firstDigit = stringNumber[0];
    let allSame = true;
    let sum = 0;

    for(let digit of stringNumber)
    {
        if(digit !== firstDigit)
        {
            allSame = false;
        }
        sum += parseInt(digit);
    }

    console.log(allSame);
    console.log(sum)
}

sameNumbers(1234)