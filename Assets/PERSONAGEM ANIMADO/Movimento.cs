using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController charac;
    private Animator an;
    private Vector3 inputs;

    public Rigidbody rb;
    public float JumpForce;

    public LayerMask Layermask;
    public bool IsGrounded;
    public float GroundCheckSize;
    public Vector3 GroundCheckPosition;


    private float vel = 5f;

    // Start is called before the first frame update
    void Start()
    {
        charac = GetComponent<CharacterController>();
        an = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charac.Move(inputs * Time.deltaTime * vel);

        if(inputs != Vector3.zero)
        {
            an.SetBool("Walk", true);
            transform.forward = inputs;
        }
        else
        {
            an.SetBool("Walk", false);
        }

        var groundCheck = Physics.OverlapSphere(transform.position + GroundCheckPosition, GroundCheckSize, Layermask);
        if(groundCheck.Length !=0)
        {
            IsGrounded = true;
        }
        else
        {
            IsGrounded = false;
             
        }
       
    an.SetBool("Jump", !IsGrounded);
        if(IsGrounded == true && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(transform.up * JumpForce, ForceMode.Impulse);
        }
    }
    
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + GroundCheckPosition, GroundCheckSize);
    }
}
