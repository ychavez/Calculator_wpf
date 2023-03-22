using CommunityToolkit.Mvvm.Messaging.Messages;
using Productos_wpf.ViewModel;

namespace Productos_wpf.Messages
{
    public class ProductActionMessage : ValueChangedMessage<ProductAction>
    {
        public ProductActionMessage(ProductAction value) : base(value)
        {
        }
    }
}
