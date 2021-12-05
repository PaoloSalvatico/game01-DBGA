using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.AI;

namespace TheDayAfter.Interfaces
{
    public class SecurityCam : MonoBehaviour, IAlerter
    {
        protected List<Collider> _checkableItems = new List<Collider>();

        public Camera cam;
        protected Plane[] _planes;

        protected virtual void Update()
        {
            _planes = GeometryUtility.CalculateFrustumPlanes(cam);
            foreach (var item in _checkableItems)
            {
                if(GeometryUtility.TestPlanesAABB(_planes, item.bounds))
                {
                    SendAlert();
                    break;
                }
            }
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other);
            _checkableItems.Add(other);
        }

        private void OnTriggerExit(Collider other)
        {
            _checkableItems.Remove(other);
        }

        #region Implements IAlerter

        public void SendAlert()
        {
            var ownable = GetComponent<IOwnable>();
            if(ownable != null)
            {
                var owner = ownable.GetOwner();
                if (owner != null)
                {
                    var alertable = owner.GetComponent<IAlertable>();
                    if(alertable != null)
                    {
                        alertable.Alert();
                    }
                }
            }
        }

        #endregion
    }

}
