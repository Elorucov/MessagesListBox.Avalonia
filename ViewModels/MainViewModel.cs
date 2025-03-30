using System.Collections.ObjectModel;

namespace MessagesListBoxDemo.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        private ObservableCollection<ChatViewModel> _chats;
        private ChatViewModel _selectedChat;

        public ObservableCollection<ChatViewModel> Chats { get { return _chats; } set { _chats = value; OnPropertyChanged(); } }
        public ChatViewModel SelectedChat { get { return _selectedChat; } set { _selectedChat = value; OnPropertyChanged(); } }

        public MainViewModel()
        {
            var chats = ChatViewModel.GetSamples();
            Chats = new ObservableCollection<ChatViewModel>(chats);
        }
    }
}
