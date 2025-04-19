import { expect } from "chai";
import {artGallery} from "../functions/05_ArtGallery.js"

describe("Tests for artGallery object", function() {

    // Tests for addArtwork
    describe("addArtwork", function() {
      it("should throw error for invalid title or artist", function() {
        expect(() => artGallery.addArtwork(123, "30 x 40", "Van Gogh")).to.throw("Invalid Information!");
        expect(() => artGallery.addArtwork("Starry Night", "30 x 40", 123)).to.throw("Invalid Information!");
      });
  
      it("should throw error for invalid dimensions format", function() {
        expect(() => artGallery.addArtwork("Starry Night", "invalid dimensions", "Van Gogh")).to.throw("Invalid Dimensions!");
        expect(() => artGallery.addArtwork("Starry Night", "30 by 40", "Van Gogh")).to.throw("Invalid Dimensions!");
      });
  
      it("should throw error for invalid artist", function() {
        expect(() => artGallery.addArtwork("Starry Night", "30 x 40", "Unknown Artist")).to.throw("This artist is not allowed in the gallery!");
      });
  
      it("should add valid artwork successfully", function() {
        const result = artGallery.addArtwork("Starry Night", "30 x 40", "Van Gogh");
        expect(result).to.equal("Artwork added successfully: 'Starry Night' by Van Gogh with dimensions 30 x 40.");
      });
    });
  
    // Tests for calculateCosts
    describe("calculateCosts", function() {
      it("should throw error for invalid costs or sponsor", function() {
        expect(() => artGallery.calculateCosts("100", 200, true)).to.throw("Invalid Information!");
        expect(() => artGallery.calculateCosts(100, "200", false)).to.throw("Invalid Information!");
        expect(() => artGallery.calculateCosts(100, 200, "yes")).to.throw("Invalid Information!");
        expect(() => artGallery.calculateCosts(-100, 200, true)).to.throw("Invalid Information!");
      });
  
      it("should calculate total cost without discount if sponsor is false", function() {
        const result = artGallery.calculateCosts(100, 200, false);
        expect(result).to.equal("Exhibition and insurance costs are 300$.");
      });
  
      it("should calculate total cost with a 10% discount if sponsor is true", function() {
        const result = artGallery.calculateCosts(100, 200, true);
        expect(result).to.equal("Exhibition and insurance costs are 270$, reduced by 10% with the help of a donation from your sponsor.");
      });
    });
  
    // Tests for organizeExhibits
    describe("organizeExhibits", function() {
      it("should throw error for invalid artworksCount or displaySpacesCount", function() {
        expect(() => artGallery.organizeExhibits("10", 2)).to.throw("Invalid Information!");
        expect(() => artGallery.organizeExhibits(10, "2")).to.throw("Invalid Information!");
        expect(() => artGallery.organizeExhibits(-10, 2)).to.throw("Invalid Information!");
        expect(() => artGallery.organizeExhibits(10, -2)).to.throw("Invalid Information!");
      });
  
      it("should return correct message when artworksPerSpace is less than 5", function() {
        const result = artGallery.organizeExhibits(10, 3);
        expect(result).to.equal("There are only 3 artworks in each display space, you can add more artworks.");
      });
  
      it("should return correct message when artworksPerSpace is 5 or more", function() {
        const result = artGallery.organizeExhibits(20, 4);
        expect(result).to.equal("You have 4 display spaces with 5 artworks in each space.");
      });
    });
  
  });