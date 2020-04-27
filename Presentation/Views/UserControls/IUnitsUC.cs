using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface IUnitsUC
    {
        event EventHandler AddNewUnitEventRaised;
        event EventHandler DeleteUnitEventRaised;
        event EventHandler EditUnitEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}