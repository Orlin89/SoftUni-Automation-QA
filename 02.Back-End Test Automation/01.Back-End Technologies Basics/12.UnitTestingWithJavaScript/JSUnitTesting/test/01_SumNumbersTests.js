import {expect} from 'chai'
import {sum} from '../01_SumNumbers.js'

describe("Sum function tests", function() {
    
    it("should return the sum of an array of numbers", function() {
        //arrange
        let testData = [1, 2 , 3]
        let result;

        //act
        result = sum(testData);

        //assert
        expect(result).to.equal(6)
    })

    it("should return the sum of an array as string", function() {
        //arrange
        let testData = ['1', '2' , '3']
        let result;

        //act
        result = sum(testData);

        //assert
        expect(result).to.equal(6)
    })

    it("should return 0 when pass array with 0 elements", function() {
        //arrange
        let testData = []
        let result;

        //act
        result = sum(testData);

        //assert
        expect(result).to.equal(0)
    })

    it("should return correct sum when pass negative numbers", function() {
        //arrange
        let testData = [-1, -2, -3]
        let result;

        //act
        result = sum(testData);

        //assert
        expect(result).to.equal(-6)
    })

    it("should return correct sum when pass mixed input", function() {
        //arrange
        let testData = [1, '2', 3]
        let result;

        //act
        result = sum(testData);

        //assert
        expect(result).to.equal(6)
    })

    it("should return correct sum when pass chars as input", function() {
        //arrange
        let testData = ['a', 'b', 'a']
        let result;

        //act
        result = sum(testData);

        //assert
        expect(result).to.be.NaN
    })
})