using System;
using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    public class ImagesDetailPresenter : IImagesDetailPresenter
    {
        public event EventHandler ReadyToShowImagesDetailEventRaised;
        public event EventHandler CancelClickEventRaised;

        public IImagesDetailUC GetImagesDetailUC()
        {
            throw new NotImplementedException();
        }

        public void SetupImagesDetailForAdd()
        {
            throw new NotImplementedException();
        }

        public void SetupImagesDetailForEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
