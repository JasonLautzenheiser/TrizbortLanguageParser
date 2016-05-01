using NUnit.Framework;
using TrizbortLanguageParser;
using TrizbortLanguageParser.TrizbortObjects;

namespace Test_TLP
{
  [TestFixture]
  public class TrizParse_Test
  {
    [Test]
    public void CallBaseTrizParseFunctionReturnsEmptyTrizHead()
    {
      var parse = new TrizParseI7();
      var xx = parse.ParseSource("test");

      Assert.That(xx.Author, Is.EqualTo(string.Empty));
      Assert.That(xx.Title, Is.EqualTo(string.Empty));
    }
  }
}