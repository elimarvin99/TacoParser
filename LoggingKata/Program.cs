using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);

            logger.LogInfo($"Lines: {lines[0]}");

            // Create a new instance of your TacoParser class
            var parser = new TacoParser();

            // Grab an IEnumerable of locations using the Select command: var locations = lines.Select(parser.Parse);
            var locations = lines.Select(parser.Parse).ToArray();
            //foreach (var item in locations)
            //{
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.Location.Longitude);
            //    Console.WriteLine(item.Location.Latitude);

            //}

            ITrackable far = null;
            ITrackable farther = null;
            double distance = 0.0;

            for (int i = 0; i < lines.Length; i++)
            {
                GeoCoordinate locA = new GeoCoordinate(locations[i].Location.Latitude, locations[i].Location.Longitude);
                for (int x = 0; x < lines.Length; x++)
                {
                    GeoCoordinate locB = new GeoCoordinate(locations[x].Location.Latitude, locations[x].Location.Longitude);
                    if (locA.GetDistanceTo(locB) > distance)
                    {
                        distance = locA.GetDistanceTo(locB);
                        far = locations[i];
                        farther = locations[x];
                    }
                }
            }

            // Once you've looped through everything, you've found the two Taco Bells farthest away from each other.
            var miles = Math.Round(distance * 0.00062);

            //Console.WriteLine(far.Name);
            //Console.WriteLine(farther.Name);
            //Console.WriteLine(distance);
            Console.WriteLine($"{far.Name} is {miles} miles away from {farther.Name}.");
        }

       
    }
}
