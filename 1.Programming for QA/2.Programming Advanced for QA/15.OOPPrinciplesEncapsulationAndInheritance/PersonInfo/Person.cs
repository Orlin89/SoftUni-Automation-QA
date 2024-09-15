using System;

namespace PersonInfo;

public class Person
{
    private string firstName;
    private string lastName;
    private int age;

    public string FirstName
    {
        get
        {
            return firstName;
        }
        set
        {
            if (value.Length < 3 )
            {
                throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
            }
            firstName = value;
        }
    }
    public string LastName
    {
        get
        {
            return lastName;
        }
        set
        {
            if ( value.Length < 3 )
            {
                throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
            }
            lastName = value;
        }
    }
    public int Age
    {
        get
        {
            return age;
        }
        set
        {
            if (value < 1)
            {
                throw new ArgumentException("Age cannot be zero or a negative integer!");
            }
            age = value;
        }
    }
    public Person (string firstName, string lastName, int age)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Age = age;
    }

    public override string ToString()
    {
        return $"{firstName} {lastName} is {age} years old.";
    }

}
