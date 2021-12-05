using UnityEngine;

namespace TheDayAfter.Interfaces
{
    public interface IOwnable
    {
        void SetOwner(GameObject gameObject);
        GameObject GetOwner();
    }

}
