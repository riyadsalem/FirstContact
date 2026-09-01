using NSubstitute;
namespace FirstContact.Tests.ContactServiceTests;

public class DeleteContactTests
{
    [Fact]
    public void PassesIdToRepository()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.Delete(Arg.Any<int>()).Returns(true);
        ContactService service = new(repository);

        service.DeleteContact(5);

        repository.Received(1).Delete(5);
    }

    [Fact]
    public void ReturnsTrue_WhenRepositoryDeletes()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.Delete(5).Returns(true);
        ContactService service = new(repository);

        bool result = service.DeleteContact(5);

        Assert.True(result);
    }

    [Fact]
    public void ReturnsFalse_WhenRepositoryFails()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.Delete(5).Returns(false);
        ContactService service = new(repository);

        bool result = service.DeleteContact(5);

        Assert.False(result);
    }
}