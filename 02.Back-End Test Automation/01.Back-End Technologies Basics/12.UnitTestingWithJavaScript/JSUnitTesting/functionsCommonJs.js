module.exports.add = function(a, b){
    return a + b;
}

module.exports.substract = function(a, b){
    return a-b;
}

function sum(arr) {
    let sum = 0;
    for (let num of arr){
        sum += Number(num);
    }
    return sum;
}
module.exports = { sum };
