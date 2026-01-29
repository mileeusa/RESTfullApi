using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListInActions.Entities
{
    public class PartForSort : IEquatable<PartForSort>, IComparable<PartForSort>
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public PartForSort(int partId, string name, decimal price)
        {
            PartId = partId;
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return $"PartId: {PartId}, Name: {Name}, Price: {Price}";
        }
        public override bool Equals(object? obj)
        {
            if (obj == null) 
                return false;

            PartForSort? other = obj as PartForSort;
            if (other == null)
                return false;

            return Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(PartId, Name, Price);
        }

        public bool Equals(PartForSort? other)
        {
            if (other == null) return false;
            return this.PartId.Equals(other.PartId);
        }

        public int CompareTo(PartForSort? other)
        {
            if (other == null) return 1;
            return this.PartId.CompareTo(other.PartId);
        }

        public int SortByNameAscending(string name1, string name2)
        {
            return string.Compare(name1, name2);
        }
    }
}
