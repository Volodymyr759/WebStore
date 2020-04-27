using System;
using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    public class ProductsDetailPresenter : IProductsDetailPresenter
    {
        public event EventHandler ReadyToShowProductsDetailEventRaised;
        public event EventHandler CancelClickEventRaised;

        public IProductsDetailUC GetProductsDetailUC()
        {
            throw new NotImplementedException();
        }

        public void SetupProductsDetailForAdd()
        {
            throw new NotImplementedException();
        }

        public void SetupProductsDetailForEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
