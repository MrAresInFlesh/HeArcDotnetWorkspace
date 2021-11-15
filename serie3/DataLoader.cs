using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Data;
using System.Text.RegularExpressions;

namespace serie3
{
    class DataLoader
    {
        /// <summary>
        /// Data struct to be used to store data.
        /// This is just, again, a simple container.
        /// </summary>
        public struct Data
        {
            object data;
            private String category;

            public Data(String data, String category)
            {
                this.category = category;
                this.data = new List<object>();
                InitData(data);
            }

            /// <summary>
            /// Initializing data from the .csv.
            /// Using object makes it easy to change between types when loading.
            /// Because String is immutable, except for Split(), it is not necessary to check
            /// if String is nullable (because it is).
            /// </summary>
            /// <param name="data"></param>
            private void InitData(String data)
            {
                String[] str = new String[] { };
                try
                {
                    str = (!String.IsNullOrEmpty(data.Split(';').ToString()) ? data.Split(';') : null);
                }
                catch
                {
                    str = new String[] { "-" };
                }
                if (str[0].All(char.IsDigit))
                {
                    int value;
                    if(int.TryParse(str[0], out value)) value = int.Parse(data);
                    this.data = value;
                }
                else if (str[0].Contains(".") && str[0].Any(char.IsDigit))
                {
                    double value;
                    if(double.TryParse(str[0], out value)) value = double.Parse(data);
                    this.data = value;
                }
                else
                {
                    this.data = str[0];
                }
            }

            public object GetData()
            {
                return this.data;
            }

            public String GetColumn()
            {
                return this.category;
            }

        }

        /// <summary>
        /// Class that contains methods to manipulate given data type.
        /// </summary>
        public class DataSet
        {
            public List<Data> dataBase;

            public DataSet(List<Data> dataList)
            {
                this.dataBase = dataList;
            }

            public void DisplayOccurencesOfTargetObjectInColumn(String category, object dataType)
            {
                int count = 0;
                StringBuilder stringBuilder = new StringBuilder();
                Console.WriteLine(category + " : ");
                this.dataBase.ForEach(data => 
                {
                    if (data.GetColumn().Contains(category) && dataType.ToString() == data.GetData().ToString())
                    {
                        count += 1;
                        stringBuilder.Append("[" + data.GetData() + "]");
                    }
                });
                Console.WriteLine(stringBuilder + " number of occurencies : " + count);
            }

