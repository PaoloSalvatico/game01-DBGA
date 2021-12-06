using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheDayAfter.Interfaces;

namespace TheDayAfter.Enemy
{
    public class AdvancedDroneLockable : MonoBehaviour, ITaggable
    {
        public EnemyTags[] tags;
        public bool HasTag(string TagName)
        {
            tags[0].ToString();
            return true;
        }

        public bool HasTags(string[] TagNames)
        {
            throw new System.NotImplementedException();
        }

        public enum EnemyTags
        {
            BaseEnemy,
            AdvancedEnemy,
            MiniBoss,
            Boss,
        }
    }
}
