using UnityEngine;

namespace TheDayAfter.Interfaces
{
    public interface IAlerter
    {
        void SendAlert(Transform item = null);
    }

}
