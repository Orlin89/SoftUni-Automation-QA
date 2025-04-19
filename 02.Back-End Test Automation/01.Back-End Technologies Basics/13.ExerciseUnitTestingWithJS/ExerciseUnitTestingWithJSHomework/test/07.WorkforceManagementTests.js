import {expect} from 'chai';
import {workforceManagement} from "../Functions/07.WorkforceManagement.js";

describe("WorkforceManagement function tests", function(){

    describe("RecruitStaff function tests", function(){
        it("Role input data diferent from Developer should throw an error",function(){
           expect(() => workforceManagement.recruitStaff("Orlin", "system admin", 15)).to.throw(`We are not currently hiring for this role.`)
        })
        
        it("Test with role Developer and experience greater or equal to 4 should recruited successfully", function(){
            expect(workforceManagement.recruitStaff("Orlin", "Developer", 4)).to.equal(`Orlin has been successfully recruited for the role of Developer.`)
            expect(workforceManagement.recruitStaff("Orlin", "Developer", 10)).to.equal(`Orlin has been successfully recruited for the role of Developer.`)
        })

        it("Test with role Developer and experience smaller then 4 should throw an error", function(){
            expect(workforceManagement.recruitStaff("Orlin", "Developer", 3)).to.equal(`Orlin is not suitable for this role.`)
            expect(workforceManagement.recruitStaff("Orlin", "Developer", 2)).to.equal(`Orlin is not suitable for this role.`)
        })
    })

    describe("ComputeWages function tests", function(){
        it("Valid input data should return salary", function(){
            expect(workforceManagement.computeWages(100)).to.equal(1800);
        })

        it("Test with more than 160 hours input data should return salary with bonus 1500 BGN", function(){
            expect(workforceManagement.computeWages(170)).to.equal(4560);
        })

        it("Test input data with negative number should throw an error", function(){
            expect(() =>workforceManagement.computeWages(-20)).to.throw("Invalid hours");
        })

        it("Test input data with non number should throw an error", function(){
            expect(() =>workforceManagement.computeWages([])).to.throw("Invalid hours");
            expect(() =>workforceManagement.computeWages("string")).to.throw("Invalid hours");
            expect(() =>workforceManagement.computeWages(null)).to.throw("Invalid hours");
        })
    })

    describe("DismissEmployee function tests", function(){
        it("Valid input data should remove an element (employee) from the array", function(){
             expect(workforceManagement.dismissEmployee(["Orlin", "Joro", "Ivan"], 2)).to.equal("Orlin, Joro")
        })

        it("Test with non array input data for workforce should throw error", function(){
            expect(() => workforceManagement.dismissEmployee({}, 4)).to.throw("Invalid input");
            expect(() => workforceManagement.dismissEmployee("string", 4)).to.throw("Invalid input");
        })

        it("Test with non number input data for employeeIndex should throw error", function(){
            expect(() => workforceManagement.dismissEmployee(["Orlin", "Joro", "Ivan"], null)).to.throw("Invalid input");
            expect(() => workforceManagement.dismissEmployee(["Orlin", "Joro", "Ivan"], "string")).to.throw("Invalid input");
        })

        it("Test with negative number input data for employeeIndex should throw error", function(){
            expect(() => workforceManagement.dismissEmployee(["Orlin", "Joro", "Ivan"], -3)).to.throw("Invalid input");   
        })

        it("Test with outside of the limits of the array number input data for employeeIndex should throw error", function(){
            expect(() => workforceManagement.dismissEmployee(["Orlin", "Joro", "Ivan"], 3)).to.throw("Invalid input");   
        })
    })
});