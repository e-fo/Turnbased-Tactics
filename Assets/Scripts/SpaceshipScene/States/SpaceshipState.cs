using System.Collections.Generic;
using UnityEngine;

public class SpaceshipState : IState
{
    bool m_Initialized = false;
    private SpaceshipSceneData m_SpaceshipSceneData;
    private SpaceshipData m_SpaceshipDataCache;
    private SpaceshipSceneConfig m_SpaceshipSceneConfigCache;

    public async void OnEnter()
    {
        //loading spaceship scene
        await UnityEngineUtil.LoadSceneWithIndex(1);

        m_SpaceshipSceneData = GameObject.FindObjectOfType<SpaceshipSceneData>();
        m_SpaceshipDataCache = m_SpaceshipSceneData.SpaceshipData;
        m_SpaceshipSceneConfigCache = m_SpaceshipSceneData.Config;

        //generating islands
        {
            int numOfIslands = m_SpaceshipSceneConfigCache.NumOfIslands;
            IReadOnlyList<IslandData> pool = m_SpaceshipSceneConfigCache.IslandPool;
            float z = 0;
            IslandData[] generated = new IslandData[numOfIslands];

            Vector3 spaceshipPosition = new Vector3(m_SpaceshipDataCache.transform.position.x, m_SpaceshipDataCache.transform.position.y, 0);

            for (int i = 0; i < numOfIslands; ++i)
            {
                IslandData islandPrefab = pool[Random.Range(0, pool.Count)];

                generated[i] = Object.Instantiate(islandPrefab, new Vector3(spaceshipPosition.x, spaceshipPosition.y, z), Quaternion.identity, m_SpaceshipSceneData.IslandParent);

                z += m_SpaceshipSceneConfigCache.DistanceBetweenIslands;
            }

            m_SpaceshipSceneData.IslandList = generated;
        }

        m_Initialized = true;
    }

    public void OnUpdate()
    {
        if (m_Initialized)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                m_SpaceshipDataCache.IsMoving = !m_SpaceshipDataCache.IsMoving;
            }

            if (m_SpaceshipDataCache.IsMoving)
            {
                Vector3 moveVector = m_SpaceshipDataCache.transform.forward * m_SpaceshipSceneConfigCache.SpaceshipSpeed * Time.deltaTime;
                m_SpaceshipDataCache.transform.Translate(moveVector);
                Camera.main.transform.Translate(moveVector, Space.World);
            }
        }
    }

    public void OnExit()
    {

    }
}