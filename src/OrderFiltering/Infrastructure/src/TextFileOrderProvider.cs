using EffectiveMobile.DeliveryService.OrderFiltering.Domain;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure;

public class TextFileOrderProvider : IOrderProvider, IDisposable
{
	private readonly TextReader _reader;

	public TextFileOrderProvider(string input)
	{
		_reader = new StringReader(input);
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		((IDisposable)_reader).Dispose();
	}

	public IReadOnlyCollection<Order> GetOrders()
	{
		var orders = new List<Order>();

		for (string? line = string.Empty; line is not null; line = _reader.ReadLine())
		{
			if (TextOrderParser.TryParse(line, out var order))
			{
				orders.Add(order);
			}
		}

		return orders;
	}
}
