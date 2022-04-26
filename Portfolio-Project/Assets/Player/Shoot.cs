//using Sound;
using UnityEngine;

namespace Player
{
    public class Shoot : MonoBehaviour
    {
        [SerializeField]
        private Camera playerCam;
        [SerializeField]
        private GameObject projectile;
        [SerializeField]
        private Transform shotPoint;
        private bool _isShooting;
        private bool _canShoot = true;
        private Vector3 _destination;
        private float _speed = 30;

        private void Update()
        {
            // If they press the button and can shoot
            if (_isShooting && _canShoot)
            {
                ShootProjectile();
                _canShoot = false;
            }
            // If they are not pressing the button let them shoot again -> creates semi auto functionality
            else if (!_isShooting && !_canShoot)
            {
                _canShoot = true;
            }
        }

        private void ShootProjectile()
        {
            // Create new ray cast
            Ray ray = playerCam.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
            RaycastHit hit;

            // If it hit something, get the position
            if (Physics.Raycast(ray, out hit))
            {
                _destination = hit.point;
            }
            // Else just grab a position 1000 units away
            else
            {
                _destination = ray.GetPoint(1000);
            }

            var projectileObj = Instantiate(projectile, shotPoint.position, Quaternion.identity) as GameObject;
            projectileObj.GetComponent<Rigidbody>().velocity = (_destination - shotPoint.position).normalized * _speed;
            
            //SoundManager.Instance.PlayShoot();
        }

        public void PassInput(bool isShooting)
        {
            _isShooting = isShooting;
        }
    }
}
