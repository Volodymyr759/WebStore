using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface IProductsUC
    {
        event EventHandler AddNewProductEventRaised;
        event EventHandler DeleteProductEventRaised;
        event EventHandler EditProductEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}