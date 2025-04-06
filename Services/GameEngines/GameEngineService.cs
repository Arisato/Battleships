using Battleships.Assets.Grids;
using Battleships.Models;
using Battleships.Utilities.Enums;

namespace Battleships.Services.GameEngines
{
    public class GameEngineService : IGameEngineService
    {
        public GameEngineService(AlphaNumeric? grid)
        {
            if (grid != null)
            {
                IsGridValid = true;
                Grid = grid;
            }
        }

        public Event ReadCoordInput(string input)
        {
            var countSnapshot = Grid?.WaterCrafts.Count;
            var targetName = Grid?.ReadCoordinate(input);

            if (!string.IsNullOrEmpty(targetName))
            {
                if (countSnapshot > Grid?.WaterCrafts.Count)
                {
                    return new Event { ActionType = ActionType.ShipHasSunk, TargetName = targetName };
                    
                }
                else
                {
                    return new Event { ActionType = ActionType.Hit, TargetName = targetName };
                }
            }
            
            return new Event { ActionType = ActionType.Miss };
        }

        public bool IsGridValid { get; private set; }

        public bool IsGameLive { get { return IsGridValid && Grid.WaterCrafts.Any(); } }

        public AlphaNumeric? Grid { get; private set; }
    }
}
