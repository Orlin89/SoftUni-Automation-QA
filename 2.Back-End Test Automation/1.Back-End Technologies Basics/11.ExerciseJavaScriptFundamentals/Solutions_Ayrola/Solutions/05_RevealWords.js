function revealWords(words, sentence) {
    // Split the words by comma to get an array of words
    let wordList = words.split(', ');

    // Iterate through each word and replace the corresponding template in the sentence
    wordList.forEach(word => {
        // Create a pattern for the template that has the same length as the word
        let template = '*'.repeat(word.length);
        sentence = sentence.replace(template, word);
    });

    return sentence;
}

// Test cases
let words1 = 'great';
let sentence1 = 'softuni is ***** place for learning new programming languages';
console.log(revealWords(words1, sentence1));
// Output: softuni is great place for learning new programming languages

let words2 = 'great, learning';
let sentence2 = 'softuni is ***** place for ******* new programming languages';
console.log(revealWords(words2, sentence2));
// Output: softuni is great place for learning new programming languages