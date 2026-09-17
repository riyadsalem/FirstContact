using NSubstitute;
namespace FirstContact.Tests.ContactServiceTests;

public class SearchTests
{
    [Fact]
    public void PassesSearchTermToRepository()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        // MME: incorrect setup
        repository.GetAll().Returns([]);
        ContactService service = new(repository);

        service.Search("Riyad");

        repository.Received(1).Search("Riyad");
    }

    [Fact]
    public void MapsFoundContactsToResponse()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.Search("r").Returns(
        [
            new Contact ("Riyad") {Id = 1},
            new Contact ("Mark") {Id = 2}
        ]);
        ContactService service = new(repository);

        List<SearchContactResponse> result = service.Search("r");

        // MME: Check Ids as well
        Assert.Equal(2, result.Count);
        Assert.Equal("Riyad", result[0].Name);
        Assert.Equal("Mark", result[1].Name);
    }

    [Fact]
    public void ReturnsEmptyList_WhenNothingFound()
    {
        IContactRepository repository = Substitute.For<IContactRepository>();
        repository.Search(Arg.Any<string>()).Returns([]);
        ContactService service = new(repository);

        List<SearchContactResponse> result = service.Search("Riyad");

        Assert.Empty(result);
    }
}