using EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Services.Filters;

namespace EffectiveMobile.DeliveryService.OrderFiltering.ApplicationCore.Tests.Services.Filters;

public abstract class OrderFilterTestsBase<TFilter> where TFilter : IOrderFilter
{
	[Fact]
	public void ApplyFilter_WhenOrderIsNull_ReturnsFalse()
	{
		// Arrange
		var filter = CreateFilter();

		// Act
		var filtered = filter.ApplyFilter(order: null!);

		// Assert
		Assert.False(filtered);
	}

	protected abstract TFilter CreateFilter();
}
