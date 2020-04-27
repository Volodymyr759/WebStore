using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface ISuppliersUC
    {
        event EventHandler AddNewSupplierEventRaised;
        event EventHandler DeleteSupplierEventRaised;
        event EventHandler EditSupplierEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}