function addItem() {
    let text = document.getElementById('newItemText');
    let value = document.getElementById('newItemValue');
    
    let select = document.getElementById('menu');
    let option = document.createElement('option');

    option.textContent = text.value;
    option.value = value.value;    
    select.appendChild(option)

    text.value = '';
    value.value = '';
}