function attachEventsListeners() {
    let inputDays = document.getElementById("days")
    let inputHours = document.getElementById("hours")
    let inputMinutes = document.getElementById("minutes")
    let inputSeconds = document.getElementById("seconds")

    document.querySelector("main").addEventListener("click", onConvert)

    let ratios = {
       days: 1,
       hours: 24,
       minutes: 1440,
       seconds: 86400
    }

    function onConvert(event)
    {
       if(event.target.type == "button")
       {
         let input = event.target.parenElement.querySelector("input[type='text']");  // let input = event.target.parentNode.children[1]

         let inputInDays = Number(input.value / ratios[input.id]);

         let hoursToDisplay = inputInDays * ratios.hours;
         let minutesToDisplay = inputInDays * ratios.minutes;
         let secondToDisplay = inputInDays * ratios.seconds;

         inputDays.value = inputInDays;
         inputHours.value = hoursToDisplay;
         inputMinutes.value = minutesToDisplay;
         inputSeconds.value = secondToDisplay; 
       }
    }
}

