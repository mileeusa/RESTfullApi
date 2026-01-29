using SagaServiceImpl.Model;

namespace SagaServiceImpl.Services
{
    public class OrderSagaService
    {
        private readonly InventoryService _inventory;
        private readonly IPaymentService _payment;
        private readonly IShippingService _shipping;

        public OrderSagaService(InventoryService inventory, IPaymentService payment, IShippingService shipping)
        {
            _inventory = inventory;
            _payment = payment;
            _shipping = shipping;
        }

        public async Task<bool> ProcessOrderAsync(Order order)
        {
            try
            {
                if (!await _inventory.ReserveInventoryAsync(order))
                    throw new Exception("Inventory reservation failed");

                if (!await _payment.ProcessPaymentAsync(order))
                    throw new Exception("Payment failed");

                if (!await _shipping.ShipOrderAsync(order))
                    throw new Exception("Shipping failed");

                return true;
            }
            catch
            {
                await CompensateAsync(order);
                return false;
            }
        }

        private async Task CompensateAsync(Order order)
        {
            await _shipping.UndoShipOrderAsync(order);
            await _payment.UndoProcessPaymentAsync(order);
            await _inventory.UndoReserveInventoryAsync(order);
        }
    }
}
