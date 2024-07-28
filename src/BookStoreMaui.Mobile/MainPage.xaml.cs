namespace BookStoreMaui.Mobile
{
    public partial class MainPage : ContentPage
    {
        public MainPage(AppState appState)
        {
            InitializeComponent();
            BindingContext = appState;
        }
    }
}
