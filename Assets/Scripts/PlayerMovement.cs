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
    }

    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + Vector3.forward * animator.deltaPosition.magnitude);
    }
}
