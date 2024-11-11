using System.Collections.Generic;
using UnityEngine;

public class SpaceshipSceneData : MonoBehaviour
{
    [SerializeField] SpaceshipSceneConfig m_Config;
    public SpaceshipSceneConfig Config => m_Config;

    [SerializeField] SpaceshipData m_SpaceshipData;
    public SpaceshipData SpaceshipData => m_SpaceshipData;

    [SerializeField] Transform m_IslandParent;
    public Transform IslandParent => m_IslandParent;
    
    public IReadOnlyList<IslandData> IslandList = null;
}