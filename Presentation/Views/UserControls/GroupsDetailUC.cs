using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Presentation.Views.UserControls
{
    public partial class GroupsDetailUC : UserControl, IGroupsDetailUC
    {
        public event EventHandler SaveProductsDetailEventRaised;

        public event EventHandler CancelProductsDetailEventRaised;

        public GroupsDetailUC()
        {
            InitializeComponent();
        }

        public void SetupControls(Dictionary<string, string> modelDictionary)
        {

        }

        public void ResetControls()
        {
            throw new NotImplementedException();
        }
    }
}
