using Library.Application.Models;
using MediatR;

namespace Library.Application.Notifications.BookCreated;

internal class UsersNotificationHandler : INotificationHandler<BookCreatedNotification>
{
    public Task Handle(BookCreatedNotification notification, CancellationToken cancellationToken)
    {
        Console.WriteLine($"Novo livro cadastrado! - ${notification.Title}");

        return Task.CompletedTask;
    }
}
