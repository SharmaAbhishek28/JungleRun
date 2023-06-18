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

    private float Next_X_POS=0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            animator.SetBool("Run", true);
        }

        else if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("Slide", true);
        }

        else if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("Jump", true);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("Right", true);
            if(GetComponent<Rigidbody>().position.x >= - 3.5f && GetComponent<Rigidbody>().position.x < -1.5f)
            {
                Next_X_POS = 0;
            }
            else if(GetComponent<Rigidbody>().position.x >= - 1.5f && GetComponent<Rigidbody>().position.x < 1.5f)
            {
                Next_X_POS = 3.5f;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("Left", true);

            if(GetComponent<Rigidbody>().position.x >=  1.5f && GetComponent<Rigidbody>().position.x < 4.5f)
            {
                Next_X_POS = 0;
            }
            else if(GetComponent<Rigidbody>().position.x >= - 1.5f && GetComponent<Rigidbody>().position.x < 1.5f)
            {
                Next_X_POS = -3.5f;
            }
        }
    }

    void ToggleOff(string Name)
    {
        animator.SetBool(Name, false);
        isJumpDown = false;
    }

    private bool isJumpDown = false;
    
    void JumpDown()
    {
        isJumpDown = true;
    }


    private void OnAnimatorMove()
    {
        if (animator.GetBool("Jump"))
        {
            if(isJumpDown)
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(0, 0, 2) * animator.deltaPosition.magnitude);
            else
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(0, 1.5f, 2) * animator.deltaPosition.magnitude);    
        }
        else if (animator.GetBool("Right"))
        { 
            if(GetComponent<Rigidbody>().position.x < Next_X_POS)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.right * animator.deltaPosition.magnitude);
            else
                animator.SetBool("Right", false);
        }

        else if (animator.GetBool("Left"))
        { 
            if(GetComponent<Rigidbody>().position.x > Next_X_POS)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.left * animator.deltaPosition.magnitude);
            else
                animator.SetBool("Left", false);
        }
        else
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * animator.deltaPosition.magnitude);    
        }
        
    }
}