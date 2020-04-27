using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    public interface IImagesDetailUC
    {
        event EventHandler CancelImagesDetailEventRaised;
        event EventHandler SaveImagesDetailEventRaised;

        void ResetControls();
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}