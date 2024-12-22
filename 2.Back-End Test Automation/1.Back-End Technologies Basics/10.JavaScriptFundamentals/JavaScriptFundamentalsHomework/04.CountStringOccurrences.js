function countString(text, word)
{
    let copyText = text.split(' ');
    let counter = 0;
    for(let i = 0; i < copyText.length; i ++)
    {
        if(copyText[i] === (word))
        {
            counter ++;
        }
    }
    console.log(counter)
}






function countString2(text, word)
{
    let copyText = text.split(' ');
    let counter = 0;
    for(let curentWord of copyText)
    {
        if(curentWord === (word))
        {
            counter ++;
        }
    }
    console.log(counter)
}