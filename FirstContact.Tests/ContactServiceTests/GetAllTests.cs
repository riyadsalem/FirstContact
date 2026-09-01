using NSubstitute;
namespace FirstContact.Tests.ContactServiceTests;

public class GetAllTests
{
    [Fact]
    public void MapsContactsToResponse()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.GetAll().Returns(
        [
            new Contact ("Riyad") {Id = 1},
            new Contact ("Mark") {Id = 2}
        ]);
        ContactService service = new(repository);

        List<GetAllContactResponse> result = service.GetAll();

        Assert.Equal(2, result.Count);
        Assert.Equal("Riyad", result[0].Name);
        Assert.Equal("Mark", result[1].Name);
    }

    [Fact]
    public void ReturnsEmptyList_WhenRepositoryIsEmpty()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.GetAll().Returns([]);
        ContactService service = new(repository);

        List<GetAllContactResponse> result = service.GetAll();

        Assert.Empty(result);
    }
}