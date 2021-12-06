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
        public string lockableTag;
        public string[] lockableTags;


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
            ITaggable taggable = other.GetComponent<ITaggable>();
            if(taggable != null && taggable.HasTags(lockableTags))
            {
                Debug.Log(other);
                _checkableItems.Add(other);
            }           
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
