using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Save
{
	public class Saving : MonoBehaviour
	{
		public static Saving Instance;
		
		//[SerializeField]
		//private Timer timer;
		private List<string> _times = new List<string>();

		private class SaveObject
		{
			public List<string> SaveData;
		}
		
		private void Awake()
		{
			// Make Saving a singleton
			if (Instance == null)
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
			
			// Deal with the file
			SaveObject saveObject = new SaveObject
			{
				SaveData = _times
			};
			
			string json = JsonUtility.ToJson(saveObject);
			
			SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
		}

		private void Start()
		{
			LoadGame();
		}
		
		
		private void LoadGame()
		{
			//Actually reads the text from a file.
			string saveString = File.ReadAllText(Application.dataPath + "/Save/save.json");   
			
			//Convert text string to JSON format. Uses the SaveObject class to help organize the data. 
			SaveObject saveObject = JsonUtility.FromJson<SaveObject>(saveString);   
			// Gets the saved times from the json file
			_times = saveObject.SaveData;
        
			Debug.Log("Loaded. The times are: " + _times[0]);
		}

		public void Save(Timer timer)
		{
			// Take the new time and cut off after 2 millisecond digits
			string input = Timer.TimerText;
			int index = input.IndexOf(".", StringComparison.Ordinal);
			if (index >= 0)
				input = input.Substring(0, index+3);
			// Add the new time and sort the list
			_times.Add(input);
			_times.Sort();
			// Make sure list is max 10 items -> remove worst time if too big
			if (_times.Count > 10)
			{
				_times.RemoveAt(10);
			}

			// Creates a new SaveObject to hold the data
			SaveObject saveObject = new SaveObject()
			{
				SaveData = _times
			};
			// Converts data to format to be stored in json
			string json = JsonUtility.ToJson(saveObject);
			// Actually writes the data in the json file
			File.WriteAllText(Application.dataPath + "/Save/save.json", json);
		}
	}
}
