using MessagesListBoxDemo.Controls;
using System;
using System.Collections.Generic;

namespace MessagesListBoxDemo.ViewModels
{
    public class MessageViewModel : BaseViewModel, IMessageListItem
    {
        private static readonly string[] _names = new string[] { "Alice", "Bob", "Lena", "Zidane" };
        private static readonly double[] _attahcments = new double[] { 0, 72, 144, 400 };
        private static readonly string[] _texts = new string[] {
            "The quick brown fox jumps over the lazy dog",
            "This is because dotnet/reactive has adopted ImmutableArray (or its equivalent) for Subject, which results in the allocation of a new array every time one is added or removed. Depending on the design of the application, a large number of subscriptions can occur (we have seen this especially in the complexity of games), which can be a critical issue. In R3, we have devised a way to achieve high performance while avoiding ImmutableArray.",
            "Our goal is delivering a polished, professionally designed and user-friendly app.",
            "There are a few debug menus that are only found in the demo versions, which allow the player to select a handful of options such as the levels, characters, and number of players during the gameplay.",
        };

        private static readonly Random _rnd = new Random();

        private static int _firstId = 500001;
        private static int _lastId = 500050;

        private int _id;
        private string _senderName;
        private string _text;
        private double _attachmentHeight;

        public int Id { get { return _id; } private set { _id = value; OnPropertyChanged(); } }
        public string SenderName { get { return _senderName; } private set { _senderName = value; OnPropertyChanged(); } }
        public string Text { get { return _text; } private set { _text = value; OnPropertyChanged(); } }
        public double AttachmentHeight { get { return _attachmentHeight; } private set { _attachmentHeight = value; OnPropertyChanged(); } }

        public static List<MessageViewModel> GetSamples()
        {
            List<MessageViewModel> messages = new List<MessageViewModel>() { Capacity = _lastId - _firstId };

            for (int i = _firstId; i <= _lastId; i++)
            {
                messages.Add(GetSample(i));
            }

            return messages;
        }

        public static List<MessageViewModel> GetPreviousSamples()
        {
            List<MessageViewModel> messages = new List<MessageViewModel>() { Capacity = 50 };

            for (int i = 50; i > 0; i--)
            {
                _firstId--;
                messages.Insert(0, GetSample(_firstId));
            }

            return messages;
        }

        public static List<MessageViewModel> GetNextSamples()
        {
            List<MessageViewModel> messages = new List<MessageViewModel>() { Capacity = 50 };

            for (int i = 0; i <= 50; i++)
            {
                _lastId++;
                messages.Add(GetSample(_lastId));
            }

            return messages;
        }

        private static MessageViewModel GetSample(int id)
        {
            return new MessageViewModel
            {
                Id = id,
                SenderName = $"{id} {_names[_rnd.Next(0, 3)]}",
                Text = _texts[_rnd.Next(0, 3)],
                AttachmentHeight = _attahcments[_rnd.Next(0, 3)]
            };
        }
    }
}
