using System;
using UnityEngine;

namespace Save
{
	public class Saving : MonoBehaviour
	{
		[SerializeField]
		private Timer timer;
		private string[] _times;

		private void Awake()
		{
			SaveObject saveObject = new SaveObject
			{
				SaveData = _times
			};
			
			string json = JsonUtility.ToJson(saveObject);
			
			SaveObject loadedSaveObject = JsonUtility.FromJson<SaveObject>(json);
		}

		private class SaveObject
		{
			public string[] SaveData;
		}
		
	}
}
