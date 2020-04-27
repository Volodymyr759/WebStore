using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    public interface IParametersDetailUC
    {
        event EventHandler CancelParametersDetailEventRaised;
        event EventHandler SaveParametersDetailEventRaised;

        void ResetControls();
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}