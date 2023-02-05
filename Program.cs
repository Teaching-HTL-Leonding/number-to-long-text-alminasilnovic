string input;
int leftdigit = 0;
int leftdigithundred = 0;
int leftdigitthousand = 0;
int rightdigit = 0;
int rightdigithundred = 0;
int rightdigitthousand = 0;
string result = string.Empty;
do
{
    System.Console.Write("Enter a number: ");
    input = Console.ReadLine()!;
    if (input == "q")
    {
        return;
    }
    // int numberinput = int.Parse(input);
    // string result = DigitIntoLongText(numberinput);
    // System.Console.WriteLine(result);
    System.Console.WriteLine(NumberIntoLongText(int.Parse(input)));

} while (true);

string DigitIntoLongText(int number)
{
    switch (number)
    {
        case 0: return "zero";
        case 1: return "one";
        case 2: return "two";
        case 3: return "three";
        case 4: return "four";
        case 5: return "five";
        case 6: return "six";
        case 7: return "seven";
        case 8: return "eight";
        case 9: return "nine";
        default: return "not a digit";
    }
}

string NumberIntoLongText(int number)
{
    result = number.ToString();
    char minus = result[0];
    if (minus == '-')
    {
        number *= (-1);
    }
    if (number < 10)
    {
        result = DigitIntoLongText(number);
    }
    if (number > 9999)
    {
        return "not a valid number";
    }
    // int lastdigit = number - 10;
    if (number > 9 && number < 20)
    {
        switch (number)
        {
            case 10: result = "ten"; break;
            case 11: result = "eleven"; break;
            case 12: result = "twelve"; break;
            case 13: result = "thirteen"; break;
            case 15: result = "fifteen"; break;
            case 18: result = "eighteen"; break;
            default: result = $"{DigitIntoLongText(number - 10)}teen"; break;
        }
    }
    if (number > 19 && number < 100)
    {
        leftdigit = number / 10;
        rightdigit = number % 10;
        switch (leftdigit)
        {
            case 2: result = "twenty"; break;
            case 3: result = "thirty"; break;
            case 4: result = "forty"; break;
            case 5: result = "fifty"; break;
            case 8: result = "eighty"; break;
            default: result = $"{DigitIntoLongText(leftdigit)}ty"; break;
        }
        if (rightdigit != 0)
        {
            result += DigitIntoLongText(rightdigit);
        }
    }
    if (number > 99 && number < 1000)
    {
        leftdigithundred = number / 100;
        rightdigithundred = number % 100;
        if (rightdigithundred == 0)
        {
            result = $"{DigitIntoLongText(leftdigithundred)}hundred";
        }
        else
        switch (leftdigithundred)
        {
            default: result = $"{DigitIntoLongText(leftdigithundred)}hundred{NumberIntoLongText(rightdigithundred)}"; break;
        }
    }
    if (number > 999 && number < 10000)
    {
        leftdigitthousand = number / 1000; // 9000 = 9
        rightdigitthousand = number % 1000; // 9000 = 0
        if (rightdigitthousand == 0)
        {
            result = $"{DigitIntoLongText(leftdigitthousand)}thousand";
        }
        else
        switch (leftdigitthousand)
        {
            default: result = $"{DigitIntoLongText(leftdigitthousand)}thousand{NumberIntoLongText(rightdigitthousand)}"; break;
        }
    }
    if (minus == '-' && number != 0)
    {
        return $"minus{result}";
    }
    return result;
}