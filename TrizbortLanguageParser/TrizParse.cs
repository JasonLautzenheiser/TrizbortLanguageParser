using TrizbortLanguageParser.TrizbortObjects;

namespace TrizbortLanguageParser
{
  public abstract class TrizParse
  {
    public virtual TrizHead ParseSource(string input)
    {
      return new TrizHead();
    }
  }
}