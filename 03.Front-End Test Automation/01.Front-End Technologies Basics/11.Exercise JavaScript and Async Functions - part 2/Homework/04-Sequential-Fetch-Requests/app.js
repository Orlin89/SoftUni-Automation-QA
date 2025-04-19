async function fetchSequential() {
      
      const response1 = await fetch("https://swapi.dev/api/people/1");
      const response2 = await fetch("https://swapi.dev/api/people/2");

      const data1 = await response1.json();
      const data2 = await response2.json();

      console.log(data1);
      console.log(data2);
}

// fetchSequential();