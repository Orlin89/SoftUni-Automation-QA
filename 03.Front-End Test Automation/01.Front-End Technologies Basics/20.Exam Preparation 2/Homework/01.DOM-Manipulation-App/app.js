window.addEventListener('load', solve);

function solve() {
    
    let carModelInput = document.getElementById('car-model');
    let carYearInput = document.getElementById('car-year');
    let partNameInput = document.getElementById('part-name');
    let partNumberInput = document.getElementById('part-number');
    let conditionInput = document.getElementById('condition');

    let carModelInfo = document.getElementById('info-car-model');
    let carYearInfo = document.getElementById('info-car-year');
    let partNameInfo = document.getElementById('info-part-name');
    let partNumberInfo = document.getElementById('info-part-number');
    let conditionInfo = document.getElementById('info-condition');

    let nextButton = document.getElementById('next-btn');
    nextButton.addEventListener('click', onNext);

    let partInfoElement = document.getElementById('part-info');

    let currentYear = new Date().getFullYear();

    let editButton = document.getElementById('edit-btn');
    editButton.addEventListener('click', onEdit);

    let confirmButton = document.getElementById('confirm-btn');
    confirmButton.addEventListener('click', onConfirm);

    let confirmOrderElement = document.getElementById('confirm-order');

    let newOrderButton = document.getElementById('new-btn');
    newOrderButton.addEventListener('click', newOrder);

    function onNext()
    {
       if(carModelInput.value == "" || carYearInput.value < 1990 || carYearInput.value > currentYear || partNameInput.value == "" || partNumberInput.value == "" || conditionInput.value == "")
       {
         return;
       }

       partInfoElement.style.display = 'block';
       nextButton.disabled = true;

       carModelInfo.textContent = carModelInput.value;
       carYearInfo.textContent = carYearInput.value;
       partNameInfo.textContent = partNameInput.value;
       partNumberInfo.textContent = partNumberInput.value;
       conditionInfo.textContent = conditionInput.value;

       carModelInput.value = "";
       carYearInput.value = "";
       partNameInput.value = "";
       partNumberInput.value = "";
       conditionInput.value = "";
    };

    function onEdit()
    {
        nextButton.disabled = false;

        carModelInput.value = carModelInfo.textContent;
        carYearInput.value = carYearInfo.textContent;
        partNameInput.value = partNameInfo.textContent;
        partNumberInput.value = partNumberInfo.textContent;
        conditionInput.value = conditionInfo.textContent;

        partInfoElement.style.display = 'none';
    };

    function onConfirm()
    {
        partInfoElement.style.display = 'none';
        confirmOrderElement.style.display = 'block';
    };

    function newOrder()
    {
        confirmOrderElement.style.display = 'none';
        nextButton.disabled = false;
    };
};


    
    
