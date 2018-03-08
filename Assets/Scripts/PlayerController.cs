using UnityEngine;

[RequireComponent(typeof(CharacterMovement))]
[RequireComponent(typeof(CharacterShooter))]
public class PlayerController : MonoBehaviour
{
    [Header("Joystick Number")]
    [Range(0, 4)]
    public int m_PlayerId;

    [Header("Shooter")]
    public GameObject m_BallPrefab;

    public float m_Force;

    private CharacterShooter m_ShooterScript;

    private CharacterMovement m_MovementScript;

    private float m_HorizontalMove;
    private float m_VerticalMove;

    private float m_HorizontalTurn;
    private float m_VerticalTurn;

    private bool m_CanShoot;

    private void Awake()
    {
        m_ShooterScript = GetComponent<CharacterShooter>();
        m_MovementScript = GetComponent<CharacterMovement>();
    }

    private void Update()
    {
        m_HorizontalMove = Input.GetAxis("Horizontal");
        m_VerticalMove = Input.GetAxis("Vertical");

        if (m_CanShoot)
        {
            m_CanShoot = false;
            m_ShooterScript.Shooter(m_BallPrefab, m_Force);
        }

        m_MovementScript.Move(m_HorizontalMove, m_VerticalMove);
        m_MovementScript.Turning(m_HorizontalMove, m_VerticalMove);
    }
}
