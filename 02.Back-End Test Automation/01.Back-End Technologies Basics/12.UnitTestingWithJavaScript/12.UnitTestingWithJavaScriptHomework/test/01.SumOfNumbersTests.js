import {expect} from 'chai'
import {sum} from '../01.SumOfNumbers.js'

describe("Sum function tests",function(){
    it("Should return sum of an array of numbers",function(){
        //Arrange
        let input = [1,2,3]

        //Act
        let result = sum(input)

        //Assert
        expect(result).to.equal(6)
    })
    it("Return same number when array contains only one", function(){
        //Arrange
        let input = [3]

        //Act
        let result = sum(input)

        //Assert
        expect(result).to.equal(3)
    })
    it("Sum of an array of string numbers should return the correct sum", function(){
        //Arrange
        let input = ['1','2','3']
        //Act
        let result = sum(input)

        //Assert
        expect(result).to.equal(6)
    })
    it("Sum of an array of strings should return NaN", function(){
        //Arrange
        let input = ['a','b','c']

        //Act
        let result = sum(input)

        //Assert
        expect(result).to.be.NaN
    })
    it("Sum of negative numbers in array should return sum", function(){
        //Arrange
        let input = [-1,-2,-3]

        //Act
        let result = sum(input)

        //Assert
        expect(result).to.equal(-6)
    })
    it("Sum of an empty array should return 0", function(){
        //Arrange
        let input = []

        //Act
        let result = sum(input)

        //Assert
        expect(result).to.equal(0)
    })
})