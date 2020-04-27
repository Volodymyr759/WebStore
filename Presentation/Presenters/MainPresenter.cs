using Common;
using System;
using System.Windows.Forms;

namespace Presentation
{
    public class MainPresenter : IMainPresenter
    {
        public event EventHandler TestEventRaised;
        IMainView mainView;
        IUnitsPresenter unitsPresenter;
        IUnitsDetailPresenter unitsDetailPresenter;
        //Panel _userControlPanel;
        //private IPlantListPresenter _plantListPresenter;
        //private INewsPresenter _newsPresenter;
        //private IDepartmentListPresenter _departmentListPresenter;
        //private IDepartmentDetailPresenter _departmentDetailPresenter;
        //private IHelpAboutPresenter _helpAboutPresenter;

        //private List<UserControl> userControList;

        Panel mainPanel;
        Panel rightPanel;
        //public void SetMainView(IMainView mainView) { _mainView = mainView; }

        public MainPresenter()
        {
        }

        public MainPresenter(IMainView mainView, IUnitsPresenter unitsPresenter, IUnitsDetailPresenter unitsDetailPresenter)
        {
            this.mainView = mainView;
            this.unitsPresenter = unitsPresenter;
            this.unitsDetailPresenter = unitsDetailPresenter;
            mainPanel = mainView.GetMainPanel();
            rightPanel = mainView.GetRightPanel();
            SubscribeToEventsSetup();
            //userControList = new List<UserControl>();
        }

        public IMainView GetMainView() => mainView;

        private void SubscribeToEventsSetup()
        {
            //mainView.TSMenuUnitsClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)unitsPresenter.GetUnitsUC());
            mainView.UnitsMenuClickEventRaised += (sender, e) => SetupMainView(mainPanel, (UserControl)unitsPresenter.GetUnitsUC());
            unitsDetailPresenter.ReadyToShowUnitsDetailEventRaised += (sender, e) => SetupMainView(rightPanel, (UserControl)unitsDetailPresenter.GetUnitsDetailUC());
            unitsDetailPresenter.CancelClickEventRaised += (object sender, EventArgs e) =>
            {
                rightPanel.Controls.Clear();
                rightPanel.Visible = false;
            };
        }

        private void SetupMainView(Panel targetPanel, UserControl userControl)
        {
            if (targetPanel.Name == "panelMain") mainPanel.Controls.Clear();
            rightPanel.Controls.Clear();
            rightPanel.Visible = (targetPanel.Name == "panelRight") ? true : false;
            targetPanel.Controls.Add(userControl);
            EventHelper.RaiseEvent(this, TestEventRaised, new EventArgs());
        }

        //private void OnCancelClickEventRaised(object sender, EventArgs e)
        //{
        //    rightPanel.Controls.Clear();
        //    rightPanel.Visible = false;
        //}
        //public void OnMainViewLoadedEventRaised(object sender, System.EventArgs e)
        //{
        //    //userControList = new List<UserControl>();
        //    //userControList.Add((UserControl)unitsPresenter.GetUnitsUC());
        //    //_userControList.Add((UserControl)_plantListPresenter.GetPlantListViewUC());
        //    //_userControList.Add((UserControl)_departmentListPresenter.GetDepartmentListViewUC());
        //    //_userControList.Add((UserControl)_departmentDetailPresenter.GetDepartmentDetailViewUC());

        //    //AssignUserControlToMainViewPanel((BaseUserControUC)_plantListPresenter.GetPlantListViewUC());
        //    //AssignUserControlToMainViewPanel((BaseUserControUC)_departmentListPresenter.GetDepartmentListViewUC());
        //    //AssignUserControlToMainViewPanel((BaseUserControUC)_newsPresenter.GetNewsViewUC());
        //    //AssignUserControlToMainViewPanel((BaseUserControUC)_departmentDetailPresenter.GetDepartmentDetailViewUC());
        //    //SetUserControlVisibleInPanel((UserControl)_newsPresenter.GetNewsViewUC());
        //    //_newsPresenter.LoadNewsPageIntoNewsView();
        //}

        //public void OnHelpAboutMenuClickEventRaised(object sender, EventArgs e)
        //{
        //    _helpAboutPresenter.GetHelpAboutView().ShowHelpAboutView();
        //}

        //public void OnDepartmentDetailSaveBtnClickEventRaised(object sender, AccessTypeEventArgs e)
        //{
        //    UpdateUserControlPanelForDepartmentDetailViewExit(e);
        //}

        //public void OnDepartmentDetailCancelBtnClickEventRaised(object sender, EventArgs e)
        //{
        //    _mainView.ResetUserControlPanelSizeandLocation();
        //    SetUserControlVisibleInPanel((UserControl)_departmentListPresenter.GetDepartmentListViewUC());
        //}

        //public void UpdateUserControlPanelForDepartmentDetailViewExit(AccessTypeEventArgs e)
        //{
        //    _mainView.ResetUserControlPanelSizeandLocation();
        //    SetupDepartmentListInPanel();
        //}

        //public void OnDepartmentDetailViewReadyToShowEventRaised(object sender, EventArgs e)
        //{
        //    SetUserControlVisibleInPanel((UserControl)_departmentDetailPresenter.GetDepartmentDetailViewUC());
        //    _mainView.ExpandUserControlPanel();
        //}

        //public void OnDisplayNewsBtnClickEventRaised(object sender, System.EventArgs e)
        //{
        //    SetupNewsPageInPanel();
        //}

        //public void OnPlantsListBtnClickEventRaised(object sender, System.EventArgs e)
        //{
        //    SetupPlantListInPanel();
        //}

        //private void SetupNewsPageInPanel()
        //{
        //    _newsPresenter.LoadNewsPageIntoNewsView();

        //    if (_newsPresenter.ContentIsLoadedInNewsView())
        //    {
        //        SetUserControlVisibleInPanel((UserControl)_newsPresenter.GetNewsViewUC());
        //    }
        //}

        //private void SetupPlantListInPanel()
        //{
        //    _plantListPresenter.LoadAllPlantsFromDbToGrid();
        //    SetUserControlVisibleInPanel((UserControl)_plantListPresenter.GetPlantListViewUC());
        //}

        //public void OnUpdateSelectedDepartmentInGridMenuClickEventRaised(object sender, EventArgs e)
        //{
        //    this._departmentListPresenter.OnUpdateSelectedDepartmentInGridMenuClickEventRaised(sender, e);
        //}

        //private void AssignUserControlToMainViewPanel(BaseUserControUC baseUserControl)
        //{
        //    baseUserControl.SetParentSizeLocationAnchor(mainPanel);
        //}

    }
}
