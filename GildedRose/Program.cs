using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;


namespace GildedRose
{
  public class Program
  {
    public IList<Item> Items;

    [ExcludeFromCodeCoverage]
    public static void Main(string[] args)
    {
      System.Console.WriteLine("OMGHAI!");

      var app = new Program()
      {
        Items = new List<Item>
                                          {
                new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 },
                new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new Item
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
    			// this conjured item does not work properly yet
    			new Item { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
                                          }

      };

      for (var i = 0; i < 31; i++)
      {
        Console.WriteLine("-------- day " + i + " --------");
        Console.WriteLine("name, sellIn, quality");
        for (var j = 0; j < app.Items.Count; j++)
        {
          Console.WriteLine(app.Items[j].Name + ", " + app.Items[j].SellIn + ", " + app.Items[j].Quality);
        }
        Console.WriteLine("");
        app.UpdateQuality();
      }
    }

    public void UpdateQuality()
    {
      for (var i = 0; i < Items.Count; i++)
      {
        var item = Items[i];
        switch (item.Name)
        {
          case "Aged Brie":
            if (item.Quality < 50)
            {
              item.Quality++;
              item.SellIn--;
            }
            break;
          case var someVal when new Regex(@"Sulfuras").IsMatch(someVal!):
            break;
          case var someVal when new Regex(@"Backstage").IsMatch(someVal!):

            if (item.SellIn < 1) item.Quality = 0;
            else if (item.SellIn < 6) item.Quality += 3;
            else if (item.SellIn < 11) item.Quality += 2;
            else item.Quality++;
            if (item.Quality > 50) item.Quality = 50;
            item.SellIn--;
            break;
          case var someVal when new Regex(@"Conjured").IsMatch(someVal!):
            if (item.SellIn < 1) item.Quality -= 4;
            else item.Quality -= 2;
            item.SellIn--;
            if (item.Quality < 0) item.Quality = 0;
            break;
          default:
            if (item.SellIn < 1) item.Quality -= 2;
            else item.Quality--;
            item.SellIn--;
            if (item.Quality < 0) item.Quality = 0;
            break;
        }
      }
    }
  }
}

public class Item
{
  public string Name { get; set; }

  public int SellIn { get; set; }

  public int Quality { get; set; }
}
