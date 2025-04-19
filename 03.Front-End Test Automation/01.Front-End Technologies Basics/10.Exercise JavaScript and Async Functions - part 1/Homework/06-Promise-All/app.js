function allPromise() {
    
    let p1 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("1 second")
        }, 1000);
    })

    let p2 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("2 second")
        }, 2000);
    })

    let p3 = new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("3 second")
        }, 3000);
    })

    Promise.all([p1, p2, p3])
    
    .then((result) => {
        console.log(result)
    })
}

// allPromise();