using Battleships.Assets.Grids;

namespace Battleships.Services.GridBuilders
{
    public interface IGridBuilderService
    {
        AlphaNumeric? BuildGrid(Settings.Settings settings);
    }
}
