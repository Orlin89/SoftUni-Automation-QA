let num1Field = document.getElementById('number1');
let num2Field = document.getElementById('number2');
let resultField = document.getElementById('result');

document.getElementById('calcButton').onclick = sumNumbers;
document.getElementById('resetButton').onclick = resetNumbers;

function sumNumbers() {
  let num1 = parseFloat(num1Field.value);
  let num2 = parseFloat(num2Field.value);
  let sum = num1 + num2;
  if (isNaN(sum))
    sum = "<i>invalid input</i>";
  else
    sum = '<pre>' + sum + '</pre>';
  resultField.innerHTML = "<h4>Sum:</h4> " + sum;
}

function resetNumbers() {
  resultField.innerHTML = '';
}

