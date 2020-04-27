using System;

namespace Presentation
{
    public interface IDeleteConfirmView
    {
        event EventHandler DeleteConfirmViewOKEventRaised;

        int GetIdToDelete();
        void ShowDeleteConfirmMessageView(string windowTitle, string deleteConfirmMessage, int idToDelete);
    }
}