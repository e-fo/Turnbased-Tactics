public interface IState
{
    public void OnEnter();
    public void OnUpdate();
    public void OnExit();
}

public interface IStateMachine
{
    public IState CurrentState { get; }
    public void SwitchState( IState to);
    public void OnStart();
    public void OnUpdate();
    public void OnFinished();
}

public class StateMachine : IStateMachine
{
    public StateMachine(IState init)
    {
        CurrentState = init;
    }

    public IState CurrentState {get; private set;}

    public void OnUpdate()
    {
        CurrentState.OnUpdate();
    }

    public void SwitchState( IState to )
    {
        CurrentState.OnExit();
        CurrentState = to;
        CurrentState.OnEnter();
    }

    public void OnStart()
    {
        CurrentState.OnEnter();
    }

    public void OnFinished() {}
}
