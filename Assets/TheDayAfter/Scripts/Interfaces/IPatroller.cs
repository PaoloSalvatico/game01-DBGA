
namespace TheDayAfter.Interfaces
{
    public interface IPatroller
    {
        void StartPatrolling();
        void EndPatrolling();
        void Recall();
        bool IsPatrolling();
        bool IsRecalling();
    }

}
