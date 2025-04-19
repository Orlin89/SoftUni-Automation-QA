async function fetchDataWithErrorHandling() {
    
    try {
        const response = await fetch("https://swapi.dev/api/people/17868678768768768");
        const character = await response.json();
        
        if(!response.ok)
        {
            throw new Error("Something went wrong!");
        }
        
        console.log(character)

    } catch (error) {
        console.error("Errrrrrrrrrr", error.message);
    }
}

// fetchDataWithErrorHandling();