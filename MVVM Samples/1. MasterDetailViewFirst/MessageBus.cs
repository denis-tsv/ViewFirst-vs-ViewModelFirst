using System;
using Common;

namespace _1.MasterDetailViewFirst
{
public class UserChangedEventArgs : EventArgs
{
    public UserChangedEventArgs(User user)
    {
        User = user;
    }
    public User User { get; }
}

public class MessageBus
{
    public static MessageBus Instance = new MessageBus();

    public event EventHandler<UserChangedEventArgs> SelectedUserChanged;

    public void OnSelectedUserChanged(User user)
    {
        SelectedUserChanged?.Invoke(this, new UserChangedEventArgs(user));
    }
}
}
