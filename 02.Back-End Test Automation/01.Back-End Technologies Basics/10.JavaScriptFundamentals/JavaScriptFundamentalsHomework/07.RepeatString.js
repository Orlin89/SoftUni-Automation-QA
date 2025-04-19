function repeatString(string, repeatCount)
{
    let result = string.repeat(repeatCount);
    return result;
}




function repeatString2(string, repeatCount)
{
    let result = '';
    for(let i = 0; i <= repeatCount - 1; i ++)
    {
        result += string       
    }  
    return result; 
}
