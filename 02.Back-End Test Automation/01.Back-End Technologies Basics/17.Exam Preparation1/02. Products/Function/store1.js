function solve(products) {

    // 1. Filter products by category
    function getProductsByCategory(category) {
        var filteredProducts = [];
        for (var i = 0; i < products.length; i++) {
            if (products[i].category === category) {
                filteredProducts.push(products[i]);
            }
        }
        return filteredProducts;
    }

    // 2. Add a new product
    function addProduct(id, name, category, price, stock) {
        var newProduct = { id: id, name: name, category: category, price: price, stock: stock };
        products.push(newProduct);
        return products;
    }

    // 3. Find product by ID
    function getProductById(id) {
        for (var i = 0; i < products.length; i++) {
            if (products[i].id === id) {
                return products[i];
            }
        }
        return "Product with ID " + id + " not found";
    }

    // 4. Remove product by ID
    function removeProductById(id) {
        for (var i = 0; i < products.length; i++) {
            if (products[i].id === id) {
                products.splice(i, 1); // Remove product at index i
                return products;
            }
        }
        return "Product with ID " + id + " not found";
    }

    // 5. Update product price
    function updateProductPrice(id, newPrice) {
        for (var i = 0; i < products.length; i++) {
            if (products[i].id === id) {
                products[i].price = newPrice;
                return products;
            }
        }
        return "Product with ID " + id + " not found";
    }

    // 6. Update product stock
    function updateProductStock(id, newStock) {
        for (var i = 0; i < products.length; i++) {
            if (products[i].id === id) {
                products[i].stock = newStock;
                return products;
            }
        }
        return "Product with ID " + id + " not found";
    }

    // Returning all functions to allow external access
    return {
        getProductsByCategory: getProductsByCategory,
        addProduct: addProduct,
        getProductById: getProductById,
        removeProductById: removeProductById,
        updateProductPrice: updateProductPrice,
        updateProductStock: updateProductStock
    };
}
