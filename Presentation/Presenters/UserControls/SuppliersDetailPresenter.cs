using System;
using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    public class SuppliersDetailPresenter : ISuppliersDetailPresenter
    {
        public event EventHandler ReadyToShowSuppliersDetailEventRaised;
        public event EventHandler CancelClickEventRaised;

        public ISuppliersDetailUC GetSuppliersDetailUC()
        {
            throw new NotImplementedException();
        }

        public void SetupSuppliersDetailForAdd()
        {
            throw new NotImplementedException();
        }

        public void SetupSuppliersDetailForEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
