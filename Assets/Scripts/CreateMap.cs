using System.Collections;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    [SerializeField]
    private GameObject m_TilePrefab;

    [SerializeField]
    private float m_TileSize;

    [SerializeField]
    private int m_WorldLength;

    [SerializeField]
    private float m_TimeToSpawn;

    private Vector3 m_Position = Vector3.zero;

    private float m_Angle;

    public void Start()
    {
        m_Angle = 90.0f;
        StartCoroutine(CreateUlnaSpiral(0, m_WorldLength));
    }

    private IEnumerator CreateUlnaSpiral(int min, int max)
    {
        if (min > max)
        {
            yield return CreateTileLine(min - 1);
        }
        else
        {
            if (min == 0)
            {
                CreateTile(m_TilePrefab, Vector3.zero);
            }
            else
            {
                for (int j = 0; j < 2; j++)
                {
                    yield return CreateTileLine(min);
                }
            }

            StartCoroutine(CreateUlnaSpiral(min + 1, max));
        }
    }

    private IEnumerator CreateTileLine(int length)
    {
        m_Angle -= 90.0f;
        for (int i = 0; i < length; i++)
        {
            Vector3 direction = new Vector3(Mathf.Sin(m_Angle * Mathf.Deg2Rad), 0, Mathf.Cos(m_Angle * Mathf.Deg2Rad));
            m_Position += m_TileSize * direction;
            CreateTile(m_TilePrefab, m_Position);
            yield return new WaitForSeconds(m_TimeToSpawn);
        }
    }

    private void CreateTile(GameObject prefab, Vector3 position)
    {
        GameObject go = Instantiate(prefab, position, Quaternion.identity);
        go.transform.parent = transform;
    }
}
