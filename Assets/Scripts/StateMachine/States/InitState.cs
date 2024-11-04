using UnityEngine;

public class InitState : IState
{
    public void OnEnter()
    {
        Debug.Log("This is start of the game");
    }

    public void OnUpdate()
    {
        GameManager.MainStateMachine.SwitchState( new SpaceshipState() );
    }


    public void OnExit() {}
}