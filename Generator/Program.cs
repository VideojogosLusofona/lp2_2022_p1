// Copyright (c) 2022 Nuno Fachada
// Distributed under the MIT License (See accompanying file LICENSE_CODE or copy
// at http://opensource.org/licenses/MIT)

using System;
using System.Collections.Generic;
using System.IO;

namespace Generator
{
    public static class Program
    {
        private const string terrainsFile = "terrains.txt";
        private const string resourcesFile = "resources.txt";

        private static int Main(string[] args)
        {
            int rows, cols;
            IEnumerable<string> terrains;
            IEnumerable<string> resources;
            Generator generator;
            Map map;

            if (args.Length != 3
                || !int.TryParse(args[0], out rows)
                || !int.TryParse(args[1], out cols)
                || rows < 1
                || cols < 1)
            {
                Console.Error.WriteLine(
                    "Usage:\n\tdotnet run --project Generator -- <rows> <cols> <file>");
                Console.Error.WriteLine(
                    "Example:\n\tdotnet run --project Generator -- 80 50 myworld.map4x");
                return -1;
            }

            try
            {
                terrains = File.ReadAllLines(terrainsFile);
                resources = File.ReadAllLines(resourcesFile);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return -2;
            }

            generator = new Generator(terrains, resources);
            map = generator.CreateMap(rows, cols);

            try
            {
                generator.SaveMap(map, args[2]);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
                return -3;
            }

            return 0;
        }
    }
}
