using BookStoreMaui.Shared.Interfaces;

namespace BookStoreMaui.Web.Services
{
    public class CommonService : ICommonService
    {
        public bool IsWeb => true;

        public bool IsMobile => false;
    }
}
