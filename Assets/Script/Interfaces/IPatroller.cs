using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TheFirstGame.Interfaces
{
    public interface IPatroller
    {
        void StartPatrolling();

        void EndPatrolling();

        void Recall();

        bool IsPatrolling();
    }


}
