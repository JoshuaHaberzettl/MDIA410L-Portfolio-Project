using UnityEngine;
using Random = UnityEngine.Random;

namespace Sound
{
	public class SoundManager : MonoBehaviour
	{
		public static SoundManager Instance;

		[SerializeField]
		private AudioSource shootSource, footstepSource;

		private void Awake()
		{
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

		private void Randomize(AudioSource source)
		{
			source.volume = Random.Range(.8f, 1);
			source.pitch = Random.Range(.85f, 1.1f);
		}

		private void Normalize(AudioSource source)
		{
			source.volume = 1;
			source.pitch = 1;
		}

		public void PlayShoot()
		{
			Randomize(shootSource);
			shootSource.Play();
		}
		
		public void PlayFootstep()
		{
			Randomize(footstepSource);
			footstepSource.Play();
		}
	}
}