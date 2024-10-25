﻿using EffectiveMobile.DeliveryService.OrderFiltering.Domain;

namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Commands;

public class FilterOrdersByDistrictCommand(IOrderProvider orders) : ICommand<IEnumerable<Order>>
{
	private DistrictId _districtId;

	public void AddParameter(DistrictId districtId)
	{
		_districtId = districtId;
	}

	public IEnumerable<Order> Execute()
	{
		var sourceOrders = orders.GetOrders();
		var filteredOrders = ProduceFilteredOrders(_districtId, sourceOrders);
		return filteredOrders;
	}

	private static IEnumerable<Order> ProduceFilteredOrders(DistrictId districtId, IEnumerable<Order> source)
	{
		var filter = new DistrictIdOrderFilter(districtId);

		foreach (var order in source)
		{
			if (filter.ApplyFilter(order))
			{
				yield return order;
			}
		}
	}
}
