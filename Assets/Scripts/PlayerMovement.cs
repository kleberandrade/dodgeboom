using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public void Move(float horizontal, float vertical, float speed)
    {
        Vector3 movement = new Vector3(horizontal, 0.0f, vertical) * speed * Time.deltaTime;
        transform.Translate(movement, Space.World);
    }

    public void Turning(float horizontal, float vertical)
    {
        Vector3 direction = new Vector3(horizontal, 0.0f, vertical);

        if (direction.magnitude != 0.0f)
        {
            Quaternion angle = Quaternion.LookRotation(direction);
            transform.rotation = angle;
        }
    }
}