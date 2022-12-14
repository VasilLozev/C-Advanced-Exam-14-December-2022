using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;

namespace ShoeStore
{
    public class ShoeStore
    {
        private List<Shoe> shoes { get { return Shoes; } set { Shoes = value; } }

        public string Name { get; set; }
        public int StorageCapacity { get; set; }
        public List<Shoe> Shoes { get; set; }

        public ShoeStore(string name, int storageCapacity)
        {
            Shoes = new List<Shoe>();
            Name = name;
            StorageCapacity = storageCapacity;
        }
        public int Count => Shoes.Count;
        public string AddShoe(Shoe shoe)
        {
            if (shoes.Count == StorageCapacity)
            {
                shoes.Add(shoe);
                return "No more space in the storage room.";
            }
            else
            {
                shoes.Add(shoe);
                return $"Successfully added {shoe.Type} {shoe.Material} pair of shoes to the store.";
            }
        }
        public int RemoveShoes(string material)
        {
            int count = 0;
            for (int i = 0; i < shoes.Count; i++)
            {
                if (shoes[i].Material == material)
                {
                    shoes.RemoveAt(i);
                    count++;
                }
            }
            return count;
        }
        public List<Shoe> GetShoesByType(string type)
        {
            return shoes.Where(x => x.Type.ToLower() == type.ToLower()).ToList();
        }
        public Shoe GetShoeBySize(double size)
        {
            return shoes.Where(x => x.Size == size).First();
        }
        public string StockList(double size, string type)
        {
            shoes =  shoes.Where(x => x.Type.ToLower() == type.ToLower() && x.Size == size).ToList();
            
            if (shoes.Any())
            {
                Console.WriteLine($"Stock list for size {size} – {type} shoes:");
                return $"{string.Join('\n', shoes)}"; 
            }
               return "No matches found!";
        }
    }
}
