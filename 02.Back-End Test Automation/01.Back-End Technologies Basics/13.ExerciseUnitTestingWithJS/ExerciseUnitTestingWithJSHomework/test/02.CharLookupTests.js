import {expect} from 'chai';
import {lookupChar} from "../Functions/02.CharLookup.js";

describe("LookupChar function tests", function(){
    it("Test with non string as first parameter should return undefined", function(){
        expect(lookupChar(12, 5)).to.be.undefined;
        expect(lookupChar([], 5)).to.be.undefined;
        expect(lookupChar({}, 5)).to.be.undefined;
        expect(lookupChar(null, 5)).to.be.undefined;
    })

    it("Test with non number as second parameter should return undefined", function(){
        expect(lookupChar("hello","3")).to.be.undefined;
        expect(lookupChar("hello", "hi")).to.be.undefined;
        expect(lookupChar("hello", [])).to.be.undefined;
        expect(lookupChar("hello", null)).to.be.undefined;
        expect(lookupChar("hello", 3.5)).to.be.undefined;
    })

    it("Test with non string as first parameter and non number for second parameter should return undefined", function(){
        expect(lookupChar(12, "5")).to.be.undefined;
        expect(lookupChar([], {})).to.be.undefined;
        expect(lookupChar({}, [])).to.be.undefined;
        expect(lookupChar(null, null)).to.be.undefined;
    })

    it("Tests with negative number as index input",function(){
        expect(lookupChar("string", -3)).to.equal("Incorrect index");
        expect(lookupChar("string", -100)).to.equal("Incorrect index");
    })

    it("Tests with outside of the bounds index as input",function(){
        expect(lookupChar("string", 6)).to.equal("Incorrect index");
        expect(lookupChar("string", 100)).to.equal("Incorrect index");
        expect(lookupChar("string", 7)).to.equal("Incorrect index");
    })

    it("Tests with correct input returning the char at the specified index",function(){
        expect(lookupChar("string", 5)).to.equal("g");
        expect(lookupChar("string", 0)).to.equal("s");
        expect(lookupChar("string", 2)).to.equal("r");
    })
})