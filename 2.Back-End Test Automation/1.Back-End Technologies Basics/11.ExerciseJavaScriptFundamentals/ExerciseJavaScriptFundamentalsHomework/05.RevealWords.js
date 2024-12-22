function revealWords(wordsToReplace, text)
{    
    let words = wordsToReplace.split(', ')  
    words.forEach(word => {
    let replaceWord = '*'.repeat(word.length)
    text = text.replace(replaceWord, word)
   }) 
   return text
}






function revealWords2(wordsString, text) {   
    let words = wordsString.split(', ');  // Split the first parameter into individual words based on ', '
    
    // Iterate through the words that contain asterisks
    words.forEach(word => {
        // Create a template to match (e.g., ***** for 'great')
        let template = '*'.repeat(word.length);
        
        // Replace the template with the word in the sentence
        text = text.replace(template, word);
    });
    
    return text;  // Return the modified sentence
}

// Example usage:
console.log(revealWords('great', 'softuni is ***** place for learning new programming languages'));
// Output: "softuni is great place for learning new programming languages"

console.log(revealWords('great, learning', 'softuni is ***** place for ******** new programming languages'));
// Output: "softuni is great place for learning new programming languages"












