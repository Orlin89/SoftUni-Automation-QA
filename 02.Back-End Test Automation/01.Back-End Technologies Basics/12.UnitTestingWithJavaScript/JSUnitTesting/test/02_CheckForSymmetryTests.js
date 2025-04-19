import {expect} from 'chai'
import {isSymmetric} from '../02_CheckForSymmetry.js'

describe("Tests for checkForSymmetryFunction", function(){

    it("should return true for symmetryc", function(){
        const result = isSymmetric([1,2,3,2,1]);

        expect(result).to.be.true;
    })

    it("should return false for non-symmetryc", function(){
        const result = isSymmetric([1,2,3,5,1]);

        expect(result).to.be.false;
    })

    it("should return true for empty array", function(){
        const result = isSymmetric([]);

        expect(result).to.be.true;
    })

    it("should return false for non-array", function(){
        const result = isSymmetric('this is not array');

        expect(result).to.be.false;
    })

    it("should return false for non numebr elements", function(){
        const result = isSymmetric([1, '1']);

        expect(result).to.be.false;
    })

    it("should return true for single element array", function(){
        const result = isSymmetric([1]);

        expect(result).to.be.true;
    })
})