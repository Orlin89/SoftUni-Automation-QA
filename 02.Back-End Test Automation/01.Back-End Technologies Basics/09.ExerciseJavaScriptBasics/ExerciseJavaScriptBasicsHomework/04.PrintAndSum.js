function sum(arr)
{
    let start = parseInt(arr[0]);
    let end = parseInt(arr[1]);
    let numbers = '';
    let sum = 0;
    
    for(let i = start; i <= end; i++)
    {
       numbers += i + ' '
       sum += i
    }
    console.log(numbers.trim());
    console.log(`Sum: ${sum}`)
}
