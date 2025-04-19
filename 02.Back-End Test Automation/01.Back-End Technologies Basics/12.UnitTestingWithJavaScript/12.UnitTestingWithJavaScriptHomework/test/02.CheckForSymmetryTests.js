import {expect} from 'chai'
import {isSymmetric} from '../02.CheckForSymmetry.js'

describe("isSymmetric function tests",function(){
    it("Symmetryc array as a input should return true", function(){
        //Arrange
        let input = [1,2,3,2,1]

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.true
    })
    it("Non symmetryc array should return false", function(){
        //Arrange
        let input = [1,2,3,4]

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.false
    })
    it("Same numbers of an array should return true", function(){
        //Arrange
        let input = [2,2,2,2]

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.true
    })
    it("Empty array should return true", function(){
        //Arrange
        let input = []

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.true
    })
    it("Symetryc array with string numbers should return true", function(){
        //Arrange
        let input = ['1','2','3','2','1']

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.true
    })   
    it("Symetryc array with strings and numbers should return false", function(){
        //Arrange
        let input = ['1','2','3',2,1]

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.false
    })
    it("Array with one element should return true", function(){
        //Arrange
        let input = ['a']

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.true
    })
    it("Non symmetryc array with strings should return false", function(){
        //Arrange
        let input = ['a','b','c','d']

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.false
    })
    it("Non array input should return false", function(){
        //Arrange
        let input = 'This is not an array'

        //Act
        let result = isSymmetric(input)

        //Assert
        expect(result).to.be.false
    })
})