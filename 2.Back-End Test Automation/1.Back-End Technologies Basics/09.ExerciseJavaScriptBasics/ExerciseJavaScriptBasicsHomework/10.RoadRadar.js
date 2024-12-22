function roadRadar(input) {
    let speed = input[0];
    let area = input[1];
    
    // Define speed limits for different areas
    const speedLimits = {
        motorway: 130,
        interstate: 90,
        city: 50,
        residential: 20
    };

    // Get the speed limit for the given area
    let speedLimit = speedLimits[area];

    // Check if the speed is within the limit
    if (speed <= speedLimit) {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
    } else {
        // Calculate the difference
        let difference = speed - speedLimit;
        let status;

        // Determine the status based on the difference
        if (difference <= 20) {
            status = "speeding";
        } else if (difference <= 40) {
            status = "excessive speeding";
        } else {
            status = "reckless driving";
        }

        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
    }
}