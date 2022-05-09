using Sound;
using UnityEngine;

public class Door : MonoBehaviour
{
    [SerializeField] 
    private int killsNeeded;

    private void Update()
    {
        if ((26 - DisplayManager.EnemiesLeft) == killsNeeded)
        {
            SoundManager.Instance.PlayDoorOpen();
            gameObject.SetActive(false);
        }
    }
}
