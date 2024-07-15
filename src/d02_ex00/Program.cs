
try
{
    if (args.Length != 2)
    {
        throw new ArgumentException("Input error. Check the input data and repeat the request.");
    }

    var sum = args[0];
    var directory = args[1];

    if (!Directory.Exists(directory))
    {
        throw new ArgumentException("Input error. Check the input data and repeat the request.");
    }
    ExchangeSum.TryParse(sum, out var inputSum);

    Console.WriteLine($"Amount in the original currency: {inputSum}");
    Exchanger exchanger = new Exchanger(args[1]);
    foreach (var convertedSum in exchanger.Convert(inputSum))
    {
        Console.WriteLine($"Amount in {convertedSum.Currency}: {convertedSum:N2}");
    }

} catch (Exception e) {
    Console.WriteLine(e.Message);
}
