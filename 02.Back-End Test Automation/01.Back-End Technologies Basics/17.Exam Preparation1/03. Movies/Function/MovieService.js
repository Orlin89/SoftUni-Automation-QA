export const movieService = {
    movies: [
        {
            id: "1",
            name: "Inception",
            genre: "Sci-Fi",
            year: 2010,
            director: "Christopher Nolan",
            rating: 8.8,
            duration: 148,
            language: "English",
            desc: "A thief who steals corporate secrets through the use of dream-sharing technology."
        },
        {
            id: "2",
            name: "The Matrix",
            genre: "Action",
            year: 1999,
            director: "Lana Wachowski, Lilly Wachowski",
            rating: 8.7,
            duration: 136,
            language: "English",
            desc: "A computer hacker learns about the true nature of reality and his role in the war against its controllers."
        },
        {
            id: "3",
            name: "Interstellar",
            genre: "Adventure",
            year: 2014,
            director: "Christopher Nolan",
            rating: 8.6,
            duration: 169,
            language: "English",
            desc: "A team of explorers travel through a wormhole in space in an attempt to ensure humanity's survival."
        }
    ],
    getMovies() {
        return {
            status: 200,
            data: this.movies
        };
    },
    addMovie(movie) {
        if (!movie.id || !movie.name || !movie.genre || !movie.year || !movie.director || !movie.rating || !movie.duration || !movie.language || !movie.desc) {
            return {
                status: 400,
                error: "Invalid Movie Data!"
            };
        }
        this.movies.push(movie);
        return {
            status: 201,
            message: "Movie added successfully."
        };
    },
    deleteMovie(movieId) {
    const movieIndex = this.movies.findIndex(movie => movie.id === movieId);
    if (movieIndex === -1) {
        return {
            status: 404,
            error: "Movie Not Found!"
        };
    }
    this.movies.splice(movieIndex, 1);
    return {
        status: 200,
        message: "Movie deleted successfully."
    };
},
    updateMovie(oldName, newMovie) {
        const movieIndex = this.movies.findIndex(movie => movie.name === oldName);
        if (movieIndex === -1) {
            return {
                status: 404,
                error: "Movie Not Found!"
            };
        }
        if (!newMovie.id || !newMovie.name || !newMovie.genre || !newMovie.year || !newMovie.director || !newMovie.rating || !newMovie.duration || !newMovie.language || !newMovie.desc) {
            return {
                status: 400,
                error: "Invalid Movie Data!"
            };
        }
        this.movies[movieIndex] = newMovie;
        return {
            status: 200,
            message: "Movie updated successfully."
        };
    }
};
