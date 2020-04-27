namespace Presentation
{
    public class BasePresenter : IErrorPresenter
    {
        public IErrorMessageView _errorMessageView;

        public BasePresenter()
        {

        }
        public BasePresenter(IErrorMessageView errorMessageView)
        {
            _errorMessageView = errorMessageView;
        }

        public void ShowErrorMessage(string windowTitle, string errorMessage)
        {
            _errorMessageView.ShowErrorMessageView(windowTitle, errorMessage);
        }
    }
}
