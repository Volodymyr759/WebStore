using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface ICategoriesUC
    {
        event EventHandler AddNewCategoryEventRaised;
        event EventHandler DeleteCategoryEventRaised;
        event EventHandler EditCategoryEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}