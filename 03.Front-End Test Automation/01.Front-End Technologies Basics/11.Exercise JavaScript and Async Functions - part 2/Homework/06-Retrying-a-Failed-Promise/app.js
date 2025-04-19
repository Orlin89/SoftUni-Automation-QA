async function retryPromise(promiseFunc, retries = 3) {
  let atemptsFailed = 0;
  while(atemptsFailed < retries)
  {
    try {
      const result = await promiseFunc();
      console.log(result);
      return;
    } catch (error) {
      atemptsFailed++;
      console.log(`Faild atempt #${atemptsFailed}`)
      if(atemptsFailed === 3)
      {
        console.log(error)
      }
    }
  }
}

function createRandomPromise(){
  randomNumber = Math.random();
  return new Promise((resole, reject) => {
    if(randomNumber >= 0.7)
    {
      resole("Success!");
    }
    else{
      reject("Fail!");
    }
  })
}

retryPromise(createRandomPromise); 