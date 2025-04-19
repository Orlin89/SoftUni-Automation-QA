function solve(products) {
    function getProductsByCategory(category) {
        return products.filter(product => product.category === category);
    }

    function addProduct(id, name, category, price, stock) {
        products.push({ id, name, category, price, stock });
        return products;
    }

    function getProductById(id) {
        const product = products.find(product => product.id === id);
        return product || `Product with ID ${id} not found`;
    }

    function removeProductById(id) {
        const index = products.findIndex(product => product.id === id);
        if (index !== -1) {
            products.splice(index, 1);
            return products;
        }
        return `Product with ID ${id} not found`;
    }

    function updateProductPrice(id, newPrice) {
        const product = products.find(product => product.id === id);
        if (product) {
            product.price = newPrice;
            return products;
        }
        return `Product with ID ${id} not found`;
    }

    function updateProductStock(id, newStock) {
        const product = products.find(product => product.id === id);
        if (product) {
            product.stock = newStock;
            return products;
        }
        return `Product with ID ${id} not found`;
    }

    return {
        getProductsByCategory,
        addProduct,
        getProductById,
        removeProductById,
        updateProductPrice,
        updateProductStock
    };
}
