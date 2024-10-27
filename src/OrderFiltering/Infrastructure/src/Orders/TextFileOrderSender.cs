using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Text;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Orders;

public class TextFileOrderSender : IOrderSender, IDisposable
{
	private readonly TextWriter _writer;

	public TextFileOrderSender(FileStream stream)
	{
		_writer = new StreamWriter(stream);
	}

	public TextFileOrderSender(StringBuilder stringBuilder)
	{
		_writer = new StringWriter(stringBuilder);
	}

	public void Dispose()
	{
		GC.SuppressFinalize(this);
		((IDisposable)_writer).Dispose();
	}

	public async Task Send(IEnumerable<Order> orders)
	{
		foreach (var order in orders)
		{
			var serialized = Serialize(order);
			await _writer.WriteLineAsync(serialized);
		}
	}

	private static string Serialize(Order order)
	{
		return string.Format("{0},{1},{2},{3:yyyy-MM-dd HH:mm:ss}", order.Id, order.Weight, order.DeliveryDistrictId, order.DeliveryTime);
	}
}
