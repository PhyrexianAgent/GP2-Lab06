using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Stamina))]
public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update

    [Header("Movement")]
    [SerializeField] private float speed = 1f;
    [SerializeField, Min(1)] private float runSpeedMultiplier = 1f;
    private Rigidbody rigidbody;
    private Stamina stamina;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        stamina = GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        bool sprintPressed = Input.GetKey(KeyCode.LeftShift);
        stamina.ChangeStaminaFromMovement(rigidbody.linearVelocity != Vector3.zero, sprintPressed);
        rigidbody.linearVelocity = new Vector3();
        movement.Normalize();
        rigidbody.AddRelativeForce(movement * speed * (sprintPressed ? runSpeedMultiplier : 1));
    }
}
