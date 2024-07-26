using BookStoreMaui.Shared.Interfaces;

namespace BookStoreMaui.Mobile.Services
{
    internal class CommonService : ICommonService
    {
        public bool IsWeb => false;

        public bool IsMobile => true;
    }
}
