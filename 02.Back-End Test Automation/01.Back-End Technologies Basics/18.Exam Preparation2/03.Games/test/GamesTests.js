import{expect} from 'chai';
import {gameService} from '../Function/Games.js';

describe("gameService Tests", function() {

    describe("getGames()", function() {
        it("Should return a successful response with a list of games", function(){
          let response = gameService.getGames();
          expect(response.status).to.be.equal(200)
          expect(response.data).to.be.an('array').to.has.lengthOf(3)
          expect(response.data[0]).to.include.keys('id', 'title', 'genre', 'year', 'developer', 'description');  
        })       
    });
  
    describe("addGame()", function() {
        it("Should add a new game successfully", function(){
         let newGame = { id: "6", title: "WoW: Cataclysm", genre: "MMORPG", year: 2010, developer: "Blizzard", description: "An MMORPG game in an open world." }
         let response = gameService.addGame(newGame);
         expect(response.status).to.be.equal(201);
         expect(response.message).to.be.equal("Game added successfully.");
         expect(gameService.games).to.deep.include(newGame);        
        })
        
        it("Should return an error for invalid game data", function(){
            let invalidNewGame = { title: "WoW: Cataclysm", year: 2010};
            let response = gameService.addGame(invalidNewGame);
            expect(response.status).to.be.equal(400);
            expect(response.error).to.be.equal("Invalid Game Data!");
        })
        
    });
  
    describe("deleteGame()", function() {
        it("Should delete an existing game by ID", function(){
          let response = gameService.deleteGame('1');
          expect(response.status).to.be.equal(200);
          expect(response.message).to.be.equal("Game deleted successfully.");
          expect(gameService.games.find(game => game.id === '1')).to.be.undefined;
        })
        
  
        it("Should return an error if the game is not found", function(){
          let response = gameService.deleteGame('10');
          expect(response.status).to.be.equal(404);
          expect(response.error).to.be.equal("Game Not Found!");
        })       
    });
  
    describe("updateGame()", function() {
        it("Should update an existing game with new data", function(){
          let updateGame = { id: "7", title: "WoW: WOTLK", genre: "MMORPG", year: 2010, developer: "Blizzard", description: "An MMORPG game in an open world." } 
          let response = gameService.updateGame('2', updateGame);
          expect(response.status).to.be.equal(200);
          expect(response.message).to.be.equal("Game updated successfully.");
          expect(gameService.games.find(game => game.title === "WoW: WOTLK")).to.be.equal(updateGame);
        })
      
  
        it("Should return an error if the game to update is not found", function(){
          let updateGame = { id: "7", title: "WoW: WOTLK", genre: "MMORPG", year: 2010, developer: "Blizzard", description: "An MMORPG game in an open world." } 
          let response = gameService.updateGame('15', updateGame); 
          expect(response.status).to.be.equal(404);
          expect(response.error).to.be.equal("Game Not Found!");
        })
       
  
        it("Should return an error if the new game data is invalid", function(){
          let invalidNewGame = { title: "WoW: Cataclysm", year: 2010};
          let response = gameService.updateGame('3', invalidNewGame);
          expect(response.status).to.be.equal(400);
          expect(response.error).to.be.equal("Invalid Game Data!")
        })       
    });
  });