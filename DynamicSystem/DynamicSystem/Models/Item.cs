namespace DynamicSystem.Models
{
    public class Item
    {
        public string Name { get; set; }
        public Item[] Dependencies { get; set; }

        public Item(string name, params Item[] dependencies)
        {
            Name = name;
            Dependencies = dependencies;
        }

        public override int GetHashCode()
        {
            return GetHashCodeInternal(Name.GetHashCode(), Dependencies.GetHashCode());
        }

        private static int GetHashCodeInternal(int key1, int key2)
        {
            unchecked
            {
                //Seed
                var num = 0x7e53a269;

                //Key 1
                num = (-1521134295 * num) + key1;
                num += (num << 10);
                num ^= (num >> 6);

                //Key 2
                num = ((-1521134295 * num) + key2);
                num += (num << 10);
                num ^= (num >> 6);

                return num;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Item p = obj as Item;
            if (p == null)
                return false;

            // Return true if the fields match:
            return (Name == p.Name) && (Dependencies == p.Dependencies);
        }
    }
}
