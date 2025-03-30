using MessagesListBoxDemo.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesListBoxDemo.ViewModels
{
    public class ChatViewModel : BaseViewModel, IMessagesListHolder
    {
        private bool _openedFirstTime = false;

        private long _peerId;
        private string _title;
        private ObservableCollection<MessageViewModel> _messages = new ObservableCollection<MessageViewModel>();

        public event EventHandler<IMessageListItem> ScrollToMessageRequested;

        public long PeerId { get { return _peerId; } private set { _peerId = value; OnPropertyChanged(); } }
        public string Title { get { return _title; } private set { _title = value; OnPropertyChanged(); } }
        public ObservableCollection<MessageViewModel> Messages { get { return _messages; } private set { _messages = value; OnPropertyChanged(); } }

        public long Id => PeerId;

        public int LastReadMessageId { get; private set; }

        public ChatViewModel()
        {

        }

        public override string ToString()
        {
            return Title;
        }

        public async Task OnDisplayedAsync()
        {
            if (_openedFirstTime) return;
            _openedFirstTime = true;

            await Task.Delay(1000); // loading imitation

            var msgs = MessageViewModel.GetSamples();
            LastReadMessageId = msgs[msgs.Count / 2].Id;
            var lastReadMessage = msgs.SingleOrDefault(m => m.Id == LastReadMessageId);
            Messages = new ObservableCollection<MessageViewModel>(msgs);
            ScrollToMessageRequested?.Invoke(this, lastReadMessage);
        }

        public async Task LoadPreviousAsync(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(2000, cancellationToken); // loading imitation
                if (cancellationToken.IsCancellationRequested) return;

                var msgs = MessageViewModel.GetPreviousSamples();
                int i = 0;
                foreach (var msg in CollectionsMarshal.AsSpan(msgs))
                {
                    Messages.Insert(i, msg);
                    i++;
                }
            }
            catch (TaskCanceledException) { }
        }

        public async Task LoadNextAsync(CancellationToken cancellationToken)
        {
            try
            {
                await Task.Delay(2000, cancellationToken); // loading imitation
                if (cancellationToken.IsCancellationRequested) return;

                var msgs = MessageViewModel.GetNextSamples();
                foreach (var msg in CollectionsMarshal.AsSpan(msgs))
                {
                    Messages.Add(msg);
                }
            }
            catch (TaskCanceledException) { }
        }


        public static List<ChatViewModel> GetSamples()
        {
            return new List<ChatViewModel> {
                new ChatViewModel {
                    PeerId = 777,
                    Title = "User 777"
                },
                new ChatViewModel {
                    PeerId = -777,
                    Title = "Group 777"
                },
                new ChatViewModel {
                    PeerId = 2000000777,
                    Title = "Chat 777"
                },
            };
        }
    }
}
