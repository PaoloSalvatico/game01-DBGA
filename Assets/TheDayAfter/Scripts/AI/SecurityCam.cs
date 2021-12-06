using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.AI;

namespace TheDayAfter.Interfaces
{
    [RequireComponent(typeof(Animator))]
    public class SecurityCam : MonoBehaviour, IAlerter
    {
        protected List<Collider> _checkableItems = new List<Collider>();
        protected Animator _ai;

        public Camera cam;
        protected Plane[] _planes;
        public string lockableTag;
        public string[] lockableTags;

        private void Start()
        {
            _ai = GetComponent<Animator>();
        }


        protected virtual void Update()
        {
            _planes = GeometryUtility.CalculateFrustumPlanes(cam);
            Transform itemFound = null;
            foreach (var item in _checkableItems)
            {
                if(GeometryUtility.TestPlanesAABB(_planes, item.bounds))
                {
                    itemFound = item.transform;
                    break;
                }
            }
            var val = _ai.GetFloat(C.DRONE_PARAM_ALERT_LEVEL);
            if (itemFound != null)
            {
                val += Time.deltaTime;               
            }
            else
            {
                val -= Time.deltaTime;
            }
            val = Mathf.Clamp(0, 10, val);
            _ai.SetFloat(C.DRONE_PARAM_ALERT_LEVEL, val);

            _ai.SetBool(C.DRONE_PARAM_TARGET_LOCKED, itemFound != null);

            // Implemento la logica dell'alert
            if(itemFound != null)
            {
                SendAlert(itemFound);

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

        public void SendAlert(Transform item = null)
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
