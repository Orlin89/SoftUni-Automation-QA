function sortNumbers(array) 
{
    let sortedArray = [];
    array.sort((a, b) => a - b); // Sort the array in ascending order

    while (array.length > 0) 
    {
        sortedArray.push(array.shift()); // Get the smallest element
        if (array.length > 0) 
        {
            sortedArray.push(array.pop()); // Get the largest element
        }
    }
    
    return sortedArray;
}










//  75/100 in judge
function sortNumbers2(array)
{
    let sortedArray =[];
    
    if(array.length % 2 === 0)
    {
        while(array.length > 0)
        {
            let maxNumber = Number.MIN_SAFE_INTEGER;
            let minNumber = Number.MAX_SAFE_INTEGER;
            for(let i = 0; i < array.length; i ++)
            {
                if(maxNumber < array[i] )
                {
                 maxNumber = array[i]
                }
                if(minNumber > array[i])
                {
                 minNumber = array[i]
                }
            }
            sortedArray.push(minNumber);
            sortedArray.push(maxNumber);
            for(let j = 0; j < array.length; j ++)
            {
                if(array[j] === minNumber)
                {
                 array.splice(j, 1)            
                }           
            }
            for(let k = 0; k < array.length; k ++)
                {             
                if(array[k] === maxNumber)
                {
                 array.splice(k, 1)
                }  
            }
        }
    }
    else
    {
        while(array.length > 0)
        {
            let maxNumber = Number.MIN_SAFE_INTEGER;
            let minNumber = Number.MAX_SAFE_INTEGER;
            for(let i = 0; i < array.length; i ++)
            {                   
                if(maxNumber < array[i] )
                {
                 maxNumber = array[i]
                }
                if(minNumber > array[i])
                {
                 minNumber = array[i]
                }
            }
            if(array.length >= 2)
            {
              sortedArray.push(minNumber);
              sortedArray.push(maxNumber);
            }
            else
            {
                sortedArray.push(array[0])
            }
            
            for(let j = 0; j < array.length; j ++)
            {
               if(array[j] === minNumber)
                {
                 array.splice(j, 1)            
                }           
            }
            for(let k = 0; k < array.length; k ++)
            {             
                if(array[k] === maxNumber)
                {
                 array.splice(k, 1)
                }  
            }
        }
    }   
    return sortedArray;  
}
console.log(sortNumbers([1, 65, 3, 52, 48, 63, 31, -3, 18, 56]))
