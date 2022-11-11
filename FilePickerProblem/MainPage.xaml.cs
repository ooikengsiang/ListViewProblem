namespace FilePickerProblem;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}

	private async void OnPickFileButtonClicked(object sender, EventArgs e)
	{
        var filePath = "Nothing";

        try
        {
            var pickOptions = new PickOptions();
            var result = await FilePicker.Default.PickAsync(pickOptions);
            if (result != null)
            {
                filePath = result.FullPath;
            }
            else
            {
                filePath = "No result";
            }
        }
        catch (Exception ex)
        {
            // user canceled or something went wrong
            filePath = $"Exception: {ex.Message}";
        }

        FilePathEntry.Text = filePath;
    }
}


