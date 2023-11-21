using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

public class BrazilianFormatter
{
  public static string Format(string txt)
  {
    var _conditions = ConditionsAndFormats();
    
    var _conditionsToCompare = _conditions.Where(wh => wh.Item1 == txt.Length)
                                         .Select(s => s.Item2)
                                         .ToList();
    
    if (!_conditionsToCompare.Any())
        return "The phone number is not identified";
    
    var _conditionToCompare = _conditionsToCompare.FirstOrDefault(wh => 
        wh._condition != null ? txt.Substring(wh._condition._index, wh._condition._lenght) == wh._condition._value : true);
    
    if (_conditionToCompare == null)
        return "The phone number is not identified";
    
    return long.Parse(txt).ToString($"{_conditionToCompare._format}");
  }

  private static List<Tuple<int, Filter>> ConditionsAndFormats()
  {
      return new List<Tuple<int, Filter>>    //tamanho da string, formatação
      {
          new Tuple<int, Filter>(3, new Filter("SUP: 000") ),
          new Tuple<int, Filter>(4, new Filter("ETM: 0000") ),
          new Tuple<int, Filter>(5, new Filter("ETF: 000+00", new Condition { _index = 0, _lenght = 3, _value = "103"}) ),              
          new Tuple<int, Filter>(5, new Filter("ETV: 00000", new Condition { _index = 0, _lenght = 3, _value = "106"}) ),               
          new Tuple<int, Filter>(8, new Filter("RES: 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "3"}) ),           
          new Tuple<int, Filter>(8, new Filter("MOB: 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "8"}) ),           
          new Tuple<int, Filter>(8, new Filter("MOB: 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "9"}) ),           
          new Tuple<int, Filter>(9, new Filter("MOB: 0 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "9"}) ),         
          new Tuple<int, Filter>(10, new Filter("MOB: (00) 0000-0000", new Condition { _index = 2, _lenght = 1, _value = "8"}) ),     
          new Tuple<int, Filter>(10, new Filter("MOB: (00) 0000-0000", new Condition { _index = 2, _lenght = 1, _value = "9"}) ),     
          new Tuple<int, Filter>(10, new Filter("RES: (00) 0000-0000", new Condition { _index = 2, _lenght = 1, _value = "3"}) ),     
          new Tuple<int, Filter>(11, new Filter("MOB: (00) 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "0"}) ),     
          new Tuple<int, Filter>(11, new Filter("MOB: (00) 0 0000-0000", new Condition { _index = 2, _lenght = 1, _value = "9"}) ),   
          new Tuple<int, Filter>(12, new Filter("MOB: (00) 0 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "0"}) ),   
          new Tuple<int, Filter>(12, new Filter("MOB: +00 (00) 0000-0000", new Condition { _index = 0, _lenght = 1, _value = "5"}) ),
          new Tuple<int, Filter>(13, new Filter("MOB: +00 (00) 0 0000-0000") )
      };
  }

  public class Filter
  {
      public string _format { get; set; }
      public Condition _condition { get; set; }

      public Filter(string format, Condition condition = null)
      {
          _format = format;
          _condition = condition;
      }
  }

  public class Condition 
  {
      public int _index { get; set; }
      public int _lenght { get; set; }
      public string _value { get; set; }
      public string[] _equals { get; set; }
      public string[] _different { get; set; }
  }
}
