using Sound;
using UnityEngine;

namespace Enemy
{
    public class EnemyDeath : MonoBehaviour
    {
        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Bullet"))
            {
                SoundManager.Instance.PlayEnemyDeath();
                Destroy(gameObject);
            }
        }
    }
}
