import {expect} from 'chai'
import {createCalculator} from '../04.AddAndSubtract.js'

describe("Add and substract tests", function(){
    
    it("Check add function with valid number should pass", function(){
        //Arrange
        let calculator = createCalculator();
        let input = 5;

        //Act
        let act = calculator.add(input)
        let result = calculator.get()

        //Assert
        expect(result).to.equal(5)
    })
    it("Check substract function with valid number should pass", function(){
        //Arrange
        let calculator = createCalculator();       

        //Act
        let addNUmber = calculator.add(10) 
        let substractNumber = calculator.subtract(3)
        let result = calculator.get()

        //Assert
        expect(result).to.equal(7)
    })
    it("Check add function with valid string number should pass", function(){
        //Arrange
        let calculator = createCalculator();
        let input = '5';

        //Act
        let act = calculator.add(input)
        let result = calculator.get()

        //Assert
        expect(result).to.equal(5)
    })
    it("Check substract function with valid  string number should pass", function(){
        //Arrange
        let calculator = createCalculator();       

        //Act
        let addNUmber = calculator.add('10') 
        let substractNumber = calculator.subtract('3')
        let result = calculator.get()

        //Assert
        expect(result).to.equal(7)
    })
    it("Check substract function  from 0 should return negative number", function(){
        //Arrange
        let calculator = createCalculator();       

        //Act      
        let substractNumber = calculator.subtract(6)
        let result = calculator.get()

        //Assert
        expect(result).to.equal(-6)
    })
    it("Check add function with string should return NaN", function(){
        //Arrange
        let calculator = createCalculator();
        let input = 'a';

        //Act
        let act = calculator.add(input)
        let result = calculator.get()

        //Assert
        expect(result).to.be.NaN
    })
    it("Check substract function with string should return NaN", function(){
        //Arrange
        let calculator = createCalculator();       

        //Act
        let addNUmber = calculator.add(10) 
        let substractNumber = calculator.subtract('f')
        let result = calculator.get()

        //Assert
        expect(result).to.be.NaN
    })
})