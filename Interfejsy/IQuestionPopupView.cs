using System;
using InterfaceAdapters.Common;

namespace InterfaceAdapters.Menu.LoadingView
{
    public interface IQuestionPopupView : IBaseView
    {
        void Setup(string infoText, string confirmButtonText, string cancelButtonText, Action onConfirm,
            Action onCancel);
    }
}