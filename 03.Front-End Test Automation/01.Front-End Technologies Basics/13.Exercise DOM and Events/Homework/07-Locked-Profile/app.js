function lockedProfile() {
    let buttons = document.getElementsByTagName('button');

    for (const button of buttons) {
        button.addEventListener('click', showInfo)   
    }

    function showInfo(event)
    {
       let lockRadio = event.target.parentNode.children[2];
       let hiddenText = event.target.previousElementSibling;

       if(lockRadio.checked == false)
       {
          if(event.target.textContent == 'Hide it')
          {
            hiddenText.style.display = 'none'
            event.target.textContent = 'Show more'
          }
          else if(event.target.textContent == 'Show more')
          {
            hiddenText.style.display = 'block'
            event.target.textContent = 'Hide it'
          }
       }
    }
}