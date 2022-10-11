namespace GildedRose.Tests;

public class ProgramTests
{
  private readonly Program program;

  public ProgramTests()
  {
    program = new GildedRose.Program();
    program.Items = new List<Item> { };

  }

  [Fact]
  public void TestTheTruth()
  {
    true.Should().BeTrue();
  }

  [Fact]
  public void DexterityVest_quality_doesnt_drop_below_0()
  {
    program.Items.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
    for (int i = 0; i < 30; i++) program.UpdateQuality();
    program.Items[0].Quality.Should().Be(0);
  }

  [Fact]
  public void Conjured_quality_decreases_by_2()
  {
    program.Items.Add(new Item { Name = "Conjured item", SellIn = 10, Quality = 20 });
    program.UpdateQuality();
    program.Items[0].Quality.Should().Be(18);
  }

  [Fact]
  public void Conjured_quality_doesnt_drop_below_0()
  {
    program.Items.Add(new Item { Name = "Conjured item", SellIn = 10, Quality = 20 });
    for (int i = 0; i < 30; i++) program.UpdateQuality();
    program.Items[0].Quality.Should().Be(0);
  }
  [Fact]
  public void DexterityVest_quality_decreases_by_1()
  {
    program.Items.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
    program.UpdateQuality();
    program.Items[0].Quality.Should().Be(19);
  }

  [Fact]
  public void DexterityVest_quality_decreases_by_2()
  {
    program.Items.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
    for (int i = 0; i < 11; i++) program.UpdateQuality();
    program.Items[0].Quality.Should().Be(8);
  }

  [Fact]
  public void AgedBrie_quality_Increases_by_1()
  {
    program.Items.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
    program.UpdateQuality();
    program.Items[0].Quality.Should().Be(1);
  }
  [Fact]
  public void AgedBrie_quality_dont_Increase_above_50()
  {
    program.Items.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
    for (int i = 0; i < 60; i++) program.UpdateQuality();
    program.Items[0].Quality.Should().Be(50);
  }

  [Fact]
  public void First_Sulfuras_Dosent_Change()
  {
    program.Items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = 0, Quality = 80 });
    program.UpdateQuality();
    var sulfuras = program.Items[0];

    sulfuras!.SellIn.Should().Be(0);
    sulfuras!.Quality.Should().Be(80);
  }

  [Fact]
  public void Second_Sulfuras_Dosent_Change()
  {
    program.Items.Add(new Item { Name = "Sulfuras, Hand of Ragnaros", SellIn = -1, Quality = 80 });
    program.UpdateQuality();
    var sulfuras = program.Items[0];

    sulfuras!.SellIn.Should().Be(-1);
    sulfuras!.Quality.Should().Be(80);
  }

  [Fact]
  public void First_Backstage_Day6_sellIn9_and_Quality27()
  {
    program.Items.Add(new Item
    {
      Name = "Backstage passes to a TAFKAL80ETC concert",
      SellIn = 15,
      Quality = 20
    });
    for (int i = 0; i < 6; i++)
    {
      program.UpdateQuality();
    }

    var item = program.Items[0];

    item!.SellIn.Should().Be(9);
    item!.Quality.Should().Be(27);
  }

  [Fact]
  public void Backstage_Day10_sellIn5_and_Quality35()
  {
    program.Items.Add(new Item
    {
      Name = "Backstage passes to a TAFKAL80ETC concert",
      SellIn = 15,
      Quality = 20
    });
    for (int i = 0; i < 10; i++)
    {
      program.UpdateQuality();
    }
    var item = program.Items[0];

    item!.SellIn.Should().Be(5);
    item!.Quality.Should().Be(35);
  }

  [Fact]
  public void Backstage_Day11_sellIn4_and_Quality38()
  {
    program.Items.Add(new Item
    {
      Name = "Backstage passes to a TAFKAL80ETC concert",
      SellIn = 15,
      Quality = 20
    });
    for (int i = 0; i < 11; i++)
    {
      program.UpdateQuality();
    }
    var item = program.Items[0];

    item!.SellIn.Should().Be(4);
    item!.Quality.Should().Be(38);
  }

  [Fact]
  public void Backstage_Day6_SellIn_minus1_and_Quality0()
  {
    program.Items.Add(new Item
    {
      Name = "Backstage passes to a TAFKAL80ETC concert",
      SellIn = 5,
      Quality = 49
    });
    for (int i = 0; i < 6; i++)
    {
      program.UpdateQuality();
    }
    var item = program.Items[0];

    item!.SellIn.Should().Be(-1);
    item!.Quality.Should().Be(0);
  }

  [Fact]
  public void Backstage_Day2_not_greater_than_50_quality()
  {
    program.Items.Add(new Item
    {
      Name = "Backstage passes to a TAFKAL80ETC concert",
      SellIn = 5,
      Quality = 49
    });
    for (int i = 0; i < 1; i++)
    {
      program.UpdateQuality();
    }
    var item = program.Items[0];

    item!.SellIn.Should().Be(4);
    item!.Quality.Should().Be(50);
  }
}
