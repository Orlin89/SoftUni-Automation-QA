async function fetchData() {
    const response = await fetch("https://swapi.dev/api/people/1");
    const character = await response.json();
    console.log(character)
}

// fetchData();