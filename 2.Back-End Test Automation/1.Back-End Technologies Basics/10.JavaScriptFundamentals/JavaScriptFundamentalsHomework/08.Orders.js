function order(product, quantity)
{
    result = 0;
    switch(product)
    {
      case "coffee":
        result = quantity * 1.50
        break;
      case "water":
        result = quantity * 1.00
        break;
      case "coke":
        result = quantity * 1.40
        break;
      case "snacks":
        result = quantity * 2.00
        break;
    }
    return result.toFixed(2)
}
