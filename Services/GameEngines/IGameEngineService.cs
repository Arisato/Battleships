using Battleships.Models;

namespace Battleships.Services.GameEngines
{
    public interface IGameEngineService
    {
        Event ReadCoordInput(string input);
    }
}
