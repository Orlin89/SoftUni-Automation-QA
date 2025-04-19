function solve(products){
  
    function getProductsByCategory(category){
        let filteredproducts = [];
        for(let i = 0; i < products.length; i ++){
            if(products[i].category === category)
            {
                filteredproducts.push(products[i]);
            }
        }
        return filteredproducts;
    }
    
    function addProduct(id, name, category, price, stock)
    {
        let newProduct = {id, name, category, price, stock};
        products.push(newProduct);
        return products
    }

    function getProductById(id){
        for(let i = 0; i < products.length; i ++){
            if(products[i].id === id){
                return products[i];
            }           
        } 
        return `Product with ID ${id} not found`      
    }

    function removeProductById(id){
       for(let i = 0; i < products.length; i ++){
        if(products[i].id === id){
            products.splice(i, 1);
            return products;
        }        
       }
       return `Product with ID ${id} not found`
    }

    function updateProductPrice(id, newPrice){
        for(let i = 0; i < products.length; i ++){
            if(products[i].id === id){
              products[i].price = newPrice
              return products
            }           
        }
        return `Product with ID ${id} not found`
    }
    
    function updateProductStock(id, newStock){
        for(let i = 0; i < products.length; i ++){
            if(products[i].id === id){
                products[i].stock = newStock
                return products
            }            
        }
        return `Product with ID ${id} not found`
    }
    
    return {
        getProductsByCategory,
        addProduct,
        getProductById,
        removeProductById,
        updateProductPrice,
        updateProductStock
    }
}
