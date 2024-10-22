namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public readonly record struct AreaId(Guid Guid)
{
	public static AreaId Create()
	{
		return new AreaId
		{
			Guid = Guid.NewGuid(),
		};
	}
}
