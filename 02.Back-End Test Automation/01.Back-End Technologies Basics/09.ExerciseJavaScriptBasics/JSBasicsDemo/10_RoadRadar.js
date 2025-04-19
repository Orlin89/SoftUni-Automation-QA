function roadRadar(input)
{
    const [speed, area] = input;
    let speedLimit;

    switch(area)
    {
        case 'motorway':
            speedLimit = 130;
            break;
        case 'interstate':
            speedLimit = 90;
            break;
        case 'city':
            speedLimit = 50;
            break;
        case 'residential':
            speedLimit = 20;
            break;
        default:
            console.log("invalid Area")
            return;
    }

    if(speed <= speedLimit)
    {
        console.log(`Driving ${speed} km/h in a ${speedLimit} zone`)
    }
    else{
        let difference = speed - speedLimit;
        let status;
        if(difference <= 20)
        {
            status = 'speeding';
        }
        else if(difference <= 40)
        {
            status = 'excessive speeding'
        }
        else 
        {
            status = 'reckless driving'
        }
        console.log(`The speed is ${difference} km/h faster than the allowed speed of ${speedLimit} - ${status}`)
    }
}

roadRadar([120, 'interstate'])