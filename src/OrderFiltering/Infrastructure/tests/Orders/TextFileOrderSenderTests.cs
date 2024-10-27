using EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Orders;
using System.Text;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests.Orders;

public class TextFileOrderSenderTests
{
	[Fact]
	public async void Send()
	{
		var expectedString = OrderData.CreateSerializedOrder(out var order) + Environment.NewLine;
		var stringBuilder = new StringBuilder();
		var sender = new TextFileOrderSender(stringBuilder);

		await sender.Send([order]);

		var actualString = stringBuilder.ToString();
		Assert.Equal(expectedString, actualString);
	}
}
