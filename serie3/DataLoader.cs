using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace serie3
{
    /// <summary>
    /// Data struct to be used to store data.
    /// This is just, again, a simple container.
    /// </summary>
    public struct Data
    {
        public object data;
        public String category;

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
                if (int.TryParse(str[0], out value)) value = int.Parse(data);
                this.data = value;
            }
            else if (str[0].Contains(".") && str[0].Any(char.IsDigit))
            {
                double value;
                if (double.TryParse(str[0], out value)) value = double.Parse(data);
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
    /// To load csv data and store them as object with category as columns
    /// </summary>
    public class DataLoader
    {

        public List<Data> dataList;

        /// <summary>
        /// Constructor directly creating a List<Data> of the given file and the chosen encoding.
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        /// <param name="debug"></param>
        public DataLoader(String filename, Encoding encoding, bool debug=false)
        {
            this.dataList = LoadCsvFile(filename, encoding);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="encoding"></param>
        /// <param name="debug"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Creation of a dataset after the construction of 
        /// </summary>
        /// <returns></returns>
        public DataSet CreateDataSet()
        {
            return new DataSet(this.dataList);
        }
    }
}
