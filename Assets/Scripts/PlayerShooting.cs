using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private Transform m_Hand;

    private Rigidbody m_Ball;

    [SerializeField]
    private float m_MinForce = 10.0f;

    [SerializeField]
    private float m_MaxForce = 50.0f;

    [SerializeField]
    private float m_TimeToMaxForce = 2.0f;

    public bool CanShoot => m_Hand.childCount > 0;

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
            m_Hand.DetachChildren();
            m_Ball.AddForce(m_Hand.forward * m_CurrentForce, ForceMode.Impulse);
        }
    }

    public void Pickup()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Ball"))
        {

        }
    }
}