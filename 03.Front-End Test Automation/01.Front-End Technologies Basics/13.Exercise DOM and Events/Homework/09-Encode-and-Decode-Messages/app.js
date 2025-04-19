function encodeAndDecodeMessages() {
    let encodeAndSendButton = document.getElementsByTagName('button')[0];
    let decodeAndReadButton = document.getElementsByTagName('button')[1];
    let textAreaEncode = document.getElementsByTagName('textarea')[0];
    let textAreaDecode = document.getElementsByTagName('textarea')[1];

    let isDecoded = false; // Флаг за декодиране

    encodeAndSendButton.addEventListener('click', sendAndEncode);
    decodeAndReadButton.addEventListener('click', decodeAndRead);

    function nextChar(c)
    {
        return String.fromCharCode(c.charCodeAt(0) + 1);
    }

    function previousChar(c)
    {
        return String.fromCharCode(c.charCodeAt(0) - 1);
    }

    function transform(text, fn)
    {
        return text.split('').map(fn).join('');
    }

    function sendAndEncode()
    {
        let valueToEncode = textAreaEncode.value;
        let encodedValue = transform(valueToEncode, nextChar);
        textAreaDecode.value = encodedValue;
        textAreaEncode.value = '';
        isDecoded = false; // Нулираме флага при ново съобщение
    }
    
    function decodeAndRead() {   
        if (!isDecoded) {
            textAreaDecode.value = transform(textAreaDecode.value, previousChar);
            isDecoded = true; // След декодиране задаваме флага на true
        }
    }
}