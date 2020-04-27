using Common;
using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    public interface IUnitsDetailUC
    {
        event EventHandler CancelUnitsDetailEventRaised;
        event EventHandler<DataEventArgs> SaveUnitsDetailEventRaised;

        void ResetControls();
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}