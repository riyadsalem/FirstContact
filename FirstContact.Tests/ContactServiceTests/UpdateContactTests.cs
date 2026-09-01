using NSubstitute;
namespace FirstContact.Tests.ContactServiceTests;

public class UpdateContactTests
{
    [Fact]
    public void UpdatesNameCommitsAndReturnsTrue_WhenContactExists()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        Contact contact = new("Old Name") { Id = 1 };
        repository.GetById(1).Returns(contact);
        ContactService service = new(repository);
        UpdateContactRequest request = new() { Name = "New Name" };

        bool result = service.UpdateContact(1, request);

        Assert.True(result);
        Assert.Equal("New Name", contact.Name);
        repository.Received(1).Commit();
    }

    [Fact]
    public void ReturnsFalseAndDoesNotCommit_WhenContactMissing()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        ContactService service = new(repository);
        UpdateContactRequest request = new() { Name = "New Name" };

        bool result = service.UpdateContact(1, request);

        Assert.False(result);
        repository.DidNotReceive().Commit();
    }
}