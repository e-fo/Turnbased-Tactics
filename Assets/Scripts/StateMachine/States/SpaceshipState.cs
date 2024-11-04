using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpaceshipState : IState
{
    bool m_Initialized = false;
    private SpaceshipSceneData m_SpaceshipSceneData;
    private SpaceshipData m_SpaceshipDataCache;
    private SpaceshipSceneConfig m_SpaceshipSceneConfigCache;

    public async void OnEnter()
    {
        //loading spaceship scene
        {
            bool isLoaded = false;
            void setFlag (Scene scene, LoadSceneMode mode) => isLoaded = true;
            SceneManager.sceneLoaded += setFlag;
            SceneManager.LoadScene( 1 );
            while ( !isLoaded )
            {
                await Task.Delay( 100 );
            }
            SceneManager.sceneLoaded -= setFlag;
        }

        m_SpaceshipSceneData = GameObject.FindObjectOfType<SpaceshipSceneData>();
        m_SpaceshipDataCache = m_SpaceshipSceneData.SpaceshipData;
        m_SpaceshipSceneConfigCache = m_SpaceshipSceneData.Config;
        m_Initialized = true;
    }

    public void OnUpdate()
    {
        if (m_Initialized)
        {
            if( Input.GetKeyDown( KeyCode.Space ) )
            {
                m_SpaceshipDataCache.IsMoving = !m_SpaceshipDataCache.IsMoving;
            }

            if( m_SpaceshipDataCache.IsMoving )
            {
                Vector3 moveVector =  m_SpaceshipDataCache.transform.forward * m_SpaceshipSceneConfigCache.SpaceshipSpeed * Time.deltaTime;
                m_SpaceshipDataCache.transform.Translate( moveVector );
                Camera.main.transform.Translate( moveVector, Space.World );
            }
        }
    }

    public void OnExit()
    {
        
    }
}