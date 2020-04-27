using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface IParametersUC
    {
        event EventHandler AddNewParameterEventRaised;
        event EventHandler DeleteParameterEventRaised;
        event EventHandler EditParameterEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}