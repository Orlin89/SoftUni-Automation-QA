function subtract() {
    
    let num1 = Number(document.getElementById("firstNumber").value);
    let num2 = Number(document.getElementById("secondNumber").value);
    let resultSubstract = num1 - num2;
    let result = document.getElementById("result");
    result.textContent = resultSubstract;  
} 