using NSubstitute;
namespace FirstContact.Tests.ContactServiceTests;

public class AddContactTests
{
    [Fact]
    public void PassesNameToRepository()
    {
        // Arrange
        IContactRepository repository = Substitute.For<IContactRepository>();
        ContactService service = new(repository);
        CreateContactRequest request = new() { Name = "Riyad" };

        // Act 
        service.AddContact(request);

        // Assert
        repository.Received(1).Add(Arg.Is<Contact>(c => c.Name == "Riyad"));
    }

    [Fact]
    public void ReturnsIdAndNameFromRepository()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.When(r => r.Add(Arg.Any<Contact>())).Do(Call => Call.Arg<Contact>().Id = 1);
        ContactService service = new(repository);
        CreateContactRequest request = new() { Name = "Riyad" };

        CreateContactResponse response = service.AddContact(request);

        Assert.Equal(1, response.Id);
        Assert.Equal("Riyad", response.Name);
    }
}