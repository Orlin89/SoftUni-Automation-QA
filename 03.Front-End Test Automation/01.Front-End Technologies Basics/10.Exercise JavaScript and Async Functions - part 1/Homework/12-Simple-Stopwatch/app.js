let elapsedTime = 0;
let stopwatchInterval;
let saveTimeInterval;

function startStopWatch() {

    console.log("Stopwatch Started");

    stopwatchInterval = setInterval(() => {
        elapsedTime++;
        console.log(`Elapsed time ${elapsedTime} seconds`)
    }, 1000);

    saveTimeInterval = setInterval(async() => {
        await saveElapsedTime(elapsedTime);
    }, 5000);

}

function stopStopWatch() {
    clearInterval(stopwatchInterval);
    clearInterval(saveTimeInterval);
    saveTimeInterval = null;
    stopwatchInterval = null; 
    elapsedTime = 0;
    console.log("Stopwatch Stopped")
}

function saveElapsedTime(time){
    return new Promise((resolve, reject) => {
        setTimeout(() => {
            console.log(`Elapsed time saved: ${time}`)
            resolve();
        }, 500);
    })
}