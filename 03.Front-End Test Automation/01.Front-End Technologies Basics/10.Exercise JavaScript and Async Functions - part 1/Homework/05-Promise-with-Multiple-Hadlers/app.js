function promiseWithMultipleHandlers() {
    
    new Promise ((resolve, reject) => {
        setTimeout(() => {
            resolve ("Hello World")
        }, 2000);
    })
    .then ((result) => {
        console.log(result);
        return result;
    })
    .then ((result) => {
        console.log(result)
    })
}

// promiseWithMultipleHandlers();