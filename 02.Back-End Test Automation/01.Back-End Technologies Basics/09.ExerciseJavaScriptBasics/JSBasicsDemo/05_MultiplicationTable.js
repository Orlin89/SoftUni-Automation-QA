function multiplicationTable(number)
{
    number = Number(number);

    for(let i = 1; i <= 10; i++)
    {
        console.log(`${number} X ${i} = ${number * i}`);
    }
}

multiplicationTable(2)