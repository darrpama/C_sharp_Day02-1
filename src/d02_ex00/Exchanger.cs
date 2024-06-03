using System.Globalization;

public class Exchanger {
	private Dictionary<string, ExchangeRate> rates = new Dictionary<string, ExchangeRate>();
	public Exchanger(string foldername) {
		var files = Directory.GetFiles(foldername, "*.txt");
		foreach (var file in files) {
			var from = Path.GetFileNameWithoutExtension(file);
			var lines = file.ReadAllLines(file);
			foreach (var line in lines) {
				var parts = line.split(':');
				var to = parts[0];
				decimal.TryParse(parts[1], new CultureInfo("en-GB"), out var rate);
				ExchangeRate exchangeRate = new ExchangeRate { From = from, To = to, Rate = rate };
				rates.add($"{from}-{to}", exchangeRate);
			}
		}
	}
}