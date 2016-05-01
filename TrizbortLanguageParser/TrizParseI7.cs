using System;
using System.Linq;
using System.Runtime.ExceptionServices;
using Sprache;
using TrizbortLanguageParser.TrizbortObjects;

namespace TrizbortLanguageParser
{
  public class TrizParseI7 : TrizParse
  {
    private static readonly Parser<string> quotedText =
      (from open in Parse.Char('"')
      from content in Parse.CharExcept('"').Many().Text()
      from close in Parse.Char('"')
      select content).Token();

    private static readonly Parser<string> Author = (
      from open in Parse.String("by").Once()
      from lquote in Parse.Char('"').Token().Optional()
      from author in Parse.CharExcept('"').Many().Text()
      from rquote in Parse.Char('"').Token().Optional()
      select author
      ).Token();

    private static readonly Parser<string> Title = (
      from title in quotedText
      select title).Token();

    private static readonly Parser<TrizHead> TrizHead =
      from title in Title.Text().Token()
      from author in Author.Text().Token()
      select new TrizHead() {Author=author, Title=title};

    private static readonly Parser<string> NewLine = Parse.String(Environment.NewLine).Text();

    public override TrizHead ParseSource(string input)
    {
      var head = parseHeader(input);

      return head;
    }

    private TrizHead parseHeader(string input)
    {
      var trizHead = new TrizHead();

      var s = TrizHead.Parse(input);
      trizHead.Title = s.Title.Trim();
      trizHead.Author = s.Author.Trim();
      return trizHead;
    }
  }
}