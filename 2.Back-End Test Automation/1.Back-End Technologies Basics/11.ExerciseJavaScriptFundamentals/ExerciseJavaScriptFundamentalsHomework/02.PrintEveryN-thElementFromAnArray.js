function printEveryNthElement(array, number)
{
    let copyArray = [];
    for(let i = 0; i < array.length; i += number)
    {
        copyArray.push(array[i])
    }
    return copyArray
}
