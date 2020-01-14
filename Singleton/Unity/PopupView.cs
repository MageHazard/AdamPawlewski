using System;
using DG.Tweening;
using MemoryGame.Common;
using UnityEngine;

namespace View
{
    public class PopupView : BaseView
    {
        public static PopupView Instance { get; private set; }

        private CanvasGroup _unlockedCharacterPopup;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
            } 
            else {
                Instance = this;
            }
            
            PrepareReferences();
            HideViewImmediately(_unlockedCharacterPopup);
        }

        public void ShowUnlockedCharacterPopup()
        {
            var sequence = DOTween.Sequence();
            sequence.Append(_unlockedCharacterPopup.DOFade(1, UIProperties.AnimationDuration));
            sequence.AppendInterval(2);
            sequence.Append(_unlockedCharacterPopup.DOFade(0, UIProperties.AnimationDuration));
        }

        private void PrepareReferences()
        {
            _unlockedCharacterPopup = transform.Find("UnlockedCharacterPopup").GetComponent<CanvasGroup>();
        }
    }
}