            public void DisplayNumberOfDifferentDataInColumn(String category)
            {
                int count = 0;
                HashSet<object> hashSet = new HashSet<object>();
                Console.Write(category + " : ");
                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn().Contains(category))
                    {
                        hashSet.Add(data.GetData());
                    }
                });
                hashSet.Remove(0);
                DataLoader.Each(hashSet, element => Console.Write("[" + element + "]"));
                Console.Write(" there is " + hashSet.Count() + " different " + category);
            }

            public void DisplayAll()
            {
                Console.Write("\n|");
                HashSet<String> hashSet = new HashSet<String>();
                DataLoader.Each(this.dataBase, data => hashSet.Add(data.GetColumn()));
                IEnumerable<String> columnsQuery = from columns in hashSet
                                                   select columns;
                foreach (String columns in columnsQuery)
                {
                    Console.Write("[" + columns + "]|");
                }
                Console.Write("\n");

                IEnumerable<object> databaseQuery = from columns in this.dataBase
                                                    select columns.GetData();
                int iteration = hashSet.Count()-1;
                foreach (object columns in databaseQuery)
                {
                    if (iteration != 0)
                    {
                        Console.Write("[" + columns + "]|");
                        iteration -= 1;
                    }
                    else if (iteration == 0)
                    {
                        Console.Write("[" + columns + "]|\n");
                        iteration = hashSet.Count()-1;
                    }
                }
            }

            public void DisplayAllAlphabetically()
            {
                Console.Write("\n|");
                HashSet<String> hashSet = new HashSet<String>();
                DataLoader.Each(this.dataBase, data => hashSet.Add(data.GetColumn()));
                IEnumerable<String> columnsQuery = from columns in hashSet
                                                   select columns;
                foreach (String columns in columnsQuery)
                {
                    Console.Write("[" + columns + "]|");
                }
                Console.Write("\n");

                IEnumerable<Data> databaseQuery = from data in this.dataBase
                                                  select data;

                int iteration = hashSet.Count() - 1;
                foreach (Data columns in databaseQuery)
                {
                    if (iteration == hashSet.Count() - 1)
                    {
                        Console.Write("[" + columns.GetColumn() + "]    |====>  ");
                        Console.Write("[" + columns.GetData() + "]|");
                        iteration -= 1;
                    }
                    else if (iteration != 0)
                    {
                        Console.Write("[" + columns.GetData() + "]|");
                        iteration -= 1;
                    }
                    else if (iteration == 0)
                    {
                        Console.Write("[" + columns.GetData() + "]|\n");
                        iteration = hashSet.Count() - 1;
                    }
                }
            }

            public void DisplayPriceInferiorThan150(String category1, String category2, int limit)
            {
                Dictionary<String, (String, String)> keyValuePairs = new Dictionary<String, (String, String)>();

                List<String> listOfValueForCategory1 = new List<String>();
                List<String> listOfValueForCategory2 = new List<String>();
                List<String> listOfKeysForCategory1 = new List<String>();
                Console.Write(category1 + " : ");

                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn() == "Nom")
                    {
                        Console.WriteLine(data.GetData().ToString());
                        listOfKeysForCategory1.Add(data.GetData().ToString());
                    }
                });

                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn() == "TarifAdulte")
                    {
                        Console.WriteLine(data.GetData().ToString());
                        listOfValueForCategory1.Add(data.GetData().ToString());
                    }
                });

                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn() == "TarifEnfant")
                    {
                        Console.WriteLine(data.GetData().ToString());
                        listOfValueForCategory2.Add(data.GetData().ToString());
                    }
                });

                for (int i = 0; i < listOfKeysForCategory1.Count(); i++)
                {
                    keyValuePairs.Add(listOfKeysForCategory1.ElementAt(i), 
                        (listOfValueForCategory1.ElementAt(i),
                        listOfValueForCategory2.ElementAt(i))
                        );
                }

                Each(keyValuePairs, k => { int value = (int.Parse(k.Value.Item1) * 2 + (int.Parse(k.Value.Item2) * 2));
                if (value < limit)
                    Console.WriteLine("Station : " + k.Key +
                        "Tarif adulte : " + k.Value.Item1 +
                        " | Tarif enfant : " + k.Value.Item2 +
                        " | tarif 2 adultes plus 2 enfant = " +
                        value +
                        " est inferieur a : " +
                        limit);
                });
            }

            /// <summary>
            /// BONUS:
            /// Computation to get the stations in the radius defined by the limit parameter.
            /// </summary>
            /// <param name="limit"></param>
            /// <param name="latitude"></param>
            /// <param name="longitude"></param>
            /// <returns>IEnumerable<Tuple<String, Double>></returns>
            public IEnumerable<Tuple<String, Double>> SkiStationNearHeArc(double limit, double latitude, double longitude, bool print=false)
            {
                Dictionary<String, (Double, Double)> keyValuePairs = new Dictionary<String, (Double, Double)>();

                List<Double> listOfValueForCategory1 = new List<Double>();
                List<Double> listOfValueForCategory2 = new List<Double>();
                List<String> listOfKeys = new List<String>();
                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn() == "Nom")
                    {
                        listOfKeys.Add(data.GetData().ToString());
                    }
                });

                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn() == "Longitude")
                    {
                        double value = double.Parse(data.GetData().ToString());
                        listOfValueForCategory1.Add(value);
                    }
                });

                this.dataBase.ForEach(data =>
                {
                    if (data.GetColumn() == "Latitude")
                    {
                        double value = double.Parse(data.GetData().ToString());
                        listOfValueForCategory2.Add(value);
                    }
                });

                for (int i = 0; i < listOfKeys.Count(); i++)
                {
                    keyValuePairs.Add(listOfKeys.ElementAt(i),
                        (listOfValueForCategory1.ElementAt(i),
                        listOfValueForCategory2.ElementAt(i))
                        );
                }

                IEnumerable<Tuple<String, Double>> databaseQuery = from data in keyValuePairs
                                                    let distance = (DataSet.
                                                    GetDistance(data.Value.Item1, data.Value.Item2, 
                                                    longitude, latitude) / 1000)
                                                    where distance < 150
                                                    orderby distance ascending
                                                    select Tuple.Create(data.Key, distance);

                if(print)
                {
                    Each(keyValuePairs, k => {
                        double value = DataSet.
                        GetDistance(k.Value.Item1, k.Value.Item2, 
                        longitude, latitude) / 1000;
                        if (value < limit)
                            Console.WriteLine("Station : " + k.Key +
                                "\nLongitude : " + k.Value.Item1 +
                                " | Latitude : " + k.Value.Item2 +
                                " | distance between station and the he-arc = " +
                                value + "[km]" +
                                " limit fixed : " +
                                limit + "[km]");
                    });
                }
                return databaseQuery;
            }

            /// <summary>
            /// Source : https://stackoverflow.com/questions/6366408/calculating-distance-between-two-latitude-and-longitude-geocoordinates
            /// </summary>
            /// <param name="longitude"></param>
            /// <param name="latitude"></param>
            /// <param name="otherLongitude"></param>
            /// <param name="otherLatitude"></param>
            /// <returns></returns>
            public static double GetDistance(double longitude, double latitude, double otherLongitude, double otherLatitude)
            {
                var rad = (Math.PI / 180.0);
                var d1 = latitude * rad;
                var num1 = longitude * rad;
                var d2 = otherLatitude * rad;
                var num2 = otherLongitude * rad - num1;
                var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

                return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));

            }
        }

        public List<Data> dataList;

        public DataLoader(String filename, Encoding encoding, bool debug=false)
        {
            this.dataList = LoadCsvFile(filename, encoding);
        }

        private List<Data> LoadCsvFile(String filename, Encoding encoding, bool debug=false)
        {
            List<Data> data = new List<Data>();
            StreamReader streamReader = new StreamReader(new FileStream(filename, FileMode.Open), encoding);
            
            /**
             * Importing columns that will represent the categroy of each cell of the database.
             */
            String[] columns_name = streamReader.ReadLine().Split(';');
            string stringStream;

            while ((stringStream = streamReader.ReadLine()) != null)
            {
                if (debug) Console.WriteLine(stringStream);
                String[] row = stringStream.Split(';');
                for(int i = 0; i < row.Length; i++)
                {
                    data.Add(new Data(row[i], columns_name[i]));
                }
            }
            streamReader.Close();
            return data;
        }

        public DataSet CreateDataSet()
        {
            return new DataSet(this.dataList);
        }

        public static void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items) action(item);
        }

    }
}
