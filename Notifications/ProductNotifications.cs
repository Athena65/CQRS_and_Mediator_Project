using CQRS_and_Mediator_Project.Models;
using MediatR;

namespace CQRS_and_Mediator_Project.Notifications
{
    public class ProductNotifications
    {
        public record ProductAddedNotification(Product Product):INotification; //same as irequest
    }
}
