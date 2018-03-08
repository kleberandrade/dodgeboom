using UnityEngine;

public class FloorTear : MonoBehaviour
{
    public string m_Tag = "Player";

    public float m_DurabilityMaxTime = 5.0f;

    private float m_DurabilityTime;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag(m_Tag))
        {
            m_DurabilityTime += Time.deltaTime;
            if (m_DurabilityTime >= m_DurabilityMaxTime)
            {
                Destroy();
            }
        }
    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void Restore()
    {

    }
}
