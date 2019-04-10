using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField]
    private Rigidbody m_BulletPrefab;

    [SerializeField]
    private Transform m_BulletSpawn;

    [SerializeField]
    private float m_MinForce = 10.0f;

    [SerializeField]
    private float m_MaxForce = 50.0f;

    [SerializeField]
    private float m_TimeToMaxForce = 2.0f;

    private float m_ElapsedTime;

    private float m_CurrentForce;

    public void Update()
    {
        if (Input.GetButton("Fire1"))
        {
            m_CurrentForce = Mathf.Lerp(m_MinForce, m_MaxForce, m_ElapsedTime / m_TimeToMaxForce);
            m_ElapsedTime += Time.deltaTime;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            m_ElapsedTime = 0.0f;
            Rigidbody arrow = Instantiate<Rigidbody>(m_BulletPrefab, m_BulletSpawn.position, m_BulletSpawn.rotation);
            arrow.AddForce(m_BulletSpawn.forward * m_CurrentForce, ForceMode.Impulse);
        }
    }
}