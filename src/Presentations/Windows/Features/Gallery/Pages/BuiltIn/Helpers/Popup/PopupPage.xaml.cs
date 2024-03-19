namespace MAUIsland;
public partial class PopupPage : IGalleryPage
{
    #region [CTor]
    public PopupPage(PopupPageViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;
    }
    #endregion

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Sample Popup Alert", "You have been alerted", "OK");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        bool answer = await DisplayAlert("Question?", "Would you like to play a game", "Yes","No");
        await DisplayAlert("Answer",$"Answer is {( answer ? "yes" : "no")}" , "OK");
    }

    private async void Button_Clicked_2(object sender, EventArgs e)
    {
        string answer = await DisplayActionSheet("What game do you wanna play?", "Cancel", null, "LOL", "Halo", "Dota2");
        if (answer != "Cancel")
        {
            await DisplayAlert("Answer", $"{answer} is great!", "OK");
        }
    }

    private async void Button_Clicked_3(object sender, EventArgs e)
    {
        string answer = await DisplayPromptAsync("Hello", "What's your name?",placeholder: "Type your name");
        if (answer != null) 
        {
            await DisplayAlert("Welcome", $"Hello, {answer}","Cancel");
        }
    }
}