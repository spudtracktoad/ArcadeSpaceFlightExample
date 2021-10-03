using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceFighter
{
    public class GunController : MonoBehaviour
    {
        public Gun[] guns;
        public Transform GimbalTarget = null;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            AttemptFireCannon();
        }

        ///<summary>
        ///Will attempt to fire the guns
        /// </summary>
        private void AttemptFireCannon()
        {
            if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.Space))
            {
                foreach (var gun in guns)
                {
                    if (GimbalTarget != null)
                    {
                        gun.UseGimballedAiming = true;
                        gun.GimbalTarget = GimbalTarget.position;
                    }
                    else
                    {
                        gun.UseGimballedAiming = false;
                    }
                    gun.FireSingleShot();
                }
            }
        }
    }
}
