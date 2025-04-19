import {expect} from 'chai';
import {analyzeArray} from "../Functions/04.ArrayAnalyzer.js";

describe("AnalyzeArray function tests", function(){
    it("Test if the input is an array of numbers shoul return correct object", function(){       
        expect(analyzeArray([2, 4, 7, 6, 1, 10])).to.deep.equal({ min: 1, max: 10, length: 6});
    })

    it("Test with empty array input should return undefined", function(){
        expect(analyzeArray([])).to.be.undefined;
    })

    it("Test with non array input should return undefined", function(){
        expect(analyzeArray("string")).to.be.undefined;
    })

    it("Test with input is an array of single number shoul return correct object", function(){       
        expect(analyzeArray([2,])).to.deep.equal({ min: 2, max: 2, length: 1});
    })

    it("Test if the input is an array of strings shoul return undefined", function(){       
        expect(analyzeArray(["2", "4", "7", "6", "1", "10"])).to.be.undefined;
    })

    it("Test input is an array with equal numbers shoul return correct object", function(){       
        expect(analyzeArray([4, 4, 4])).to.deep.equal({ min: 4, max: 4, length: 3});
    })
})