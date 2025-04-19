import {expect} from 'chai'
import {rgbToHexColor} from '../03.RGBToHex.js'

describe("RBG to Hex function tests", function(){

    it("All numbers in range 0 - 255 should return correct hex", function(){
       
        //Arrange
        let red = 144;
        let green = 200;
        let blue = 10;

        //Act
        let result = rgbToHexColor(red, green, blue)

        //Assert
        expect(result).to.equal('#90C80A')
    })
    it("All numbers in upper boundary range should return correct hex", function(){
       
        //Arrange
        let red = 255;
        let green = 255;
        let blue = 255;

        //Act
        let result = rgbToHexColor(red, green, blue)

        //Assert
        expect(result).to.equal('#FFFFFF')
    })
    it("All numbers in lower boundary range should return correct hex", function(){
       
        //Arrange
        let red = 0;
        let green = 0;
        let blue = 0;

        //Act
        let result = rgbToHexColor(red, green, blue)

        //Assert
        expect(result).to.equal('#000000')
    })
    it("Red number in out of boundary range should return undefined", function(){
       
        //Arrange
        let red = -4;
        let green = 100;
        let blue = 160;

        //Act
        let result = rgbToHexColor(red, green, blue)

        //Assert
        expect(result).to.be.undefined
    })
    it("Green number in out of boundary range should return undefined", function(){
       
        //Arrange
        let red = 15;
        let green = 260;
        let blue = 102;

        //Act
        let result = rgbToHexColor(red, green, blue)

        //Assert
        expect(result).to.be.undefined
    })
    it("Blue number in out of boundary range should return undefined", function(){
       
        //Arrange
        let red = 33;
        let green = 220;
        let blue = 1000;

        //Act
        let result = rgbToHexColor(red, green, blue)

        //Assert
        expect(result).to.be.undefined
    })
})