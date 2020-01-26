using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace InterfaceAdapters.Game.Actions.BuildAction
{
    public class BuildActionPresenter : BaseActionPresenter
    {
        public void ShowQuestionPopupWantToBuild()
        {
            _router.GetView<IQuestionPopupView>().Setup("Do you want to build this building?", "Yes", "No", WantToBuild, DontWantToBuild);
            _router.ShowView<IQuestionPopupView>();
        }

        private void WantToBuild()
        {
            _router.HideView<IQuestionPopupView>();
            // If Want to build
        }

        private void DontWantToBuild()
        {
            _router.HideView<IQuestionPopupView>();
            // Dont want to build
        }
        
        public void ShowInfoPopupAboutSuccessfullBuilding()
        {
            _router.GetView<IInfoPopupView>().Setup("Building success!", "Ok", ConfirmedSuccessfullBuilding);
            _router.ShowView<IInfoPopupView>();
        }

        private void ConfirmedSuccessfullBuilding()
        {
            _router.HideView<IInfoPopupView>();
            //Do something
        }
    }
}
