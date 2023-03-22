using CommunityToolkit.Mvvm.Messaging.Messages;
using Productos_wpf.Models;
using Productos_wpf.ViewModel;

namespace Productos_wpf.Messages
{/// <summary>
/// Esta clase es la estructura del mensaje que enviaremos desde la lista de productos
/// hasta la vista de detalle de producto
/// consta de un producto y una accion
/// </summary>
    public class ProductMessage : ValueChangedMessage<(Product, ProductAction)>
    {
        public ProductMessage((Product, ProductAction) value) : base(value)
        {
        }
    }
}
