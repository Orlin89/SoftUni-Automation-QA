function simplePromise() {
    
    new Promise ((resolve, reject) => {
        setTimeout(() => {
            resolve('Success!');
        }, 2000);
    })
    .then ((result) => {
        console.log(result)
    });
}

// simplePromise();