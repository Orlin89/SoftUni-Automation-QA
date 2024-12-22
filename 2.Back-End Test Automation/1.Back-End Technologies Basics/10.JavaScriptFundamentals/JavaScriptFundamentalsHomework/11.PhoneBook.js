function phoneBook(arr)
{
    let phonebook = {};
    for(index of arr)
    {
        let [name, phone] = index.split(' ');
        phonebook[name] = phone;
    }
       
    for(key in phonebook)
    {
        console.log(`${key} -> ${phonebook[key]}`)
    }
}




function phoneBook1(data) 
{
    let phoneBook = {};

    // Loop through each entry in the data array
    for (let entry of data) 
    {
        let [name, phone] = entry.split(' ');  // Split the entry into name and phone
        phoneBook[name] = phone;               // Store or update the phone number for the name
    }

    // Print each entry in the phone book
    for (let name in phoneBook) 
    {
        console.log(`${name} -> ${phoneBook[name]}`);
    }
}