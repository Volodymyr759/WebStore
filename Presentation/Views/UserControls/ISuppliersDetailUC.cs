using Common;
using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    public interface ISuppliersDetailUC
    {
        event EventHandler CancelSuppliersDetailEventRaised;
        event EventHandler<DataEventArgs> SaveSuppliersDetailEventRaised;

        void ResetControls();
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}