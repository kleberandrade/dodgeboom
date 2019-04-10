using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_Speed = 2.0f;

    private PlayerMovement m_MovementScript;

    public void Awake()
    {
        m_MovementScript = GetComponent<PlayerMovement>();
    }

    public void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_MovementScript.Move(horizontal, vertical, m_Speed);
        m_MovementScript.Turning(horizontal, vertical);
    }
}