window.addEventListener("load", solve);

function solve() {
    
    let numberOfTicketsInput = document.getElementById('num-tickets');
    let seatingPreferenceInput = document.getElementById('seating-preference');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput = document.getElementById('phone-number');

    let numberOfTicketsPreview = document.getElementById('purchase-num-tickets');
    let seatingPreferencePreview = document.getElementById('purchase-seating-preference');
    let fullNamePreview = document.getElementById('purchase-full-name');
    let emailPreview = document.getElementById('purchase-email');
    let phoneNumberPreview = document.getElementById('purchase-phone-number');

    let purchaseTicketsButton = document.getElementById('purchase-btn');
    purchaseTicketsButton.addEventListener('click', onPurchase);

    let ticketPreviewForm = document.getElementById('ticket-preview');

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', onEdit);

    let buyButton = document.getElementById('buy-btn');
    buyButton.addEventListener('click', onBuy);

    let purchaseSuccessElemen =document.getElementById('purchase-success');

    let backButton = document.getElementById('back-btn');
    backButton.addEventListener('click', onBack);

    function onPurchase()
    {
       if(numberOfTicketsInput.value == '' || seatingPreferenceInput.value == 'seating-preference' || fullNameInput.value == '' || emailInput.value == '' || phoneNumberInput.value == '')
       {
          return;
       };

       ticketPreviewForm.style.display = 'block';

       numberOfTicketsPreview.textContent = numberOfTicketsInput.value;
       seatingPreferencePreview.textContent = seatingPreferenceInput.value;
       fullNamePreview.textContent = fullNameInput.value;
       emailPreview.textContent = emailInput.value;
       phoneNumberPreview.textContent = phoneNumberInput.value;
   
       purchaseTicketsButton.disabled = true; 
       
       numberOfTicketsInput.value = '';
       seatingPreferenceInput.value = 'seating-preference';
       fullNameInput.value = '';
       emailInput.value = '';
       phoneNumberInput.value = '';
    };

    function onEdit()
    {
        numberOfTicketsInput.value = numberOfTicketsPreview.textContent;
        seatingPreferenceInput.value = seatingPreferencePreview.textContent;
        fullNameInput.value = fullNamePreview.textContent;
        emailInput.value = emailPreview.textContent;
        phoneNumberInput.value = phoneNumberPreview.textContent;

        purchaseTicketsButton.disabled = false;

        ticketPreviewForm.style.display = 'none';
    };

    function onBuy()
    {
        ticketPreviewForm.style.display ='none';
        purchaseSuccessElemen.style.display = 'block';
    };

    function onBack()
    {
        purchaseSuccessElemen.style.display = 'none';
        purchaseTicketsButton.disabled = false;
    };

}