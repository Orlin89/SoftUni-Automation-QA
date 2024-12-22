function piccolo(input) {
    let parkingLot = [];

    // Process each entry/exit
    input.forEach(command => {
        let [direction, carNumber] = command.split(', ');
        if (direction === 'IN') {
            if (!parkingLot.includes(carNumber)) {
                parkingLot.push(carNumber);  // Add the car to the parking lot if it's not already in
            }
        } else if (direction === 'OUT') {
            if (parkingLot.includes(carNumber)) {
                parkingLot = parkingLot.filter(car => car !== carNumber);  // Remove the car if it's in the parking lot
            }
        }
    });

    // Sort the car numbers in ascending order
    let sortedCars = parkingLot.sort();

    // Print the result
    if (sortedCars.length > 0) {
        sortedCars.forEach(car => console.log(car));
    } else {
        console.log("Parking Lot is Empty");
    }
}


// Test case
let input = [
    'IN, CA2844AA',
    'IN, CA1234TA',
    'OUT, CA2844AA',
    'IN, CA9999TT',
    'IN, CA2866HI',
    'OUT, CA1234TA',
    'IN, CA2844AA',
    'OUT, CA2866HI',
    'IN, CA9876HH',
    'IN, CA2822UU'
];
piccolo(input);