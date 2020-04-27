using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface IGroupsUC
    {
        event EventHandler AddNewGroupEventRaised;
        event EventHandler DeleteGroupEventRaised;
        event EventHandler EditGroupEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}