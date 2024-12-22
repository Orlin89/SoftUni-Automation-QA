function solve(cars) {
    function getCarsByBrand(brand) {
        let filteredCars = cars.filter(car => car.brand === brand);
        return filteredCars;
    }

    function addCar(id, brand, model, year, price, inStock) {
        let newCar = {id, brand, model, year, price, inStock};
        cars.push(newCar);
        return cars;
    }

    function getCarById(id) {
        let findById = cars.find(car => car.id === id);
        if(findById)
        {
            return findById;
        }
        else
        {
            return `Car with ID ${id} not found`
        }
    }

    function removeCarById(id) {
        let index = cars.findIndex(car => car.id === id);
        if(index !== -1)
        {
            cars.splice(index, 1);
            return cars;
        }
        else
        {
            return `Car with ID ${id} not found`
        }
    }

    function updateCarPrice(id, newPrice) {
        let updatePrice = cars.find(car => car.id === id);
        if(updatePrice)
        {
            updatePrice.price = newPrice;
            return cars;
        }
        else
        {
            return `Car with ID ${id} not found`
        }
    }

    function updateCarStock(id, inStock) {
        let updateStock = cars.find(car => car.id === id);
        if(updateStock)
        {
            updateStock.inStock = inStock;
            return cars;
        }
        else
        {
            return `Car with ID ${id} not found`
        }
    }

    return {
        getCarsByBrand,
        addCar,
        getCarById,
        removeCarById,
        updateCarPrice,
        updateCarStock
    };
}