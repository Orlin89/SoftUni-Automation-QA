import {expect} from 'chai';
import { analyzeArray } from '../functions/04_ArrayAnalyzer.js';

describe('analyzeArray', function() {
    
    // Test for non-array input
    it('should return undefined if the input is not an array', function() {
        expect(analyzeArray(123)).to.be.undefined;
        expect(analyzeArray('string')).to.be.undefined;
        expect(analyzeArray({})).to.be.undefined;
        expect(analyzeArray(null)).to.be.undefined;
    });

    // Test for empty array input
    it('should return undefined if the input is an empty array', function() {
        expect(analyzeArray([])).to.be.undefined;
    });

    // Test for an array containing non-number elements
    it('should return undefined if the array contains non-number elements', function() {
        expect(analyzeArray([1, 2, 'string', 4])).to.be.undefined;
        expect(analyzeArray([1, true, 3, 4])).to.be.undefined;
        expect(analyzeArray([{}, 2, 3])).to.be.undefined;
    });

    // Test for an array of numbers
    it('should return correct object with min, max, and length for an array of numbers', function() {
        expect(analyzeArray([1, 2, 3, 4, 5])).to.deep.equal({ min: 1, max: 5, length: 5 });
        expect(analyzeArray([-5, -10, 0, 5])).to.deep.equal({ min: -10, max: 5, length: 4 });
    });

    // Test for an array with a single element
    it('should return correct object for an array with a single element', function() {
        expect(analyzeArray([7])).to.deep.equal({ min: 7, max: 7, length: 1 });
    });

    // Test for an array with equal elements
    it('should return correct object for an array with all equal elements', function() {
        expect(analyzeArray([3, 3, 3, 3])).to.deep.equal({ min: 3, max: 3, length: 4 });
    });

    // Test for an array with floating-point numbers
    it('should return correct object for an array with floating-point numbers', function() {
        expect(analyzeArray([1.1, 2.2, 3.3])).to.deep.equal({ min: 1.1, max: 3.3, length: 3 });
    });
});