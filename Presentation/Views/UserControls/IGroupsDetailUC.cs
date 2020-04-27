using System;
using System.Collections.Generic;

namespace Presentation.Views.UserControls
{
    public interface IGroupsDetailUC
    {
        event EventHandler CancelProductsDetailEventRaised;
        event EventHandler SaveProductsDetailEventRaised;

        void ResetControls();
        void SetupControls(Dictionary<string, string> modelDictionary);
    }
}