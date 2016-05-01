using NUnit.Framework;
using TrizbortLanguageParser;

namespace Test_TLP
{
  [TestFixture]
  public class TrizParseI7_Test
  {
    [Test]
    public void SimpleTitleString()
    {
      var parse = new TrizParseI7();
      var xx = parse.ParseSource(@" ""This is a test string""  by Jason Lautzenheiser  ");

      Assert.That(xx.Author, Is.EqualTo("Jason Lautzenheiser"));
      Assert.That(xx.Title, Is.EqualTo("This is a test string"));

    }

    [Test]
    public void AuthorInQuotes()
    {
      var parse = new TrizParseI7();
      var xx = parse.ParseSource(@" ""This is a test string""  by ""Jason Lautzenheiser""  ");

      Assert.That(xx.Author, Is.EqualTo("Jason Lautzenheiser"));
      Assert.That(xx.Title, Is.EqualTo("This is a test string"));

    }
  }
}