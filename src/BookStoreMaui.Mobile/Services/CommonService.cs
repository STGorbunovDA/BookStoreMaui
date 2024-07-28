using BookStoreMaui.Shared.Interfaces;

namespace BookStoreMaui.Mobile.Services
{
    internal class CommonService : ICommonService
    {
        private readonly AppState _appState;

        public CommonService(AppState appState) => _appState = appState;

        public bool IsWeb => false;

        public bool IsMobile => true;

        public void ShowLoader(string loaderMessage) => _appState.ShowLoader(loaderMessage);
        public void HideLoader() => _appState.HideLoader();
    }
}
