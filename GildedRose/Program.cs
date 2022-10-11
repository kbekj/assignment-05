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
                new AgedBrie { Name = "Aged Brie", SellIn = 2, Quality = 0 },
                new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 },
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 },
                new Sulfuras { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 },
                new BackstagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 15,
                    Quality = 20
                },
                new BackstagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 10,
                    Quality = 49
                },
                new BackstagePass
                {
                    Name = "Backstage passes to a TAFKAL80ETC concert",
                    SellIn = 5,
                    Quality = 49
                },
    			// this conjured item does not work properly yet
    			new Conjured { Name = "Conjured Mana Cake", SellIn = 3, Quality = 6 }
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
        app.UpdateAll();
      }
    }

    public void UpdateAll()
    {
      for (var i = 0; i < Items.Count; i++)
      {
        var item = Items[i];
        item.UpdateQuality();
      }
    }
  }
}

public class Item
{
  public string Name { get; set; }

  public int SellIn { get; set; }

  public int Quality { get; set; }

  public virtual void UpdateQuality() {
    if (this.SellIn < 1) this.Quality -= 2;
    else this.Quality--;
    this.SellIn--;
    if (this.Quality < 0) this.Quality = 0;
  }
}

public class AgedBrie : Item 
{
  public override void UpdateQuality() {
      if (this.Quality < 50)
            {
              this.Quality++;
              this.SellIn--;
            }
  }
}

public class Sulfuras : Item 
{
  public override void UpdateQuality() {
    return;
  }
}

public class BackstagePass : Item 
{
  public override void UpdateQuality() {
    if (this.SellIn < 1) this.Quality = 0;
    else if (this.SellIn < 6) this.Quality += 3;
    else if (this.SellIn < 11) this.Quality += 2;
    else this.Quality++;
    if (this.Quality > 50) this.Quality = 50;
    this.SellIn--;
  }
}

public class Conjured : Item 
{
  public override void UpdateQuality() {
    if (this.SellIn < 1) this.Quality -= 4;
    else this.Quality -= 2;
    this.SellIn--;
    if (this.Quality < 0) this.Quality = 0;
  }
}