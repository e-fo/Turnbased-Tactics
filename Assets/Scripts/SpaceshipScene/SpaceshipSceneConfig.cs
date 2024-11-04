using UnityEngine;

[CreateAssetMenu(menuName = "SpaceshipScene/Config")]
public class SpaceshipSceneConfig : ScriptableObject
{
    [SerializeField] int m_SpaceshipSpeed;
    public int SpaceshipSpeed => m_SpaceshipSpeed;
}