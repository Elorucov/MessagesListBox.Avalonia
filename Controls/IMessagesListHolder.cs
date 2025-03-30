using System;
using System.Threading;
using System.Threading.Tasks;

namespace MessagesListBoxDemo.Controls
{
    public interface IMessagesListHolder
    {
        long Id { get; }
        event EventHandler<IMessageListItem> ScrollToMessageRequested;

        Task LoadPreviousAsync(CancellationToken cancellationToken);
        Task LoadNextAsync(CancellationToken cancellationToken);
    }
}
