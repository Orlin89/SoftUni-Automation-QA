async function fetchParallel() {
  
   const response = await Promise.all([
     fetch("https://swapi.dev/api/people/1"),
     fetch("https://swapi.dev/api/people/2")
   ])

   for(const responseObj of response)
   {
     const data = await responseObj.json();
     console.log(data);
   }  
}

// fetchParallel();