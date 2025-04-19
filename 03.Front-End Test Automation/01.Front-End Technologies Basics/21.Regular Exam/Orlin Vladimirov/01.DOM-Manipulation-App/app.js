window.addEventListener("load", solve);

function solve() {
    
    let roomSizeInput = document.getElementById('room-size');
    let preferredTimeSlotInput = document.getElementById('time-slot');
    let fullNameInput = document.getElementById('full-name');
    let emailInput = document.getElementById('email');
    let phoneNumberInput =document.getElementById('phone-number');

    let roomSizePreview = document.getElementById('preview-room-size');
    let preferredTimeSlotPreview = document.getElementById('preview-time-slot');
    let fullNamePreview = document.getElementById('preview-full-name');
    let emailPreview = document.getElementById('preview-email');
    let phoneNumberPreview = document.getElementById('preview-phone-number');

    let bookRoomButton = document.getElementById('book-btn');
    bookRoomButton.addEventListener('click', onBook);

    let previewContainerElement = document.getElementById('preview');

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', onEdit);

    let confirmBookingButton = document.getElementById('confirm-btn');
    confirmBookingButton.addEventListener('click', onConfirm);

    let confirmationElement = document.getElementById('confirmation');

    let bookAnotherRoomButton = document.getElementById('back-btn');
    bookAnotherRoomButton.addEventListener('click', bookAnotherRoom);

    function onBook()
    {
       if(roomSizeInput.value == "" || preferredTimeSlotInput.value == "" || fullNameInput.value == "" || emailInput.value == "" || phoneNumberInput.value == "")
       {
         return;
       }

       previewContainerElement.style.display = 'block'

       roomSizePreview.textContent = roomSizeInput.value;
       preferredTimeSlotPreview.textContent = preferredTimeSlotInput.value;
       fullNamePreview.textContent = fullNameInput.value;
       emailPreview.textContent = emailInput.value;
       phoneNumberPreview.textContent = phoneNumberInput.value;

       bookRoomButton.disabled = true;

       roomSizeInput.value = "";
       preferredTimeSlotInput.value = "";
       fullNameInput.value = "";
       emailInput.value = "";
       phoneNumberInput.value = "";
    };

    function onEdit()
    {
        roomSizeInput.value = roomSizePreview.textContent;
        preferredTimeSlotInput.value = preferredTimeSlotPreview.textContent;
        fullNameInput.value = fullNamePreview.textContent;
        emailInput.value = emailPreview.textContent;
        phoneNumberInput.value = phoneNumberPreview.textContent;

        bookRoomButton.disabled = false;

        previewContainerElement.style.display = 'none';
    };

    function onConfirm()
    {
        previewContainerElement.style.display = 'none';

        confirmationElement.style.display = 'block';
    };

    function bookAnotherRoom()
    {
        confirmationElement.style.display = 'none';

        bookRoomButton.disabled = false;
    };
}
  