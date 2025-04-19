function printAndSum(arr)
{
    let resultString = '';
    let sumOfNumber = 0;
    let start = parseInt(arr[0]);
    let end = parseInt(arr[1]);

    for(let i = start; i <= end; i++)
    {
        resultString += i + ' ';
        sumOfNumber += i;
    }

    console.log(resultString.trimEnd());
    console.log(`Sum: ${sumOfNumber}`);
}

printAndSum([50, 60])