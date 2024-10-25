namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public readonly record struct OrderId(Guid Guid)
{
	public override string ToString()
	{
		return Guid.ToString();
	}

	public static OrderId Create()
	{
		return new OrderId
		{
			Guid = Guid.NewGuid(),
		};
	}
}
