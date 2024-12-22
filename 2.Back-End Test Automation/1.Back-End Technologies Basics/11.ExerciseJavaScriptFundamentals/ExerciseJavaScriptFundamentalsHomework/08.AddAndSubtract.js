function addAndSubstract(num1, num2, num3)
{ 
    function sum(num1, num2)
    {
      return num1 + num2
    }
    function substract(sumResult, num3)
    {
      return sumResult - num3
    }
    let sumResult = sum(num1, num2)
    let result = substract(sumResult, num3)
    console.log(result)
}

