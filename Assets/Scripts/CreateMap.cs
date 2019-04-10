using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject[] m_MapObjectPrefab;

    [SerializeField]
    private float m_ObjectSize;

    [SerializeField]
    private int m_MaxDepth;

    [SerializeField]
    private int m_MaxLength;

    [SerializeField]
    private float m_MaxHeight;

    public void Start()
    {
        for (int j = 0; j < m_MaxLength; j++)
        {
            for (int i = 0; i < m_MaxDepth; i++)
            {
                int r = Random.Range(0, m_MapObjectPrefab.Length);
                GameObject go = Instantiate(m_MapObjectPrefab[r]);
                go.transform.parent = transform;

                float x = (j * m_ObjectSize) - (m_MaxLength * m_ObjectSize) * 0.5f;
                float y = Random.Range(-m_MaxHeight, m_MaxHeight);
                float z = (i * m_ObjectSize) - (m_MaxDepth * m_ObjectSize) * 0.5f;

                go.transform.position = new Vector3(x,y,z);
            }
        }
    }
}
