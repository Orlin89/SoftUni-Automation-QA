function toggle() {
    let button = document.getElementsByClassName("button")[0];
    let hidenText = document.getElementById("extra");

    if(button.textContent == "More")
    {
        hidenText.style.display = "block"
        button.textContent = "Less"
    }
    else if(button.textContent == "Less")
    {
        hidenText.style.display = "none"
        button.textContent = "More"
    }
}