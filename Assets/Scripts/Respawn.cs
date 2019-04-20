using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private bool m_UseFixedRespawnPoint;

    [SerializeField]
    private Transform[] m_FixedRespawnPoints;

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
