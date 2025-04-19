function printVacationPrice(arr)
{
    let price;
    let totalPrice;
    let groupNumber = parseInt(arr[0]);
    let groupType = arr[1];
    let weekDay = arr[arr.length - 1];

    if(groupType === 'Students')
    {
        if(weekDay === 'Friday')
        {
            price = 8.45;
        }
        else if(weekDay === 'Saturday')
        {
            price = 9.80;
        }
        else if(weekDay === 'Sunday')
        {
            price = 10.46;
        }
    }
    else if(groupType === 'Business')
    {
        price = (weekDay === 'Friday') ? 10.90 : 
        (weekDay === 'Saturday') ? 15.60 : 
        (weekDay === 'Sunday') ? 16 : 0;
    }
    else if(groupType === 'Regular')
    {
        if(weekDay === 'Friday')
            {
                price = 15;
            } 
        else if(weekDay === 'Saturday')
        {
            price = 20;
        }
        else if(weekDay === 'Sunday')
        {
            price = 22.50;
        }
    }

    totalPrice = price * groupNumber;

    if(groupType === 'Students' && groupNumber >= 30)
    {
        totalPrice *= 0.85;
    }
    else if(groupType === 'Business' && groupNumber >= 100)
    {
        totalPrice = (groupNumber - 10) * price;
    }
    else if(groupType === 'Regular' && groupNumber >= 10 && groupNumber <= 20)
    {
        totalPrice *= 0.95;
    }

    console.log(`Total price: ${totalPrice.toFixed(2)}`);
}

printVacationPrice([40, "Regular", "Saturday"]);