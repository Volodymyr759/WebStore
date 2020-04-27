using System;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public interface IImagesUC
    {
        event EventHandler AddNewImageEventRaised;
        event EventHandler DeleteImageEventRaised;
        event EventHandler EditImageEventRaised;

        void SetupControls(BindingSource bindingSource);
    }
}