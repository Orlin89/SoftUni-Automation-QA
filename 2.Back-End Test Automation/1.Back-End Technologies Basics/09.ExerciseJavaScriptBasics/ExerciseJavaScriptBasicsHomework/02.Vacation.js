function vacation(arr) 
{
    let numberOfPeople = parseInt(arr[0]);
    let groupType = arr[1];
    let weekDay = arr[2];
    let price = 0;


    if (weekDay === 'Friday') 
    {
        if (groupType === 'Students') 
        {
            price = 8.45;
            if (numberOfPeople >= 30) 
            {
                price *= 0.85;
            }
        }
        else if(groupType === 'Business')
        {
            price = 10.90;
            if(numberOfPeople >= 100)
            {
               numberOfPeople -= 10;
            }
        }
        else if(groupType === 'Regular')
        {
            price = 15.00;
            if(numberOfPeople >= 10 && numberOfPeople <= 20)
            {
                price *= 0.95;
            }
        }
    }
    else if (weekDay === 'Saturday') 
    {
        if (groupType === 'Students') 
            {
                price = 9.80;
                if (numberOfPeople >= 30) 
                {
                    price *= 0.85;
                }
            }
            else if(groupType === 'Business')
            {
                price = 15.60;
                if(numberOfPeople >= 100)
                {
                   numberOfPeople -= 10;
                }
            }
            else if(groupType === 'Regular')
            {
                price = 20.00;
                if(numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    price *= 0.95;
                }
            }
    }
    else if (weekDay === 'Sunday')
    {
        if (groupType === 'Students') 
            {
                price = 10.46;
                if (numberOfPeople >= 30) 
                {
                    price *= 0.85;
                }
            }
            else if(groupType === 'Business')
            {
                price = 16.00;
                if(numberOfPeople >= 100)
                {
                   numberOfPeople -= 10.00;
                }
            }
            else if(groupType === 'Regular')
            {
                price = 22.50;
                if(numberOfPeople >= 10 && numberOfPeople <= 20)
                {
                    price *= 0.95;
                }               
            }  
    }
    console.log(`Total price: ${(price * numberOfPeople).toFixed(2)}`)
}
