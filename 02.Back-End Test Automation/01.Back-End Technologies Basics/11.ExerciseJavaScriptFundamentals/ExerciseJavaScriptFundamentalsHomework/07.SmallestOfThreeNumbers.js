function smallestOfThreeNUmbers(num1, num2, num3)
{
   if(num1 < num2 && num1 < num3)
    {
        console.log(num1)
    }
    else if(num2 < num1 && num2 < num3)
    {
       console.log(num2)
    }
    else
    {
        console.log(num3)
    } 
}







function smallestOfThree(num1, num2, num3) {
    // Use Math.min to find the smallest of the three numbers
    let smallest = Math.min(num1, num2, num3);
    console.log(smallest);
}