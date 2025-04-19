import { expect } from 'chai';
import { foodDelivery } from '../functions/06_FoodDelivery.js';

describe("Tests for foodDelivery object", function() {
  
  // Tests for getCategory
  describe("getCategory", function() {
    it('should return correct string for "Vegan"', function() {
      expect(foodDelivery.getCategory("Vegan")).to.equal("Dishes that contain no animal products.");
    });

    it('should return correct string for "Vegetarian"', function() {
      expect(foodDelivery.getCategory("Vegetarian")).to.equal("Dishes that contain no meat or fish.");
    });

    it('should return correct string for "Gluten-Free"', function() {
      expect(foodDelivery.getCategory("Gluten-Free")).to.equal("Dishes that contain no gluten.");
    });

    it('should return correct string for "All"', function() {
      expect(foodDelivery.getCategory("All")).to.equal("All available dishes.");
    });

    it('should throw error for invalid category', function() {
      expect(() => foodDelivery.getCategory("Meat")).to.throw("Invalid Category!");
    });
  });

  // Tests for addMenuItem
  describe("addMenuItem", function() {
    it('should add items with valid price and return correct array length', function() {
      const menuItems = [
        { name: "Salad", price: 8 },
        { name: "Soup", price: 5 },
        { name: "Steak", price: 20 }
      ];
      expect(foodDelivery.addMenuItem(menuItems, 10)).to.equal("There are 2 available menu items matching your criteria!");
    });

    it('should throw error for invalid parameters (non-array or non-number)', function() {
      expect(() => foodDelivery.addMenuItem("Not an array", 10)).to.throw("Invalid Information!");
      expect(() => foodDelivery.addMenuItem([], "Not a number")).to.throw("Invalid Information!");
    });

    it('should throw error for menu array with less than 1 item or maxPrice less than 5', function() {
      expect(() => foodDelivery.addMenuItem([], 10)).to.throw("Invalid Information!");
      expect(() => foodDelivery.addMenuItem([{ name: "Salad", price: 8 }], 3)).to.throw("Invalid Information!");
    });
  });

  // Tests for calculateOrderCost
  describe("calculateOrderCost", function() {
    it('should calculate total price without discount', function() {
      const shipping = ["standard"];
      const addons = ["sauce", "beverage"];
      expect(foodDelivery.calculateOrderCost(shipping, addons, false)).to.equal("You spend $7.50 for shipping and addons!");
    });

    it('should calculate total price with discount', function() {
      const shipping = ["express"];
      const addons = ["sauce", "beverage"];
      expect(foodDelivery.calculateOrderCost(shipping, addons, true)).to.equal("You spend $8.07 for shipping and addons with a 15% discount!");
    });

    it('should throw error for invalid parameters', function() {
      expect(() => foodDelivery.calculateOrderCost("standard", [], true)).to.throw("Invalid Information!");
      expect(() => foodDelivery.calculateOrderCost([], "sauce", true)).to.throw("Invalid Information!");
      expect(() => foodDelivery.calculateOrderCost([], [], "not boolean")).to.throw("Invalid Information!");
    });
  });
});