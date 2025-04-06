using Battleships.Assets.Vehicles.Enums;

namespace Battleships.Assets.Vehicles
{
    public class WaterCraft
    {
        public WaterCraft(TypeSize type)
        {
            Name = type.ToString();
            Size = (int)type;
        }

        public string Name { get; private set; }
        public int Size { get; private set; }
    }
}
