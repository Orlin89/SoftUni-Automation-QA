// Unit tests using Mocha and Chai
import {expect} from 'chai'
import {lookupChar} from "../functions/02_CharLookup.js"

describe('lookupChar', function() {
    
    // Test for undefined when the first parameter is not a string or the second parameter is not a number
    it('should return undefined if the first parameter is not a string', function() {
        expect(lookupChar(123, 0)).to.be.undefined;
        expect(lookupChar([], 0)).to.be.undefined;
        expect(lookupChar({}, 0)).to.be.undefined;
        expect(lookupChar(null, 0)).to.be.undefined;
    });

    it('should return undefined if the second parameter is not an integer', function() {
        expect(lookupChar("hello", "0")).to.be.undefined;
        expect(lookupChar("hello", 1.5)).to.be.undefined;
        expect(lookupChar("hello", [])).to.be.undefined;
        expect(lookupChar("hello", null)).to.be.undefined;
    });

    // Test for "Incorrect index" when index is out of bounds (negative or greater than or equal to string length)
    it('should return "Incorrect index" if the index is negative', function() {
        expect(lookupChar("hello", -1)).to.equal("Incorrect index");
    });

    it('should return "Incorrect index" if the index is greater than or equal to the string length', function() {
        expect(lookupChar("hello", 5)).to.equal("Incorrect index");
        expect(lookupChar("hello", 10)).to.equal("Incorrect index");
    });

    // Test for returning the character at the specified index
    it('should return the correct character when valid inputs are provided', function() {
        expect(lookupChar("hello", 0)).to.equal('h');
        expect(lookupChar("hello", 1)).to.equal('e');
        expect(lookupChar("hello", 4)).to.equal('o');
    });

    // Test for edge cases
    it('should handle an empty string correctly', function() {
        expect(lookupChar("", 0)).to.equal("Incorrect index");
    });
});