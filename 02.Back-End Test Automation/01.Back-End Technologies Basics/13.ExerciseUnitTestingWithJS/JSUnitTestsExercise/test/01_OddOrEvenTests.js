import {expect} from 'chai';
import {isOddOrEven} from "../functions/01_OddOrEven.js"

describe('isOddOrEven', function() {
    
    // Test for undefined when input is not a string
    it('should return undefined if the input is not a string', function() {
        expect(isOddOrEven(123)).to.be.undefined;
        expect(isOddOrEven({})).to.be.undefined;
        expect(isOddOrEven(null)).to.be.undefined;
        expect(isOddOrEven(undefined)).to.be.undefined;
        expect(isOddOrEven([])).to.be.undefined;
    });

    // Test for even length string
    it('should return "even" if the length of the string is even', function() {
        expect(isOddOrEven("test")).to.equal("even");
        expect(isOddOrEven("four")).to.equal("even");
    });

    // Test for odd length string
    it('should return "odd" if the length of the string is odd', function() {
        expect(isOddOrEven("hello")).to.equal("odd");
        expect(isOddOrEven("odd")).to.equal("odd");
    });

    // Test with multiple different strings
    it('should correctly evaluate multiple strings', function() {
        expect(isOddOrEven("")).to.equal("even"); // Empty string has length 0, which is even
        expect(isOddOrEven("a")).to.equal("odd");
        expect(isOddOrEven("ab")).to.equal("even");
        expect(isOddOrEven("abc")).to.equal("odd");
        expect(isOddOrEven("abcd")).to.equal("even");
    });
});