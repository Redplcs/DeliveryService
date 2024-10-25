namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure.Tests;

public class TextFileOrderProviderTests
{
	[Fact]
	public void GetOrders_FromSerializedOrderText_ReturnsArrayWithThreeItems()
	{
		var input = $@"
{OrderData.CreateSerializedOrder(out _, out _, out _, out _)}
{OrderData.CreateSerializedOrder(out _, out _, out _, out _)}
{OrderData.CreateSerializedOrder(out _, out _, out _, out _)}";
		var provider = new TextFileOrderProvider(input);

		var orders = provider.GetOrders();

		Assert.NotNull(orders);
		Assert.Equal(3, orders.Count);
	}
}
