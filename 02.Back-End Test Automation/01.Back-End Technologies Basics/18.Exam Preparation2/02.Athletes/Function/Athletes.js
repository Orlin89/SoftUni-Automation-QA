function solve(athletes) {
    function getAthletesBySport(sport) {
        let filteredAthletes = athletes.filter(athlet => athlet.sport === sport);
        return filteredAthletes;
    }
  
    function addAthlete(id, name, sport, medals, country) {
        let newAthlet = {id, name, sport, medals, country};
        athletes.push(newAthlet);
        return athletes;
    }
  
    function getAthleteById(id) {
        let athletId = athletes.find(athlet => athlet.id === id);
        if(athletId){
           return athletId;
        }
        else{
            return `Athlete with ID ${id} not found`
        }
         
    }
  
    function removeAthleteById(id) {
        let index = athletes.findIndex(athlet => athlet.id === id);
        if(index !== -1){
            athletes.splice(index, 1);
            return athletes;
        }
        else{
            return `Athlete with ID ${id} not found`
        }
        
    }
  
    function updateAthleteMedals(id, newMedals) {
        updateAthlet = athletes.find(athlet => athlet.id === id);
        if(updateAthlet){
            updateAthlet.medals = newMedals;
            return athletes;
        }
        else{
            return `Athlete with ID ${id} not found`
        }
    }
  
    function updateAthleteCountry(id, newCountry) {
        updateAthlet = athletes.find(athlet => athlet.id === id);
        if(updateAthlet){
            updateAthlet.country = newCountry;
            return athletes;
        }
        else{
            return `Athlete with ID ${id} not found`
        }
    }
  
    return {
        getAthletesBySport,
        addAthlete,
        getAthleteById,
        removeAthleteById,
        updateAthleteMedals,
        updateAthleteCountry
    };
}

// athletes = [{id: 1, name: 'Usain Bolt', sport: 'Sprinting', medals: 8, country: 'Jamaica'}, {id: 2, name: 'Michael Phelps', sport: 'Swimming', medals: 23, country: 'USA'}, {id: 3, name: 'Simone Biles', sport: 'Gymnastics', medals: 7, country: 'USA'}, {id: 4, name: 'Katie Ledecky', sport: 'Swimming', medals: 7, country: 'USA'}]
// let allAthlets = solve(athletes)
// country = "Bulgaria"
// console.log(JSON.stringify(allAthlets.updateAthleteCountry(1,country)))
// console.log(JSON.stringify(allAthlets))
