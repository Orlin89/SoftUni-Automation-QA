function listEmployees(employees) {
    let employeeData = {};  // Object to store employee names and personal numbers

    // Iterate through each employee and assign personal number based on name length
    employees.forEach(employee => {
        let personalNum = employee.length;  // Personal number is the length of the name
        employeeData[employee] = personalNum;  // Store in the object
    });

    // Print the object
    for (let employee in employeeData) {
        console.log(`Name: ${employee} -- Personal Number: ${employeeData[employee]}`);
    }
}

// Test case
let employees = ['Silas Butler', 'Adnaan Buckley', 'Juan Peterson', 'Brendan Villarreal'];
listEmployees(employees);