function manageMovies(commands) {
    let movies = {}; // Use an object to store movies, where the movie name is the key

    commands.forEach(command => {
        if (command.startsWith('addMovie ')) {
            // Extract movie name after 'addMovie '
            let movieName = command.substring(9);
            movies[movieName] = { name: movieName };  // Initialize the movie object
        } else if (command.includes('directedBy')) {
            // Extract movie name and director
            let [movieName, director] = command.split(' directedBy ');
            if (movies[movieName]) {
                movies[movieName].director = director; // Add the director to the movie object
            }
        } else if (command.includes('onDate')) {
            // Extract movie name and date
            let [movieName, date] = command.split(' onDate ');
            if (movies[movieName]) {
                movies[movieName].date = date; // Add the date to the movie object
            }
        }
    });

    // Loop through the object and print only movies that have name, director, and date
    for (let movieName in movies) {
        let movie = movies[movieName];
        if (movie.name && movie.director && movie.date) {
            console.log(JSON.stringify(movie));
        }
    }
}

// Test case
let commands = [
    'addMovie Fast and Furious',
    'addMovie Godfather',
    'Inception directedBy Christopher Nolan',
    'Godfather directedBy Francis Ford Coppola',
    'Godfather onDate 29.07.2018',
    'Fast and Furious onDate 30.07.2018',
    'Batman onDate 01.08.2018',
    'Fast and Furious directedBy Rob Cohen'
];
manageMovies(commands);

