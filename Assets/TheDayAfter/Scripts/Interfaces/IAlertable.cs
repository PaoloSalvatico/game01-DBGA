using UnityEngine;

namespace TheDayAfter.Interfaces
{
    public interface IAlertable
    {
        void Alert(int warningLevel = 0, Transform target = null);
    }

}
