using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PergerakanPlayer : MonoBehaviour
{
    //Variabel bergerak
    [SerializeField] private float kecepatan = 7f;
    public float x;
    public float z;

    //Referensi
    private CharacterController controller;

    //Variabel loncat
    private float gravitasi = 20f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float groundDistance = 0.4f;
    [SerializeField] private LayerMask groundMask;
    public bool isGround;
    Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        bergerak();
        gravity();
    }

    private void bergerak()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
        Vector3 movement = transform.right * x + transform.forward * z;
        controller.Move(movement * kecepatan * Time.deltaTime);
    }

    private void gravity()
    {
        isGround = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        velocity.y -= gravitasi * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
