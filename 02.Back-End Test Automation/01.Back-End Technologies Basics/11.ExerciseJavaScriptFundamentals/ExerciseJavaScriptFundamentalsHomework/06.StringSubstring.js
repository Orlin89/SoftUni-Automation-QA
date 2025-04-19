function stringSubstring(word, text)
{
    isFind = false
    let lowerWord = word.toLowerCase()
    let wordsArray = text.split(' ')
    wordsArray.forEach(element => {
     element = element.toLowerCase()
     if(lowerWord === element)
     {
        isFind = true
     }
    })
    if(isFind)
    {
        console.log(word)
    }
    else
    {
      console.log(`${word} not found!`)
    }
}








function stringSubstring2(word, text) {
    // Convert both the word and text to lowercase for case-insensitive comparison
    let lowerWord = word.toLowerCase();
    let lowerText = text.toLowerCase();

    // Split the text into an array of words
    let wordsArray = lowerText.split(' ');

    // Check if the word exists in the array
    if (wordsArray.includes(lowerWord)) {
        console.log(word);  // Print the original word if found
    } else {
        console.log(`${word} not found!`);  // Print "not found" message if not found
    }
}

// Example usage:
stringSubstring('javascript', 'JavaScript is the best programming language');
// Output: "javascript"

stringSubstring('python', 'JavaScript is the best programming language');
// Output: "python not found!"

