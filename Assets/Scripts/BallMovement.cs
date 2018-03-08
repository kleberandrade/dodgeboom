using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float m_Force = 1.0f;

	private void Update ()
    {
        transform.Translate(Vector3.forward * m_Force * Time.deltaTime, Space.World);
	}
}
