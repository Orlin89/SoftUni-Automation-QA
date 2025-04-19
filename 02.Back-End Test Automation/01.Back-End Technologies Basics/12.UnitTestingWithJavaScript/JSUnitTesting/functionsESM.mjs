export function add(a, b)
{
    return a+b;
}

export function substract(a, b){
    return a-b;
}

export function sum(arr) {
    let sum = 0;
    for (let num of arr){
        sum += Number(num);
    }
    return sum;
}
