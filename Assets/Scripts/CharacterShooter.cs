using UnityEngine;

public class CharacterShooter : MonoBehaviour
{
    public Transform m_Point;

    public void Shooter(GameObject ball, float force)
    {
        GameObject go = Instantiate(ball, m_Point.position, m_Point.rotation);
        BallMovement movementScript = go.GetComponent<BallMovement>();
        movementScript.m_Force = force;
    }
}
