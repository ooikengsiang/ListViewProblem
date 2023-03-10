using ReactiveUI;

namespace ListViewProblem;

public class Message : ReactiveObject
{
    public string Title
    {
        get => _Title;
        set => this.RaiseAndSetIfChanged(ref _Title, value);
    }
    private string _Title = string.Empty;

    public string Description
    {
        get => _Description;
        set => this.RaiseAndSetIfChanged(ref _Description, value);
    }
    private string _Description = string.Empty;

    public bool IsGreen
    {
        get => _IsGreen;
        set => this.RaiseAndSetIfChanged(ref _IsGreen, value);
    }
    private bool _IsGreen;

    public bool IsRed
    {
        get => _IsRed;
        set => this.RaiseAndSetIfChanged(ref _IsRed, value);
    }
    private bool _IsRed;

    public Message()
    {
    }
}

