async function promiseRejectionAsync() {
   
   try {
      await new Promise((resolve, reject) => {
         setTimeout(() => {
            reject(new Error("oops!"))
         }, 1000);
      })
   } catch (error) {
      console.error(error)
   }
}

// promiseRejectionAsync();