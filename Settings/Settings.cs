using Battleships.Assets.Vehicles.Enums;

namespace Battleships.Settings
{
    public class Settings
    {
        public int GridSizeX { get; set; }
        public int GridSizeY { get; set; }
        public required IDictionary<TypeSize, int> VehiclesQty { get; set; }
    }
}
