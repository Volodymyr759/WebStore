using System;
using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    public class ParametersDetailPresenter : IParametersDetailPresenter
    {
        public event EventHandler ReadyToShowParametersDetailEventRaised;
        public event EventHandler CancelClickEventRaised;

        public IParametersDetailUC GetParametersDetailUC()
        {
            throw new NotImplementedException();
        }

        public void SetupParametersDetailForAdd()
        {
            throw new NotImplementedException();
        }

        public void SetupParametersDetailForEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
