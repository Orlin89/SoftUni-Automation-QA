function fruits(arr)
{
    let fruitName = arr[0];
    let weightIngrams = arr[1];
    let pricePerKg = arr[2];
    let weightInKG = weightIngrams / 1000.0;
    let neededMoney = pricePerKg * weightInKG;

    console.log(`I need $${neededMoney.toFixed(2)} to buy ${weightInKG.toFixed(2)} kilograms ${fruitName}.`);
}

fruits(['orange', 2500, 1.80])