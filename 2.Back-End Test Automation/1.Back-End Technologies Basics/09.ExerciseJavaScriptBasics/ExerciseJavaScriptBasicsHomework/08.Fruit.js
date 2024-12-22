function calculateCost(fruitDetails) 
{
    let fruit = fruitDetails[0];
    let weightInGrams = fruitDetails[1];
    let pricePerKg = fruitDetails[2];

    // Convert grams to kilograms
    let weightInKg = weightInGrams / 1000;

    // Calculate the total cost
    let totalCost = weightInKg * pricePerKg;

    // Print the result rounded to two decimal places
    console.log(`I need $${totalCost.toFixed(2)} to buy ${weightInKg.toFixed(2)} kilograms ${fruit}.`);
}    