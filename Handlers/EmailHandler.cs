using CQRS_and_Mediator_Project.Models;
using MediatR;
using static CQRS_and_Mediator_Project.Notifications.ProductNotifications;

namespace CQRS_and_Mediator_Project.Handlers
{
    public class EmailHandler:INotificationHandler<ProductAddedNotification>
    {
        private readonly FakeDataStore _fakeDataStore;

        public EmailHandler(FakeDataStore fakeDataStore)
        {
            _fakeDataStore = fakeDataStore;
        }

        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fakeDataStore.EvenOccured(notification.Product, " Email sent");
            await Task.CompletedTask;
        }
    }
}
