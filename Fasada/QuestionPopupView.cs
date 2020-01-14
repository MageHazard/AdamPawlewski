using System;
using TMPro;
using InterfaceAdapters.Common;
using InterfaceAdapters.Menu.LoadingView;
using UnityEngine.UI;

namespace Frameworks.View.Common
{
    public class QuestionPopupView : BaseView, IQuestionPopupView
    {
        private TextMeshProUGUI _questionText;
        private TextMeshProUGUI _confirmButtonText;
        private TextMeshProUGUI _cancelButtonText;
        private Button _confirmButton;
        private Button _cancelButton;

        public override IController Controller { get; set; }

        public void Setup(string infoText, string confirmButtonText, string cancelButtonText, Action onConfirm, Action onCancel)
        {
            _questionText.text = infoText;
            _confirmButtonText.text = confirmButtonText;
            _confirmButton.onClick.AddListener(() => onConfirm());
            _cancelButtonText.text = cancelButtonText;
            _cancelButton.onClick.AddListener(() => onCancel());
        }

        #region Helpers

        protected override void PrepareReferences()
        {
            base.PrepareReferences();
            _questionText = transform.Find("SafeArea/Popup/QuestionText").GetComponent<TextMeshProUGUI>();
            _confirmButtonText = transform.Find("SafeArea/Popup/ConfirmButton/Text").GetComponent<TextMeshProUGUI>();
            _confirmButton = transform.Find("SafeArea/Popup/ConfirmButton").GetComponent<Button>();
            _cancelButtonText = transform.Find("SafeArea/Popup/CancelButton/Text").GetComponent<TextMeshProUGUI>();
            _cancelButton = transform.Find("SafeArea/Popup/CancelButton").GetComponent<Button>();
        }

        #endregion
    }
}
