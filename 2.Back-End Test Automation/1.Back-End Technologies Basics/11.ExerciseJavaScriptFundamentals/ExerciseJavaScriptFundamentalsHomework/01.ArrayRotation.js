function arrayRotation(array, numberOfRotations)
{
    let effectiveRotation = numberOfRotations % array.length;

    let rotatedArray = array.slice(effectiveRotation).concat(array.slice(0, effectiveRotation));
    
    console.log(rotatedArray.join(' '));
}
