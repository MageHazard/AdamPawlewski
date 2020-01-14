using System;
using TMPro;
using InterfaceAdapters.Common;
using InterfaceAdapters.Menu.LoadingView;
using UnityEngine.UI;

namespace Frameworks.View.Common
{
    public class InfoPopupView : BaseView, IInfoPopupView
    {
        private TextMeshProUGUI _infoText;
        private TextMeshProUGUI _confirmButtonText;
        private Button _confirmButton;

        public override IController Controller { get; set; }

        public void Setup(string infoText, string confirmButtonText, Action onConfirm)
        {
            _infoText.text = infoText;
            _confirmButtonText.text = confirmButtonText;
            _confirmButton.onClick.AddListener(() => onConfirm());
        }

        #region Helpers

        protected override void PrepareReferences()
        {
            base.PrepareReferences();
            _infoText = transform.Find("SafeArea/Popup/InfoText").GetComponent<TextMeshProUGUI>();
            _confirmButtonText = transform.Find("SafeArea/Popup/ConfirmButton/Text").GetComponent<TextMeshProUGUI>();
            _confirmButton = transform.Find("SafeArea/Popup/ConfirmButton").GetComponent<Button>();
        }

        #endregion
    }
}
