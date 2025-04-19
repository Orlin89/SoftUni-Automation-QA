function promiseRejection() {
    
    new Promise ((resolve, reject) => {
        setTimeout(() => {
            reject (new Error("Something went wrong!"))
        }, 1000);
    })

    .catch ((error) => {
        console.log(error)
    })
}

promiseRejection();