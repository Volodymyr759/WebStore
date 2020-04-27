using System;
using System.Windows.Forms;

namespace Presentation
{
    public interface IMainView
    {
        event EventHandler UnitsMenuClickEventRaised;
        event EventHandler ImagesMenuClickEventRaised;
        event EventHandler ParametersMenuClickEventRaised;
        event EventHandler SuppliersMenuClickEventRaised;
        event EventHandler GroupsMenuClickEventRaised;
        event EventHandler CategoriesMenuClickEventRaised;
        event EventHandler ProductsMenuClickEventRaised;

        void ShowMainView();
        Panel GetMainPanel();
        Panel GetRightPanel();
    }
}
