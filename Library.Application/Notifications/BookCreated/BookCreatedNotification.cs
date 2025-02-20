
using MediatR;

namespace Library.Application.Notifications.BookCreated
{
    public class BookCreatedNotification : INotification
    {
        public string Title { get; set; }

        public BookCreatedNotification(string title)
        {
            Title = title;
        }
    }
}
