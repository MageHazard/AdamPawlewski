using System;
using InterfaceAdapters.Common;

namespace InterfaceAdapters.Menu.LoadingView
{
    public interface IInfoPopupView : IBaseView
    {
        void Setup(string infoText, string confirmButtonText, Action onConfirm);
    }
}