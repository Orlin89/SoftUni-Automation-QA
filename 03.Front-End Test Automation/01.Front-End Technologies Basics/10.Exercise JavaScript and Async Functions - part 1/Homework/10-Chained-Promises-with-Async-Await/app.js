async function chainedPromisesAsync() {
    
    const p1 = await new Promise((resolve, reject) => {
        setTimeout(() => {
            resolve("first")
        }, 1000);
    })

    const p2 = new Promise((resolve, reject) => {
        setTimeout(()=> {
            resolve("second")
        }, 2000)
    })

    const p3 = await new Promise((resolve, reject) => {
        setTimeout(()=> {
            resolve("third")
        }, 3000)
    })

    console.log(p1, p2, p3)
}

// chainedPromisesAsync();