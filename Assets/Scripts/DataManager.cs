using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using UnityEngine;

public class DataManager
{

	public static List<Task> taskList = new List<Task>();

	static List<string> taskNames = new List<string>();

	/// <summary>
	/// The data path is the root of the assets folder.
	/// </summary>
	private static string dataPath = Application.dataPath + "/Data";

	/// <summary>
	/// Saves the categories.
	/// </summary>
	public void SaveTasks()
	{
		BinaryFormatter bf = new BinaryFormatter();
		var saveFile = File.Create(dataPath + "/tasks.dat");
		bf.Serialize(saveFile, taskList);
		saveFile.Close();
	}

	/// <summary>
	/// Loads the categories.
	/// </summary>
	public void LoadTasks()
	{
		try
		{
			// check if the file exists before doing anything.
			if (File.Exists(dataPath + "/tasks.dat"))
			{
				BinaryFormatter bf = new BinaryFormatter();
				var f = File.Open(dataPath + "/tasks.dat", FileMode.OpenOrCreate);
				taskList = (List<Task>)bf.Deserialize(f);
				for (int i = 0; i < taskList.Count; i++)
				{
					taskNames.Add(taskList[i].name);
				}
			}

		}
		catch (SerializationException e)
		{
			Debug.LogErrorFormat("Error loading categories: {0}", e);
		}

	}
}
