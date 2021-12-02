using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace TheFirstGame.Interfaces
{
    public class SecurityCam : MonoBehaviour, IAlerter
    {
        protected List<Collider> _checkableItems = new List<Collider>();

        protected Plane[] planes;
        public Camera cam;

        
        protected virtual void Update()
        {
            planes = GeometryUtility.CalculateFrustumPlanes(cam);

            foreach (var item in _checkableItems)
            {
                if(GeometryUtility.TestPlanesAABB(planes, item.bounds))
                {
                    SendAlert();
                    break;
                }
            }
            //GeometryUtility.CalculateFrustumPlanes
            
        }

        private void OnTriggerEnter(Collider other)
        {
            _checkableItems.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _checkableItems.Remove(other);

        }


        #region
        public void SendAlert()
        {
            //TODO Implementare l'alert
            Debug.Log("Ho scoperto qualcosa");
        }
        #endregion

    }
}

