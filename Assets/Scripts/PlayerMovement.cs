using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody>();
    }

    private float Next_X_POS;
    private bool Left, Right;

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
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide"))
            animator.SetBool("Right", true);

            else 
                Right = true;

            if(m_rigidbody.position.x >= -3 && m_rigidbody.position.x < -1)
            {
                Next_X_POS = 0;
            }
            else if(m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_X_POS = 2;
            }
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide"))
            animator.SetBool("Left", true);

            else Left =  true;

            if(m_rigidbody.position.x >=  1 && m_rigidbody.position.x < 3)
            {
                Next_X_POS = 0;
            }
            else if(m_rigidbody.position.x >= -1 && m_rigidbody.position.x < 1)
            {
                Next_X_POS = -2;
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
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(1, 0, 1.5f) * animator.deltaPosition.magnitude);
            else
                animator.SetBool("Right", false);
        }

        else if (animator.GetBool("Left"))
        { 
            if(GetComponent<Rigidbody>().position.x > Next_X_POS)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(-1, 0, 1.5f) * animator.deltaPosition.magnitude);
            else
                animator.SetBool("Left", false);
        }
        else
        {
            GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + Vector3.forward * animator.deltaPosition.magnitude);    
        }

        if(Left)
        {
            if(GetComponent<Rigidbody>().position.x > Next_X_POS)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(-1, 0, 0) * animator.deltaPosition.magnitude);
            else
                Left = false;
        }
        if(Right)
        {
            if(GetComponent<Rigidbody>().position.x < Next_X_POS)
                GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + new Vector3(1, 0, 0) * animator.deltaPosition.magnitude);
            else
                Right = false;
        }
        
    }
}