using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimento : MonoBehaviour
{
    private CharacterController charac;
    private Animator an;
    private Vector3 inputs;

    private float vel = 2f;

    // Start is called before the first frame update
    void Start()
    {
        charac = GetComponent<CharacterController>();
        an = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        inputs.Set(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        charac.Move(inputs * Time.deltaTime * vel);

        if(inputs != Vector3.zero)
        {
            an.SetBool("Walk", true);
        }
        else
        {
            an.SetBool("Walk", false);
        }
    }
}
