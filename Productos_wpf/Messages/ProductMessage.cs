using CommunityToolkit.Mvvm.Messaging.Messages;
using Productos_wpf.Models;
using Productos_wpf.ViewModel;

namespace Productos_wpf.Messages;

public class ProductMessage : ValueChangedMessage<(Product,ProductAction)>
{
    public ProductMessage((Product, ProductAction) value) : base(value)
    {
    }
}
