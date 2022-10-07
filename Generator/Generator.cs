// Copyright (c) 2022 Nuno Fachada
// Distributed under the MIT License (See accompanying file LICENSE_CODE or copy
// at http://opensource.org/licenses/MIT)

using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    public class Generator
    {
        private const int maxBitsForTerrain = 4; // i.e. max of 16 terrain types
        private const int bitsInByte = 8;
        private const double probResource = 0.3;
        private readonly int terrainMask;
        private readonly Random random;
        private readonly IDictionary<int, string> terrains;
        private readonly IDictionary<int, string> resources;

        public Generator(IEnumerable<string> terrainCollection,
            IEnumerable<string> resourceCollection)
        {
            int terrainCount = 0;
            int resourceBit = maxBitsForTerrain + 1;

            random = new Random();

            terrainMask =
                (int)(0xFFFFFFFF >> (sizeof(int) * bitsInByte - maxBitsForTerrain));

            terrains = new Dictionary<int, string>();
            resources = new Dictionary<int, string>();

            foreach (string terrain in terrainCollection)
            {
                terrains.Add(terrainCount, terrain);
                terrainCount++;
            }

            foreach (string resource in resourceCollection)
            {
                resources.Add(1 << resourceBit, resource);
                resourceBit++;
            }
        }

        public Map CreateMap(int rows, int cols)
        {
            Map map = new Map(rows, cols);
            IList<int> resourceList = new List<int>(resources.Keys);

            for (int r = 0; r < rows; r++)
            {
                for (int c = 0; c < cols; c++)
                {
                    int resourcesInTile = 0;
                    int tile = random.Next(terrains.Count);
                    resourceList.Shuffle();

                    while (random.NextDouble() < probResource
                        && resourcesInTile < resources.Count)
                    {
                        tile |= resourceList[resourcesInTile];
                        resourcesInTile++;
                    }

                    map[r, c] = tile;
                }
            }

            return map;
        }

        public void SaveMap(Map map, string file)
        {
            ICollection<string> resourcesInTile = new List<string>();

            using (TextWriter sw = new StreamWriter(file))
            {
                sw.WriteLine($"{map.Rows} {map.Cols}");
                for (int r = 0; r < map.Rows; r++)
                {
                    for (int c = 0; c < map.Cols; c++)
                    {
                        int tile = map[r, c];

                        string terrain = terrains[tile & terrainMask];

                        sw.Write(terrain);

                        resourcesInTile.Clear();

                        for (int i = 0; i < resources.Count; i++)
                        {
                            int resourceBit = maxBitsForTerrain + 1 + i;
                            int resourceMask = 1 << resourceBit;
                            bool resourceExists = (tile & resourceMask) != 0;

                            if (resourceExists)
                            {
                                sw.Write($" {resources[resourceMask]}");
                            }
                        }

                        if (c == 0)
                        {
                            sw.Write($"\t# Start of row {r}");
                        }

                        sw.WriteLine();
                    }
                }
            }
        }
    }
}