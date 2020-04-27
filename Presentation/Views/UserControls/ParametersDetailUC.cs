using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ParametersDetailUC : UserControl, IParametersDetailUC
    {
        public event EventHandler SaveParametersDetailEventRaised;
        public event EventHandler CancelParametersDetailEventRaised;

        public ParametersDetailUC()
        {
            InitializeComponent();
        }

        public void ResetControls()
        {

        }

        public void SetupControls(Dictionary<string, string> modelDictionary)
        {

        }
    }
}
