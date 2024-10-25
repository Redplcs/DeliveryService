using EffectiveMobile.DeliveryService.OrderFiltering.Domain;
using System.Globalization;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Infrastructure;

public class TextOrderParser
{
	public static Order Parse(string input)
	{
		const string deliveryTimeFormat = "yyyy-MM-dd HH:mm:ss";

		var properties = input.Split(',');

		if (properties.Length != 4)
			throw new InvalidDataException("The number of properties is not equals to 4");

		var orderGuid = Guid.Parse(properties[0], CultureInfo.InvariantCulture);
		var weight = float.Parse(properties[1], CultureInfo.InvariantCulture);
		var deliveryDistrictGuid = Guid.Parse(properties[2], CultureInfo.InvariantCulture);
		var deliveryTime = DateTime.ParseExact(properties[3], deliveryTimeFormat, CultureInfo.InvariantCulture);

		return Order.Create(new OrderId(orderGuid), weight, new DistrictId(deliveryDistrictGuid), deliveryTime);
	}
}
