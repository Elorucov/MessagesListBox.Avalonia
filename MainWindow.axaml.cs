using Avalonia.Controls;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using MessagesListBoxDemo.ViewModels;

namespace MessagesListBoxDemo;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new MainViewModel();
    }

    private void ChatChanged(object sender, System.EventArgs e)
    {
        ChatViewModel chat = (sender as Control).DataContext as ChatViewModel;
        if (chat == null) return;

        new System.Action(async () => await chat.OnDisplayedAsync())();
    }

    private void MessageChanged(object sender, System.EventArgs e)
    {
        Border root = sender as Border;
        MessageViewModel message = root.DataContext as MessageViewModel;
        if (message == null)
        {
            root.Child = null;
            return;
        }

        Border bubble = new Border
        {
            MaxWidth = 320,
            Padding = new Avalonia.Thickness(12),
            Background = new SolidColorBrush(Color.FromArgb(128, 128, 128, 128))
        };

        StackPanel items = new StackPanel
        {
            Spacing = 3,
        };

        items.Children.Add(new TextBlock
        {
            Text = message.SenderName,
            Foreground = new SolidColorBrush(Color.FromArgb(255, 0, 122, 204)),
            FontSize = 15,
            FontWeight = FontWeight.SemiBold
        });

        items.Children.Add(new TextBlock
        {
            Text = message.Text,
            FontSize = 16,
            TextWrapping = TextWrapping.Wrap
        });

        if (message.AttachmentHeight > 0) items.Children.Add(new Rectangle
        {
            Width = 240,
            Height = message.AttachmentHeight,
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            Fill = new SolidColorBrush(Color.FromArgb(255, 0, 119, 255))
        });

        bubble.Child = items;
        root.Child = bubble;
    }
}