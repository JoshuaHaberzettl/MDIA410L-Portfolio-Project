using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Save
{
	public class Leaderboard : MonoBehaviour
	{
		[SerializeField]
		private List<TextMeshProUGUI> scoreText;

		public static Leaderboard Instance;
		
		private void Awake()
		{
			// Make this a singleton
			if (Instance == null)
			{
				Instance = this;
				DontDestroyOnLoad(gameObject);
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void UpdateBoard(List<string> scores)
		{
			for (int i = 0; i < scores.Count; i++)
			{
				if (scoreText [i] != null)
				{
					scoreText [i].text = (i+1) + ") " + scores [i];
				}
			}
		}
	}
}
