import {expect} from 'chai';
import {mathEnforcer} from "../Functions/03.MathEnforcer.js";

describe("MathEnforcer function tests", function(){

    describe("AddFife function tests", function(){
        
        it("Tests if the parameter is NOT a number should return undefined", function(){
            expect(mathEnforcer.addFive([])).to.be.undefined;
            expect(mathEnforcer.addFive({})).to.be.undefined;
            expect(mathEnforcer.addFive(null)).to.be.undefined;
            expect(mathEnforcer.addFive("5")).to.be.undefined;
            expect(mathEnforcer.addFive(undefined)).to.be.undefined;
        })

        it("Tests if the parameter is a number, add 5 to it, and return the result", function(){
            expect(mathEnforcer.addFive(5)).to.equal(10);
            expect(mathEnforcer.addFive(-7)).to.equal(-2);
            expect(mathEnforcer.addFive(5.5)).to.closeTo(10.5, 0.01);
        })
    });

    describe("SubstractTen function tests", function(){
        it("Tests if the parameter is NOT a number, the function should return undefined", function(){
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
            expect(mathEnforcer.subtractTen(null)).to.be.undefined;
            expect(mathEnforcer.subtractTen("5")).to.be.undefined;
            expect(mathEnforcer.subtractTen(undefined)).to.be.undefined;
        })

        it("Tests if the parameter is a number, subtract 10 from it, and return the result", function(){
            expect(mathEnforcer.subtractTen(20)).to.equal(10);
            expect(mathEnforcer.subtractTen(-20)).to.equal(-30);
            expect(mathEnforcer.subtractTen(15.5)).to.closeTo(5.5, 0.01);
        })
    });

    describe("Sum function tests", function(){
        it("Tests if any of the 2 parameters is NOT a number, the function should return undefined", function(){
            expect(mathEnforcer.sum("string", 6)).to.be.undefined;
            expect(mathEnforcer.sum(6, "string")).to.be.undefined;
            expect(mathEnforcer.sum([], {})).to.be.undefined;
            expect(mathEnforcer.sum(null, undefined)).to.be.undefined;
        })

        it("Tests if both parameters are numbers, the function should return their sum.", function(){
            expect(mathEnforcer.sum(5, 5)).to.equal(10);
            expect(mathEnforcer.sum(-5, 5)).to.equal(0);
            expect(mathEnforcer.sum(4.5, 5.5)).to.closeTo(10.00, 0.01);
        })
    });
})