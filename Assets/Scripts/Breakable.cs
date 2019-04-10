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

    public void Awake()
    {
        m_Renderer = GetComponent<Renderer>();
    }

    public void Start()
    {
        ChangeColor(0.0f);
    }

    public void Update()
    {
        if (m_Overhead > 0)
        {
            m_DurabilityTime += Time.deltaTime;
            ChangeColor(m_DurabilityTime / m_Durability);
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