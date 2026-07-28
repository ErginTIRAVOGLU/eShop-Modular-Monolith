
namespace Catalog.Products.EventHandlers;

public class ProductCreatedEventHandler(ILogger<ProductCreatedEventHandler> logger)
    : INotificationHandler<ProductCreatedEvent>
{
    public Task Handle(ProductCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("Product created: {ProductId}", notification.Product.Id);
        return Task.CompletedTask;
    }
}

 