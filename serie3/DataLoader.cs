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
