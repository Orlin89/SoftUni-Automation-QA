function sortAndPrintNames(names) {
    // Sort the names alphabetically, ignoring case sensitivity
    names.sort((a, b) => a.toLowerCase().localeCompare(b.toLowerCase()));
    
    // Print each name with its corresponding number
    names.forEach((name, index) => {
        console.log(`${index + 1}.${name}`);
    });
}

// Test case
let namesArray = ["Pgf","Zh","fA","K","Z","Aa"];
sortAndPrintNames(namesArray);