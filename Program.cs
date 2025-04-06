using Battleships.Models;
using Battleships.Services.GameEngines;
using Battleships.Services.GridBuilders;
using Battleships.Utilities;
using Battleships.Utilities.Enums;
using System.Text.Json;

namespace Battleships
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Screen Feedback Draw
            var feedbackInterface = new FeedbackInterface();

            // Game Setup
            var settings = InitSettings();
            feedbackInterface.SendFeedback(new Event { ActionType = ActionType.InitSettings });

            var grid = new GridBuilderService().BuildGrid(settings);
            feedbackInterface.SendFeedback(new Event { ActionType = ActionType.InitGrid });

            var gameEngine = new GameEngineService(grid);
            feedbackInterface.SendFeedback(new Event { ActionType = ActionType.EngineInit });

            // Game Start
            feedbackInterface.SendFeedback(new Event { ActionType = ActionType.GameStart });

            while (gameEngine.IsGameLive)
            {
                feedbackInterface.PrintMap(gameEngine.Grid);
                feedbackInterface.SendFeedback(new Event { ActionType = ActionType.PlayerTurn });
                feedbackInterface.SendFeedback(gameEngine.ReadCoordInput(Console.ReadLine()?.ToUpper()));
            }

            // Game End
            if (gameEngine.IsGridValid)
            {
                feedbackInterface.PrintMap(gameEngine.Grid);
                feedbackInterface.SendFeedback(new Event { ActionType = ActionType.GameEnd });
            }
            else
            {
                feedbackInterface.SendFeedback(new Event { ActionType = ActionType.InvalidGrid });
            }
        }

        private static Settings.Settings InitSettings()
        {
            using StreamReader file = File.OpenText($"{Directory.GetCurrentDirectory()}//{nameof(Settings.Settings)}.json");

            return JsonSerializer.Deserialize<Settings.Settings>(file.BaseStream);
        }
    }
}