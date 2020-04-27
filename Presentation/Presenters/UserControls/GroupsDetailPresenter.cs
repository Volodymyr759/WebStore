using System;
using Presentation.Views.UserControls;

namespace Presentation.Presenters.UserControls
{
    public class GroupsDetailPresenter : IGroupsDetailPresenter
    {
        public event EventHandler ReadyToShowGroupsDetailEventRaised;
        public event EventHandler CancelClickEventRaised;

        public IGroupsDetailUC GetGroupsDetailUC()
        {
            throw new NotImplementedException();
        }

        public void SetupGroupsDetailForAdd()
        {
            throw new NotImplementedException();
        }

        public void SetupGroupsDetailForEdit(int id)
        {
            throw new NotImplementedException();
        }
    }
}
