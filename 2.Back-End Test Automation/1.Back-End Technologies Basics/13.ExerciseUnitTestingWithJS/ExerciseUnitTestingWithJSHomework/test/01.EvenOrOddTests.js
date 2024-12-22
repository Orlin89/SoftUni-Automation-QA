import {expect} from 'chai';
import {isOddOrEven} from "../Functions/01.EvenOrOdd.js"

describe("IsOddOrEven function tests",function(){
    it("Tests with non string input shoul return undefined", function(){
        expect(isOddOrEven(1234)).to.be.undefined
        expect(isOddOrEven([])).to.be.undefined
        expect(isOddOrEven({})).to.be.undefined
        expect(isOddOrEven(undefined)).to.be.undefined
        expect(isOddOrEven(null)).to.be.undefined
    })

    it("Tests with even length string should return even", function(){
        expect(isOddOrEven("even")).to.equal("even")
        expect(isOddOrEven("eveneven")).to.equal("even")
        expect(isOddOrEven("")).to.equal("even")
    })

    it("Tests with odd length string should return odd", function(){
        expect(isOddOrEven("one")).to.equal("odd")
        expect(isOddOrEven("seven")).to.equal("odd")
        expect(isOddOrEven("a")).to.equal("odd")
    })
})