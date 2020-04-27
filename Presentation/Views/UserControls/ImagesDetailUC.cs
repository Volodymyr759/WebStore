using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class ImagesDetailUC : UserControl, IImagesDetailUC
    {
        public event EventHandler SaveImagesDetailEventRaised;
        public event EventHandler CancelImagesDetailEventRaised;

        public ImagesDetailUC()
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
