namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public readonly record struct OrderId(Guid Guid)
{
	public static OrderId Create()
	{
		return new OrderId
		{
			Guid = Guid.NewGuid(),
		};
	}
}
