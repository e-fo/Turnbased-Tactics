using UnityEngine;

public class IslandData : MonoBehaviour
{
    [SerializeField] float m_IslandRadius;
    public float IslandRadius => m_IslandRadius;


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere( transform.position, m_IslandRadius );
    }
}