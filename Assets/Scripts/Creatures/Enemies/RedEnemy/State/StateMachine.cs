namespace Enemies.RedEnemy
{
    public class StateMachine
    {
        public IState CurrentState { get; private set; }
        
        public void Init(IState startState)
        {
            startState.Enter();

            CurrentState = startState;
        }

        public void ChangeState(IState newState)
        {
            CurrentState.Exit();
            
            CurrentState = newState;

            CurrentState.Enter();
        }
    }
}
