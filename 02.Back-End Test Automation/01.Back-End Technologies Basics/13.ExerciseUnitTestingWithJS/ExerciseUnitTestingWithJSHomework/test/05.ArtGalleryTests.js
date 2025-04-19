import {expect} from 'chai';
import {artGallery} from "../Functions/05.ArtGallery.js";

describe("AddArtwork function tests", function(){
    it("Tests with non string title and artist should throw an error", function(){
        expect(() => artGallery.addArtwork(123, "30 x 30", "Van Gogh")).to.throw("Invalid Information!")
    })

    it("Tests with non string title and artist should throw an error", function(){
        expect(() => artGallery.addArtwork("Van Gogh", "30 x 30", 4 )).to.throw("Invalid Information!")
    })

    it("Tests dimensions with invalid input should throw an error", function(){
        expect(() => artGallery.addArtwork("title", " -30 x 30", "Van Gogh")).to.throw("Invalid Dimensions!")
    })

    it("Tests dimensions with invalid input should throw an error", function(){
        expect(() => artGallery.addArtwork("title", 30, "Van Gogh")).to.throw("Invalid Dimensions!")
    })

    it("Tests with non allowed artists should throw an error", function(){
        expect(() => artGallery.addArtwork("title", "30 x 30", "Orlin")).to.throw("This artist is not allowed in the gallery!")
    })

    it("Tests with all valid data input should  add artwork successfully", function(){
        expect(artGallery.addArtwork("title", "30 x 30", "Picasso")).to.equal("Artwork added successfully: 'title' by Picasso with dimensions 30 x 30.")
    })
});

describe("CalculateCosts function tests", function(){
    it("Test with non number insuranceCosts as input should throw an error", function(){
        expect(() => artGallery.calculateCosts("str", 5, true)).to.throw("Invalid Information!");
    })

    it("Test with negative number insuranceCosts as input should throw an error", function(){
        expect(() => artGallery.calculateCosts(-5, 5, true)).to.throw("Invalid Information!");
    })

    it("Test with non number exhibitionCosts as input should throw an error", function(){
        expect(() => artGallery.calculateCosts(10, "str", true)).to.throw("Invalid Information!");
    })

    it("Test with negative number exhibitionCosts as input should throw an error", function(){
        expect(() => artGallery.calculateCosts(10, -10, true)).to.throw("Invalid Information!");
    })

    it("Test with non boolean o	sponsor as input should throw an error", function(){
        expect(() => artGallery.calculateCosts(10, 5, [])).to.throw("Invalid Information!");
    })

    it("Summing exhibitionCosts and insuranceCosts with sponsor true, should apply a 10% discount to the total cost", function(){
        expect(artGallery.calculateCosts(50, 50, true)).to.equal("Exhibition and insurance costs are 90$, reduced by 10% with the help of a donation from your sponsor.");
    })

    it("Summing exhibitionCosts and insuranceCosts with sponsor false, should return total cost", function(){
        expect(artGallery.calculateCosts(50, 50, false)).to.equal("Exhibition and insurance costs are 100$.");
    })
});

describe("OrganizeExhibits function tests", function(){
    it("Test with negative number artworksCount as input should throw an error", function(){
        expect(() => artGallery.organizeExhibits(-5, 5)).to.throw("Invalid Information!");
    })

    it("Test with non number artworksCount as input should throw an error", function(){
        expect(() => artGallery.organizeExhibits([], 5)).to.throw("Invalid Information!");
    })

    it("Test with negative number displaySpacesCount as input should throw an error", function(){
        expect(() => artGallery.organizeExhibits(10, -5)).to.throw("Invalid Information!");
    })

    it("Test with non number displaySpacesCount as input should throw an error", function(){
        expect(() => artGallery.organizeExhibits(10, "string")).to.throw("Invalid Information!");
    })

    it("Tests if the number of artworks per display space is less than 5 should return correct message", function(){
        expect(artGallery.organizeExhibits(6, 2)).to.equal("There are only 3 artworks in each display space, you can add more artworks.")
    })

    it("Tests if the number of artworks per display space is bigger than 5 should return correct message", function(){
        expect(artGallery.organizeExhibits(20, 2)).to.equal("You have 2 display spaces with 10 artworks in each space.")
    })
});