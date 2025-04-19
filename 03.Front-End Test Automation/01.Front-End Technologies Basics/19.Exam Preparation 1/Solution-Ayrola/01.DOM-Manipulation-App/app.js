window.addEventListener("load", solve);

function solve() {
    let numberOfTicketsInput = document.getElementById('num-tickets');
    let seetingPreferenceInput = document.getElementById('seating-preference');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById("email");
    let phoneNumberInput = document.getElementById("phone-number");

    let purchaseTicketsNumber = document.getElementById("purchase-num-tickets");
    let purchaseSeatingPreference = document.getElementById("purchase-seating-preference");
    let purcahseFullName = document.getElementById("purchase-full-name");
    let purchaseEmail = document.getElementById("purchase-email");
    let purchasePhoneNumber = document.getElementById("purchase-phone-number");

    let tricketPreviewElement = document.getElementById("ticket-preview");

    let purchaseTicketsButton = document.getElementById("purchase-btn");

    purchaseTicketsButton.addEventListener("click", previewTickets)

    function previewTickets()
    {
        var test = numberOfTicketsInput.value;
        
        if(Number(numberOfTicketsInput.value) < 1 || seetingPreferenceInput.value == "seating-preference" || !fullNameInput.value || emailInput.value == "" || phoneNumberInput.value == "")
        {
            return;
        }

        //Display the ticket info in the hidden element
        tricketPreviewElement.style.display = "block";

        purchaseTicketsNumber.textContent = numberOfTicketsInput.value;
        purchaseSeatingPreference.textContent = seetingPreferenceInput.value;
        purcahseFullName.textContent = fullNameInput.value;
        purchaseEmail.textContent = emailInput.value;
        purchasePhoneNumber.textContent = phoneNumberInput.value;

        //diasble purcahse ticket button
        purchaseTicketsButton.disabled = true;

        //clear the input fields
        numberOfTicketsInput.value = "";
        seetingPreferenceInput.value = "seating-preference";
        fullNameInput.value = "";
        emailInput.value = "";
        phoneNumberInput.value = "";
    }

    let editButton = document.getElementById("edit-btn");

    editButton.addEventListener("click", onEdit)

    function onEdit()
    {
        numberOfTicketsInput.value = purchaseTicketsNumber.textContent;
        seetingPreferenceInput.value = purchaseSeatingPreference.textContent;
        fullNameInput.value = purcahseFullName.textContent;
        emailInput.value = purchaseEmail.textContent;
        phoneNumberInput.value = purchasePhoneNumber.textContent;

        purchaseTicketsButton.disabled = false;

        tricketPreviewElement.style.display = "none";
    }

    let buyButton = document.getElementById("buy-btn");

    buyButton.addEventListener("click", onBuy)

    let purchaseSuccessElement = document.getElementById("purchase-success");

    function onBuy(){
        tricketPreviewElement.style.display = "none";

        purchaseSuccessElement.style.display = "block"; 
    }

    let backButton = document.getElementById("back-btn");
    backButton.addEventListener("click", onBack)

    function onBack(){
        purchaseSuccessElement.style.display = "none";

        purchaseTicketsButton.disabled = false;
    }
}