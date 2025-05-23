﻿using Battleships.Assets.Grids;
using Battleships.Assets.Vehicles;

namespace Battleships.Services.GridBuilders
{
    public class GridBuilderService : IGridBuilderService
    {
        public AlphaNumeric? BuildGrid(Settings.Settings settings)
        {
            if ((settings.VehiclesQty.Select(x => (int)x.Key * x.Value).Sum() * 5) <= (settings.GridSizeX * settings.GridSizeY))
            {
                var waterCrafts = new List<WaterCraft>();

                foreach (var waterCraft in settings.VehiclesQty)
                {
                    for (int i = 0; i < waterCraft.Value; i++)
                    {
                        waterCrafts.Add(new WaterCraft(waterCraft.Key));
                    }
                }

                return new AlphaNumeric(waterCrafts, settings.GridSizeX, settings.GridSizeY);
            }

            return null;
        }
    }
}
