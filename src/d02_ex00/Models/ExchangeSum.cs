public struct ExchangeSum
{
    public decimal Amount { get; set; }
    public string Currency { get; set; }

    public override string ToString()
    {
        return ($"{Amount:N2} {Currency}");
    }
    
    static public bool TryParse(string input, out ExchangeSum exchange)
    {
        bool result = false;
        exchange = default;
        var tokens = input.Split(' ');
        if (tokens.Length == 2 && decimal.TryParse(tokens[0], out var amount) && tokens[1].Length == 3)
        {
            var currency = tokens[1];
            exchange = new ExchangeSum { Amount = amount, Currency = currency };
            result = true;
        }
        else
        {
            throw new ArgumentException("Input error. Check the input data and repeat the request.");
        }
        return result;
    }
}