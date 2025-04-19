function solve() {
   let input = document.getElementById("text").value.toLowerCase();
   let currentCase = document.getElementById("naming-convention").value;
   let resultSpan = document.getElementById("result");
  
   let stringArray = input.split(" ");
   let stringResult = "";

   if(currentCase == "Camel Case")
   {
     stringResult += stringArray[0]
     for (let i = 1; i < stringArray.length; i++) {
      stringResult += stringArray[i][0].toUpperCase() + stringArray[i].slice(1, stringArray.length); 
      resultSpan.textContent = stringResult;
     }
   }
   else if(currentCase == "Pascal Case")
   {
    for (let i = 0; i < stringArray.length; i++) {
      stringResult += stringArray[i][0].toUpperCase() + stringArray[i].slice(1, stringArray[i].length); 
      resultSpan.textContent = stringResult;
   }
   }
   else{
    stringResult = "Error!"
   }
}