using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Run", true);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Slide", true);
        }
    }

    void ToggleOff(string Name)
    {
        animator.SetBool("Slide", false);
    }

    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + Vector3.forward * animator.deltaPosition.magnitude);
    }
}
