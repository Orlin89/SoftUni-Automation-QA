function listOfNames(array)
{
    let sortedArray = array.sort((a, b) => a.localeCompare(b))

    for(let i = 0; i < array.length; i ++)
    {
        console.log(`${i+1}.${sortedArray[i]}`)
    }
}
