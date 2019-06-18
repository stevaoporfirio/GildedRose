using GildedRose;
using System.Collections.Generic;

namespace GildedRose
{
    public class GildedRose
    {
        IList<Item> Items;

        public const string Aged = "Aged Brie";
        public const string Backstage = "Backstage passes to a TAFKAL80ETC concert";
        public const string Sulfuras = "Sulfuras, Hand of Ragnaros";
        public const string Conjured = "Conjured Mana Cake";


        public GildedRose(IList<Item> Items)
        {
            this.Items = Items;
        }

        private void MultQuality(Item item, int mult)
        {
            int rate = 1;

            item.Quality += (rate * mult);
            ItemQuality(item);

        }
        private void ItemQuality(Item item)
        {
            if (item.Quality < 0)
            {
                item.Quality = 0;
            }

            if (item.Quality > 50)
            {
                item.Quality = 50;
            }
        }

        private void Seller(Item myItem)
        {
            myItem.SellIn -= 1;
        }


        public void UpdateQuality()
        {
            foreach (var item in Items)
            {
                if (item.Name.Equals(Aged))
                {
                    Seller(item);
                    MultQuality(item, 1);
                }
                else if (item.Name.Equals(Backstage))
                {
                    Seller(item);
                    if (item.SellIn < 11 && item.SellIn > 5)
                        MultQuality(item, 2);
                    else if (item.SellIn < 6 && item.SellIn > 0)
                        MultQuality(item, 3);
                    else if (item.SellIn < 0)
                        MultQuality(item, 50);
                    else
                        MultQuality(item, 1);
                }
                else if (item.Name.Equals(Sulfuras))
                {
                    ItemQuality(item);
                }
                else if (item.Name.Equals(Conjured))
                {
                    Seller(item);
                    if (item.SellIn < 0)
                    {
                        MultQuality(item, -4);
                    }
                    else
                    {
                        MultQuality(item, -2);
                    }
                }
                else
                {
                    Seller(item);
                    if (item.SellIn < 0)
                    {
                        MultQuality(item, -2);
                    }
                    else
                    {
                        MultQuality(item, -1);
                    }
                }
            }

        }
    }
}
