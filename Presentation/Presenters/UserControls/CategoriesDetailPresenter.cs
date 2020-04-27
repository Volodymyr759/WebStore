using System;
using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    public class CategoriesDetailPresenter : ICategoriesDetailPresenter
    {
        public event EventHandler ReadyToShowCategoriesDetailEventRaised;
        public event EventHandler CancelClickEventRaised;

        public ICategoriesDetailUC GetCategoriesDetailUC()
        {
            throw new NotImplementedException();
        }

        public void SetupCategoriesDetailForAdd()
        {
            throw new NotImplementedException();
        }

        public void SetupCategoriesDetailForEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
