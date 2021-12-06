using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.Interfaces;

namespace TheDayAfter.Enemy
{
    public class DroneLockable : MonoBehaviour, ITaggable
    {
        public bool HasTag(string TagName)
        {
            return gameObject.CompareTag(TagName);
        }

        public bool HasTags(string[] TagNames)
        {
            foreach(var t in TagNames)
            {
                if (gameObject.CompareTag(t)) return true;
            }
            return false;
        }
    }

}
