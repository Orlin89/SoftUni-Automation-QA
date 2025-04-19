import { expect } from "chai";
import {mathEnforcer} from "../functions/03_MathEnforcer.js"

// Tests for mathEnforcer
describe('mathEnforcer', function() {

    // Tests for addFive function
    describe('addFive', function() {
        it('should return undefined with a non-number parameter', function() {
            expect(mathEnforcer.addFive('5')).to.be.undefined;
            expect(mathEnforcer.addFive([])).to.be.undefined;
            expect(mathEnforcer.addFive({})).to.be.undefined;
            expect(mathEnforcer.addFive(null)).to.be.undefined;
        });

        it('should return correct result with a positive number', function() {
            expect(mathEnforcer.addFive(5)).to.equal(10);
        });

        it('should return correct result with a negative number', function() {
            expect(mathEnforcer.addFive(-5)).to.equal(0);
        });

        it('should return correct result with a floating-point number', function() {
            expect(mathEnforcer.addFive(5.5)).to.be.closeTo(10.5, 0.01);
        });
    });

    // Tests for subtractTen function
    describe('subtractTen', function() {
        it('should return undefined with a non-number parameter', function() {
            expect(mathEnforcer.subtractTen('10')).to.be.undefined;
            expect(mathEnforcer.subtractTen([])).to.be.undefined;
            expect(mathEnforcer.subtractTen({})).to.be.undefined;
            expect(mathEnforcer.subtractTen(null)).to.be.undefined;
        });

        it('should return correct result with a positive number', function() {
            expect(mathEnforcer.subtractTen(20)).to.equal(10);
        });

        it('should return correct result with a negative number', function() {
            expect(mathEnforcer.subtractTen(-10)).to.equal(-20);
        });

        it('should return correct result with a floating-point number', function() {
            expect(mathEnforcer.subtractTen(10.5)).to.be.closeTo(0.5, 0.01);
        });
    });

    // Tests for sum function
    describe('sum', function() {
        it('should return undefined with a non-number first parameter', function() {
            expect(mathEnforcer.sum('5', 5)).to.be.undefined;
            expect(mathEnforcer.sum([], 5)).to.be.undefined;
            expect(mathEnforcer.sum({}, 5)).to.be.undefined;
            expect(mathEnforcer.sum(null, 5)).to.be.undefined;
        });

        it('should return undefined with a non-number second parameter', function() {
            expect(mathEnforcer.sum(5, '5')).to.be.undefined;
            expect(mathEnforcer.sum(5, [])).to.be.undefined;
            expect(mathEnforcer.sum(5, {})).to.be.undefined;
            expect(mathEnforcer.sum(5, null)).to.be.undefined;
        });

        it('should return correct sum with two positive numbers', function() {
            expect(mathEnforcer.sum(5, 10)).to.equal(15);
        });

        it('should return correct sum with two negative numbers', function() {
            expect(mathEnforcer.sum(-5, -10)).to.equal(-15);
        });

        it('should return correct sum with a positive and a negative number', function() {
            expect(mathEnforcer.sum(5, -10)).to.equal(-5);
        });

        it('should return correct sum with two floating-point numbers', function() {
            expect(mathEnforcer.sum(5.5, 4.5)).to.be.closeTo(10.0, 0.01);
        });
    });

});