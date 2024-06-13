using System.Globalization;

public class Exchanger {
	private Dictionary<string, ExchangeRate> rates = new Dictionary<string, ExchangeRate>();
	public Exchanger(string foldername) {
		var files = Directory.GetFiles(foldername, "*.txt");
		foreach (var file in files) {
			var from = Path.GetFileNameWithoutExtension(file);
			var lines = File.ReadAllLines(file);
			foreach (var line in lines) {
				var parts = line.Split(':');
				var to = parts[0];
				decimal.TryParse(parts[1], new CultureInfo("fr-Fr"), out var rate);
				ExchangeRate exchangeRate = new ExchangeRate { From = from, To = to, Rate = rate };
				rates.Add($"{from}-{to}", exchangeRate);
			}
		}
	}

	public IEnumerable<ExchangeSum> Convert(ExchangeSum sum)
	{
		foreach (var exchangeRate in rates.Values)
		{
			if (exchangeRate.From == sum.Currency)
			{
				Console.WriteLine(sum.Amount * exchangeRate.Rate);
				Console.WriteLine(exchangeRate.To);
				yield return new ExchangeSum
				{
					Amount = sum.Amount * exchangeRate.Rate,
					Currency = exchangeRate.To
				};
			}
		}
	}
}