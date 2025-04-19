import { expect } from 'chai';
import { workforceManagement } from '../functions/07_WorkForceManagement.js';

describe("Tests for workforceManagement object", function() {

  // Tests for recruitStaff
  describe("recruitStaff", function() {
    it('should successfully recruit a developer with 4 or more years of experience', function() {
      const result = workforceManagement.recruitStaff("John", "Developer", 5);
      expect(result).to.equal("John has been successfully recruited for the role of Developer.");
    });

    it('should reject a developer with less than 4 years of experience', function() {
      const result = workforceManagement.recruitStaff("John", "Developer", 2);
      expect(result).to.equal("John is not suitable for this role.");
    });

    it('should throw error when the role is not "Developer"', function() {
      expect(() => workforceManagement.recruitStaff("John", "Designer", 5)).to.throw("We are not currently hiring for this role.");
    });
  });

  // Tests for computeWages
  describe("computeWages", function() {
    it('should calculate the wages without bonus for 160 or fewer hours', function() {
      const result = workforceManagement.computeWages(160);
      expect(result).to.equal(2880); // 160 * 18
    });

    it('should calculate the wages with bonus for more than 160 hours', function() {
      const result = workforceManagement.computeWages(170);
      expect(result).to.equal(4560); // 170 * 18 + 1500
    });

    it('should throw an error for invalid hoursWorked input', function() {
      expect(() => workforceManagement.computeWages("160")).to.throw("Invalid hours");
      expect(() => workforceManagement.computeWages(-5)).to.throw("Invalid hours");
    });
  });

  // Tests for dismissEmployee
  describe("dismissEmployee", function() {
    it('should dismiss an employee by index and return the updated workforce as a string', function() {
      const workforce = ["Petar", "Ivan", "George"];
      const result = workforceManagement.dismissEmployee(workforce, 1);
      expect(result).to.equal("Petar, George");
    });

    it('should throw an error for invalid workforce input', function() {
      expect(() => workforceManagement.dismissEmployee("Not an array", 1)).to.throw("Invalid input");
      expect(() => workforceManagement.dismissEmployee([], "Invalid index")).to.throw("Invalid input");
      expect(() => workforceManagement.dismissEmployee(["Petar"], -1)).to.throw("Invalid input");
      expect(() => workforceManagement.dismissEmployee(["Petar"], 2)).to.throw("Invalid input");
    });
  });

});