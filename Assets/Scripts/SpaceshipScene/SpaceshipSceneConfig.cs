using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "SpaceshipScene/Config")]
public class SpaceshipSceneConfig : ScriptableObject
{
    [SerializeField] int m_SpaceshipSpeed;
    public int SpaceshipSpeed => m_SpaceshipSpeed;

    [SerializeField] IslandData[] m_IslandPool;
    public IReadOnlyList<IslandData> IslandPool => m_IslandPool;

    [SerializeField] int m_NumOfIslands;
    public int NumOfIslands => m_NumOfIslands;

    [SerializeField] float m_DistanceBetweenIslands;
    public float DistanceBetweenIslands => m_DistanceBetweenIslands;

}