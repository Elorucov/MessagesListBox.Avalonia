# MessagesListBox

This repository contains an example of implementing a ListBox wrapper — MessagesListBox. This wrapper can:
* save the scroll position and restore it when switching chats;
* call methods for loading messages from the ViewModel, which implements IMessagesListHolder;
* restore the scroll position after loading previous messages (those that are inserted to the start of the list).

![Demo](https://github.com/Elorucov/MessagesListBox.Avalonia/raw/master/demo.gif)