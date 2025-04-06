using Battleships.Utilities.Enums;

namespace Battleships.Models
{
    public class Event
    {
        public ActionType ActionType { get; set; }

        public string TargetName { get; set; } = string.Empty;
    }
}
