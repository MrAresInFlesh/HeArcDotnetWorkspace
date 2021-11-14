using System;
using System.IO;
using System.Text;

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
            dataset.DisplayAllAlphabetically();
        }
    }
}
