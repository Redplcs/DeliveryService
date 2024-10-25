namespace EffectiveMobile.DeliveryService.OrderFiltering.Domain;

public readonly record struct DistrictId(Guid Guid)
{
	public override string ToString()
	{
		return Guid.ToString();
	}

	public static DistrictId Create()
	{
		return new DistrictId
		{
			Guid = Guid.NewGuid(),
		};
	}
}
