using Battleships.Assets.Grids;
using Battleships.Models;

namespace Battleships.Utilities
{
    public interface IFeedbackInterface
    {
        void SendFeedback(Event eventAction);

        void PrintMap(Grid grid);
    }
}
