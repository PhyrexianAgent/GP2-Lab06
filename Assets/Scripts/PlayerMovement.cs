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
    private bool waitingForRecharge = false;
    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        stamina = GetComponent<Stamina>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (waitingForRecharge) waitingForRecharge = !stamina.IsFull();
        bool running = Input.GetKey(KeyCode.LeftShift) && stamina.CanRun() && !waitingForRecharge;
        stamina.ChangeStaminaFromMovement(rigidbody.linearVelocity != Vector3.zero, running);
        if (!waitingForRecharge) waitingForRecharge = !stamina.CanRun();
        rigidbody.linearVelocity = new Vector3();
        movement.Normalize();
        rigidbody.AddRelativeForce(movement * speed * (running ? runSpeedMultiplier : 1));
    }
}
