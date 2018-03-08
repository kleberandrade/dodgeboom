using UnityEngine;

public class BoardGeneration : MonoBehaviour
{
    public GameObject[] m_FloorsPrefab;

    public int m_Size = 10;

    public float m_Height = 0.0f;

    public int m_Margin = 2;

    [Range(0.0f, 1.0f)]
    public float m_MarginChange = 0.2f;

	private void Start ()
    {
        Create();   
	}

    private void Create()
    {
        Vector3 offset = new Vector3(m_Size, 0.0f, m_Size) * 0.5f;

        for (int z = 0; z < m_Size; z++)
        {
            for (int x = 0; x < m_Size; x++)
            {
                if (z < m_Margin || m_Size - z <= m_Margin || x < m_Margin || m_Size - x <= m_Margin)
                {
                    if (Random.Range(0.0f, 1.0f) > m_MarginChange)
                        continue;
                }

                int selectedIndex = Random.Range(0, m_FloorsPrefab.Length);

                GameObject floor = Instantiate(m_FloorsPrefab[selectedIndex], transform);
                Collider collider = floor.GetComponent<Collider>();

                Vector3 bounds = collider.bounds.size * 0.5f;
                bounds.y = 0.0f;

                floor.transform.position = new Vector3(x, m_Height, z) - offset + bounds;
            }
        }
    }
}
