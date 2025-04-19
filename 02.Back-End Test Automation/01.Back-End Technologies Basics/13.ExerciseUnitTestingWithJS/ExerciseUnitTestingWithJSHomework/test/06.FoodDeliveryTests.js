import {expect} from 'chai';
import {foodDelivery} from "../Functions/06.FoodDelivery.js";

describe("FoodDelivery", function(){

    describe("GetCategory function tests", function(){
        it("Test with category Vegan should return correct message", function(){
            expect(foodDelivery.getCategory("Vegan")).to.equal("Dishes that contain no animal products.")
        })

        it("Test with category Vegetarian should return correct message", function(){
            expect(foodDelivery.getCategory("Vegetarian")).to.equal("Dishes that contain no meat or fish.")
        })

        it("Test with category Gluten-Free should return correct message", function(){
            expect(foodDelivery.getCategory("Gluten-Free")).to.equal("Dishes that contain no gluten.")
        })

        it("Test with category All should return correct message", function(){
            expect(foodDelivery.getCategory("All")).to.equal("All available dishes.")
        })

        it("Test with non string input data should throw an error", function(){
            expect(() => foodDelivery.getCategory([])).to.throw("Invalid Category!")
        })

    })

    describe("AddMenuItem function tests", function(){
        it("Test with valid input should add item", function(){
            let menuItem = [{name: "pizza", price: 10}, {name: "meat", price: 20}]
            expect(foodDelivery.addMenuItem(menuItem, 20)).to.equal("There are 2 available menu items matching your criteria!");
        })

        it("Test with non array menuItem input should throw an error", function(){           
            expect(() => foodDelivery.addMenuItem("string", 20)).to.throw("Invalid Information!");
        })

        it("Test with empty array menuItem input should throw an error", function(){           
            expect(() => foodDelivery.addMenuItem([], 20)).to.throw("Invalid Information!");
        })

        it("Test with non number maxPrice input should throw an error", function(){
            let menuItem = [{name: "pizza", price: 10}, {name: "meat", price: 20}]
            expect(() => foodDelivery.addMenuItem(menuItem, "20")).to.throw("Invalid Information!");
        })

        it("Test with maxPrice input is les then 5 should throw an error", function(){
            let menuItem = [{name: "pizza", price: 10}, {name: "meat", price: 20}]
            expect(() => foodDelivery.addMenuItem(menuItem, 4)).to.throw("Invalid Information!");
        })
    })

    describe("CalculateOrderCost function tests", function(){
        it("Valid standard shipping and addons input data with discount true should return correct message", function(){
            let shipping = ["standard"];
            let addons = ["sauce", "beverage"];
            expect(foodDelivery.calculateOrderCost(shipping, addons, true)).to.equal("You spend $6.38 for shipping and addons with a 15% discount!") 

        })

        it("Valid express shipping and addons input data with discount false should return correct message", function(){
            let shipping = ["express"];
            let addons = ["sauce", "beverage"];
            expect(foodDelivery.calculateOrderCost(shipping, addons, false)).to.equal("You spend $9.50 for shipping and addons!"); 
        })

        it("Test with invalid shipping input data should throw an error", function(){           
            let addons = ["sauce", "beverage"];
            expect(() => foodDelivery.calculateOrderCost({}, addons, false)).to.throw("Invalid Information!"); 
        })

        it("Test with invalid addons input data should throw an error", function(){           
            let shipping = ["express"];
            expect(() => foodDelivery.calculateOrderCost(shipping, 6, false)).to.throw("Invalid Information!"); 
        })

        it("Test with invalid discount input data should throw an error", function(){           
            let shipping = ["express"];
            let addons = ["sauce", "beverage"];
            expect(() => foodDelivery.calculateOrderCost(shipping, addons, null)).to.throw("Invalid Information!"); 
        })
    })
})