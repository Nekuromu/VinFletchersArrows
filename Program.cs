
while (true)
{
    ArrowHead headType = (ArrowHead)AskQuestion("Vin Fletcher: \"Ah you would like to order arrows? What head would you like?\" \n0- Steel\n1- Wood\n2- Obsidian", 0, 2);
    float arrowLength = AskQuestion($"Vin Fletcher: Ah yes, {headType} is a good choice. How many centimeters in length shall they be?", 45, 150);
    Fletching fletchingType = (Fletching)AskQuestion($"Vin Fletcher: Alright, {arrowLength} cm. What type of fletching would you like? \n0- Plastic\n1- Turkey Feathers\n2- Goose Feathers", 0, 2);
    int arrowAmount = AskQuestion($"Vin Fletcher: {fletchingType}, perfect. Lastly; How many of these are you wanting made? my maximum per order is 200.", 1, 200);

    Arrow customerArrow = new(headType, arrowLength, fletchingType);

    Console.WriteLine($"Alright, I'll make {arrowAmount} of them. That'll be {customerArrow.GetCost()} gold per arrow; or {(customerArrow.GetCost() * (float)arrowAmount):N0} gold.");
    Console.WriteLine("Press any key to pay the man... (restart)");
    Console.ReadKey();
    Console.Clear();
}

int AskQuestion(string questionText, int minRange, int maxRange)
{
    int pickedValue = minRange - 1;
    while (true)
    {
        Console.WriteLine(questionText);
        pickedValue = Convert.ToInt32(Console.ReadLine());

        if (pickedValue >= minRange && pickedValue <= maxRange) break;

        Console.WriteLine($"Invalid Input, please enter an integer between {minRange}-{maxRange}.");
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
    return Convert.ToInt32(pickedValue);
}

public class Arrow
{
    private ArrowHead _headType;
    private float _shaftLength;
    private Fletching _fletchingType;

    public Arrow()
    {
        _headType = ArrowHead.Steel;
        _shaftLength = 75;
        _fletchingType = Fletching.GooseFeathers;
    }

    public Arrow(ArrowHead headType, float shaftLength, Fletching fletchingType)
    {
        _headType = headType;
        _shaftLength = shaftLength;
        _fletchingType = fletchingType;
    }

    public float GetCost()
    {
        float cost = 0.0f;

        if (_headType == ArrowHead.Steel) cost += 10.0f;
        if (_headType == ArrowHead.Wood) cost += 3.0f;
        if (_headType == ArrowHead.Obsidian) cost += 5.0f;

        cost += _shaftLength * 0.05f;

        if (_fletchingType == Fletching.Plastic) cost += 10.0f;
        if (_fletchingType == Fletching.TurkeyFeathers) cost += 5.0f;
        if (_fletchingType == Fletching.GooseFeathers) cost += 3.0f;

        return cost;
    }
}

public enum ArrowHead { Steel, Wood, Obsidian }
public enum Fletching { Plastic, TurkeyFeathers, GooseFeathers }
