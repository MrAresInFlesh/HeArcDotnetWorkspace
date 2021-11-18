using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace serie3
{
	public class DataSet
	{
		public List<Data> dataBase;

		public DataSet(List<Data> dataList)
		{
			this.dataBase = dataList;
		}

		/// <summary>
		/// Select the occurence entered as a parameter in your database.
		/// </summary>
		/// <param name="category"></param>
		/// <param name="dataType"></param>
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

		/// <summary>
		/// Return the number of occurence of a certain category of data.
		/// </summary>
		/// <param name="category"></param>
		public void DisplayNumberOfDifferentDataInColumn(String category)
		{
			HashSet<object> hashSet = new HashSet<object>();
			Console.WriteLine("\nDisplayNumberOfDifferentDataInColumn() :");
			Console.Write(category + " : ");
			this.dataBase.ForEach(data =>
			{
				if (data.GetColumn().Contains(category))
				{
					hashSet.Add(data.GetData());
				}
			});
			hashSet.Remove(0);
			DataUtil.Each(hashSet, element => Console.Write("[" + element + "]"));
			Console.Write(" there is " + hashSet.Count() + " different " + category + "\n\n");
		}

		/// <summary>
		/// Display all data from dataset.
		/// </summary>
		public void DisplayAll()
		{
			Console.Write("\n|");
			HashSet<String> hashSet = new HashSet<String>();
			DataUtil.Each(this.dataBase, data => hashSet.Add(data.GetColumn()));
			IEnumerable<String> columnsQuery = from columns in hashSet
											   select columns;
			foreach (String columns in columnsQuery)
			{
				Console.Write("[" + columns + "]|");
			}
			Console.Write("\n");

			IEnumerable<object> databaseQuery = from columns in this.dataBase
												select columns.GetData();
			int iteration = hashSet.Count() - 1;
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
					iteration = hashSet.Count() - 1;
				}
			}
		}

		/// <summary>
		/// Display all selected category of a datatype in ascending order.
		/// </summary>
		/// <param name="key"></param>
		public void DisplayAllAscending(String key)
		{
			List<Tuple<String, List<String>>> keyValuePairs = new List<Tuple<String, List<String>>>();
			HashSet<String> hashSet = new HashSet<String>();
			DataUtil.Each(this.dataBase, data => hashSet.Add(data.GetColumn()));

			List<List<String>> listOfValueForCategory = new List<List<String>>();
			List<String> listOfKeys = new List<String>();
			this.dataBase.ForEach(data =>
			{
				if (data.GetColumn() == key)
				{
					listOfKeys.Add(data.GetData().ToString());
				}
			});

			IEnumerable<Data> columnsQuery = from columns in this.dataBase
											 select columns;

			int iteration = hashSet.Count() - 1;
			List<String> dataColumns = new List<string>();

			int index = 0;
			foreach (Data columns in columnsQuery)
			{
				if (iteration != 0)
				{
					dataColumns.Add(columns.GetData().ToString());
					iteration -= 1;
				}
				else
				{
					dataColumns.Add(columns.GetData().ToString());
					// dataColumns.ForEach(elem => Console.Write("|" + elem));
					// Console.Write("|\n");
					keyValuePairs.Add(Tuple.Create(listOfKeys.ElementAt(index), dataColumns));
					iteration = hashSet.Count() - 1;
					index += 1;
					dataColumns = new List<String>();
				}
			}

			IEnumerable<Tuple<String, List<String>>> databaseQuery = from data in keyValuePairs
																	 orderby data.Item1 ascending
																	 select Tuple.Create(data.Item1, data.Item2);

			foreach (Tuple<String, List<String>> data in databaseQuery)
			{
				Console.WriteLine("-----------------------------------------------------------------------------------------------------------------------");
				Console.Write("Station : " + data.Item1 + " | ");
				data.Item2.ForEach(element => Console.Write(element + " | "));
				Console.WriteLine();
			}
		}

		/// <summary>
		/// Exactly what the name of the method do.
		/// </summary>
		/// <param name="category1"></param>
		/// <param name="category2"></param>
		/// <param name="limit"></param>
		public void DisplayPriceInferiorThanLimit(String category1, String category2, int limit)
		{
			Dictionary<String, (String, String)> keyValuePairs = new Dictionary<String, (String, String)>();

			List<String> listOfValueForCategory1 = new List<String>();
			List<String> listOfValueForCategory2 = new List<String>();
			List<String> listOfKeysForCategory1 = new List<String>();

			this.dataBase.ForEach(data =>
			{
				if (data.GetColumn() == "Nom")
				{
					listOfKeysForCategory1.Add(data.GetData().ToString());
				}
			});

			this.dataBase.ForEach(data =>
			{
				if (data.GetColumn() == "TarifAdulte")
				{
					listOfValueForCategory1.Add(data.GetData().ToString());
				}
			});

			this.dataBase.ForEach(data =>
			{
				if (data.GetColumn() == "TarifEnfant")
				{
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

			DataUtil.Each(keyValuePairs, k =>
			{
				int value = (int.Parse(k.Value.Item1) * 2 + (int.Parse(k.Value.Item2) * 2));
				if (value < limit)
					Console.WriteLine("Station : " + k.Key +
						" | Tarif adulte : " + k.Value.Item1 +
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
		public IEnumerable<Tuple<String, Double>> SkiStationNearHeArc(double limit, double latitude, double longitude, bool print = false)
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

			if (print)
			{
				DataUtil.Each(keyValuePairs, k =>
				{
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
}
