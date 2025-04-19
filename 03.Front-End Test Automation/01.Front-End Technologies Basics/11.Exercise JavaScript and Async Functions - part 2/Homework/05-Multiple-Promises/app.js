async function multiplePromises() {
      
      const response = await Promise.allSettled([
          new Promise((resolve, reject) => {
            setTimeout(() => {
                  resolve("Eat pizza")
            }, 1000);
          }),

          new Promise((resolve, reject) => {
            setTimeout(() => {
                  resolve("Eat hotdog")
            }, 2000);
          }),

          new Promise((resolve, reject) => {
            setTimeout(() => {
                  reject("Eat banana")
            }, 3000);
          })
      ])
      
      for (const data of response) {
            if (data.status === "fulfilled") {
                console.log(`Status: ${data.status} Value: ${data.value}`);
            } else if (data.status === "rejected") {
                console.error(`Status: ${data.status} Reason: ${data.reason}`);
            }
      }
     
}

// multiplePromises();