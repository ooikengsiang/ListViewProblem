using System.Collections.ObjectModel;
using System.Reactive.Linq;
using DynamicData;
using ReactiveUI;

namespace ListViewProblem;

public partial class MainPage : ContentPage
{
    public ReadOnlyObservableCollection<Message> Messages => _Messages;
    private readonly ReadOnlyObservableCollection<Message> _Messages;
    private readonly SourceList<Message> _MessagesSource = new();

    public MainPage()
	{
		InitializeComponent();

        _MessagesSource.Connect()
            .ObserveOn(RxApp.MainThreadScheduler)
            .Bind(out _Messages)
            .Subscribe();

        var rand = new Random();
        _MessagesSource.Edit(innerList =>
        {
            for (var i = 0; i < 100; ++i)
            {
                var isTrue = rand.Next() % 2 == 0;
                var newMessage = new Message()
                {
                    Title = i.ToString(),
                    Description = Guid.NewGuid().ToString(),
                    IsGreen = isTrue,
                    IsRed = !isTrue
                };
                innerList.Add(newMessage);
            }
        });

        MessagesListView.ItemsSource = Messages;
    }
}


