using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static IStateMachine MainStateMachine { get; private set; }
    private static GameManager Instance;

    private void Awake()
    {
        if( null == Instance ) 
        {
            Instance = this;

            MainStateMachine = new StateMachine( new InitState() );
            DontDestroyOnLoad( this.gameObject );
        }
        else
        {
            if( this  != Instance )
            {
                Destroy( this.gameObject );
            }
        }
    }

    private void Start()
    {
        MainStateMachine.OnStart();
    }

    private void Update()
    {
        MainStateMachine.OnUpdate();
    }

    private void OnDestroy() 
    {
        MainStateMachine.OnFinished();
    }
}