
using vCardManager;
namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test_IsValidEmail_SetToTrue_IfEmailIsValid()
    {
        var result = AddContacts.IsValidEmail("ndc.dev.code@gmail.com");
        Assert.True(result);
    }

    [Fact]
    public void Test_IsValidEmail_SetToTrue_IfEmailIsInvalid()
    {
        var result = AddContacts.IsValidEmail("HelloWorld");
        Assert.False(result);
    }

    [Fact]
    public void ToVcf_ShouldReturnFormattedVcfString()
    {
        var contact = new Contact("Stephan Martin", "martin.stephan9218@gmail.com", "+32479063186");
        string result = contact.ToVcf();
        string expected = "\nBEGIN:VCARD\nFN:Stephan Martin\nTEL:+32479063186\nEMAIL:martin.stephan9218@gmail.com\nEND:VCARD";
        Assert.Equal(expected, result);
    }
}
