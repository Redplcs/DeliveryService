namespace EffectiveMobile.DeliveryService.OrderFiltering.Application.Commands;

public interface ICommand<TReturn>
{
	TReturn Execute();
}
