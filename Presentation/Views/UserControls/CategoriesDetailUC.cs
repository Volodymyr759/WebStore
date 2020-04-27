using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class CategoriesDetailUC : UserControl, ICategoriesDetailUC
    {
        public event EventHandler SaveProductsDetailEventRaised;

        public event EventHandler CancelProductsDetailEventRaised;

        public CategoriesDetailUC()
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
