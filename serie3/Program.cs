using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace serie3
{
    class Program
    {
        static void Main(string[] args)
        {
            string filename = "SwissSkiDB.csv";

            DataLoader dataLoader = new DataLoader(filename, Encoding.UTF7);
            DataLoader.DataSet dataset = dataLoader.CreateDataSet();
            dataset.DisplayOccurencesOfTargetObjectInColumn("Canton", "VS");
            dataset.DisplayNumberOfDifferentDataInColumn("Canton");
            // dataset.DisplayAllAlphabetically();
            // dataset.DisplayPriceInferiorThan150("TarifAdulte", "TarifEnfant", 110);
            IEnumerable<Tuple<String, Double>> query = dataset.SkiStationNearHeArc(150, 46.997727, 6.938725);
            foreach (Tuple<String, Double> distance in query)
            {
                Console.WriteLine("Station : " + distance.Item1 + " est à " + distance.Item2 + " [km] de la he-arc (<150[km]).");
            }
        }
    }
}
