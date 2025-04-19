function updateStoreStock(currentStock, orderedProducts) {
    let store = {};

    // Process the current stock array
    for (let i = 0; i < currentStock.length; i += 2) {
        let product = currentStock[i];
        let quantity = Number(currentStock[i + 1]);
        store[product] = quantity;
    }

    // Process the ordered products array
    for (let i = 0; i < orderedProducts.length; i += 2) {
        let product = orderedProducts[i];
        let quantity = Number(orderedProducts[i + 1]);

        // If the product is already in stock, add the quantity
        if (store.hasOwnProperty(product)) {
            store[product] += quantity;
        } else {
            // If it's a new product, add it to the store
            store[product] = quantity;
        }
    }

    // Print the store inventory in the required format
    for (let product in store) {
        console.log(`${product} -> ${store[product]}`);
    }
}

// Test case 1
let currentStock1 = ['Chips', '5', 'CocaCola', '9', 'Bananas', '14', 'Pasta', '4', 'Beer', '2'];
let orderedProducts1 = ['Flour', '44', 'Oil', '12', 'Pasta', '7', 'Tomatoes', '70', 'Bananas', '30'];
updateStoreStock(currentStock1, orderedProducts1);

// Output:
// Chips -> 5
// CocaCola -> 9
// Bananas -> 44
// Pasta -> 11
// Beer -> 2
// Flour -> 44
// Oil -> 12
// Tomatoes -> 70

// Test case 2
let currentStock2 = ['Salt', '2', 'Fanta', '4', 'Apple', '14', 'Water', '4', 'Juice', '5'];
let orderedProducts2 = ['Apple', '7', 'Juice', '2', 'Bananas', '12'];
updateStoreStock(currentStock2, orderedProducts2);