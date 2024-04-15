namespace Tests;

using Bl;
using Dal;

[TestFixture]
public class Dev
{

    [Test]
    public void Test1()
    {
        var bl = new PersonsBl(new PersonsDal(TestUtils.ConnectionString));
        var person = bl.GetBy(2);
        Assert.Pass();
    }
}
