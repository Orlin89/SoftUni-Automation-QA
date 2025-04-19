import {expect} from "chai";
import {movieService} from "../Function/MovieService.js"

describe("movieService Tests", function () {

  describe("getMovies()", function () {
    it("should return all movies with status 200", function () {
      const response = movieService.getMovies();
      expect(response.status).to.equal(200);
      expect(response.data).to.be.an("array").that.has.lengthOf(3);
      expect(response.data[0]).to.include.all.keys('id', 'name', 'genre', 'year', 'director', 'rating', 'duration', 'language', 'desc');
    });
  });

  describe("addMovie()", function () {
    it("should successfully add a new movie", function () {
      const newMovie = {
        id: "4",
        name: "Dunkirk",
        genre: "War",
        year: 2017,
        director: "Christopher Nolan",
        rating: 7.9,
        duration: 106,
        language: "English",
        desc: "Allied soldiers are surrounded by the German Army."
      };
      const response = movieService.addMovie(newMovie);
      expect(response.status).to.equal(201);
      expect(response.message).to.equal("Movie added successfully.");
      expect(movieService.movies).to.deep.include(newMovie);
    });

    it("should return an error for invalid movie data", function () {
      const invalidMovie = {
        id: "5",
        name: "Incomplete Movie"
      };
      const response = movieService.addMovie(invalidMovie);
      expect(response.status).to.equal(400);
      expect(response.error).to.equal("Invalid Movie Data!");
    });
  });

  describe("deleteMovie()", function () {
    it("should delete a movie by id successfully", function () {
      const newMovie = {
        id: "6",
        name: "Test Movie",
        genre: "Drama",
        year: 2020,
        director: "Test Director",
        rating: 7.0,
        duration: 120,
        language: "English",
        desc: "A test description."
      };
      movieService.addMovie(newMovie);
      const response = movieService.deleteMovie("6");
      expect(response.status).to.equal(200);
      expect(response.message).to.equal("Movie deleted successfully.");
      expect(movieService.movies.find(movie => movie.id === "6")).to.be.undefined;
    });

    it("should return 404 for a non-existent movie id", function () {
      const response = movieService.deleteMovie("non-existent-id");
      expect(response.status).to.equal(404);
      expect(response.error).to.equal("Movie Not Found!");
    });
  });

  describe("updateMovie()", function () {
    it("should update an existing movie successfully", function () {
      const updatedMovie = {
        id: "1",
        name: "Inception Updated",
        genre: "Sci-Fi",
        year: 2010,
        director: "Christopher Nolan",
        rating: 8.8,
        duration: 148,
        language: "English",
        desc: "A thief who updates secrets through dream-sharing technology."
      };
      const response = movieService.updateMovie("Inception", updatedMovie);
      expect(response.status).to.equal(200);
      expect(response.message).to.equal("Movie updated successfully.");
      expect(movieService.movies.find(movie => movie.name === "Inception Updated")).to.deep.equal(updatedMovie);
    });

    it("should return an error if the movie to update does not exist", function () {
      const nonExistentMovie = {
        id: "non-existent-id",
        name: "Non-existent Movie",
        genre: "Sci-Fi",
        year: 2022,
        director: "Unknown",
        rating: 7.5,
        duration: 130,
        language: "English",
        desc: "This movie does not exist."
      };
      const response = movieService.updateMovie("Non-existent Movie", nonExistentMovie);
      expect(response.status).to.equal(404);
      expect(response.error).to.equal("Movie Not Found!");
    });

    it("should return an error if the new movie data is invalid", function () {
      const invalidUpdatedMovie = {
        id: "1",
        name: "Inception",
        genre: "Sci-Fi",
      };
      const response = movieService.updateMovie("The Matrix", invalidUpdatedMovie);
      expect(response.status).to.equal(400);
      expect(response.error).to.equal("Invalid Movie Data!");
    });
  });

});