using UnityEngine;

public class Breakable : MonoBehaviour
{
    [SerializeField]
    private Color m_StartColor;

    [SerializeField]
    private Color m_EndColor;

    private Renderer m_Renderer;

    [SerializeField]
    private float m_Durability = 5.0f;

    private float m_DurabilityTime;

    private int m_Overhead;

    [Header("Explosion")]
    [SerializeField]
    private GameObject m_ExplosionPartycleSystem;

    [SerializeField]
    private float m_Force = 1000.0f;

    [SerializeField]
    private float m_Radius = 10.0f;

    [SerializeField]
    private float m_UpForce = 600.0f;

    [SerializeField]
    private LayerMask m_ColliderMask;

    public void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void Start()
    {
        ChangeColor(0.0f);
    }

    public void Detonate()
    {
        Instantiate(m_ExplosionPartycleSystem, transform.position, Quaternion.identity);

        Collider[] colliders = Physics.OverlapSphere(transform.position, m_Radius, m_ColliderMask);
        foreach (Collider collider in colliders)
        {
            Debug.Log($"Collision with {collider.name}");

            Rigidbody body = collider.GetComponent<Rigidbody>();
            if (body)
            {
                body.AddExplosionForce(m_Force, transform.position, m_Radius, m_UpForce, ForceMode.VelocityChange);
            }
        }

        gameObject.SetActive(false);
    }

    public void Update()
    {
        if (m_Overhead > 0)
        {
            m_DurabilityTime += Time.deltaTime;
            ChangeColor(m_DurabilityTime / m_Durability);

            if (m_DurabilityTime >= m_Durability)
            {
                Detonate();
            }
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            m_Overhead++;
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            m_Overhead--;
        }
    }

    public void ChangeColor(float time)
    {
        Color color = Color.Lerp(m_StartColor, m_EndColor, time);
        m_Renderer.material.SetColor("_EdgeColor", color);
    }
}