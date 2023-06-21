using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;

    public static int score=0;
    
    private Rigidbody m_rigidbody;
    // Start is called before the first frame update

    public void StartGame()
    {

    }
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

            Debug.Log(score);
        if (animator.GetBool("Death"))
        {
            SceneManager.LoadScene("GAME_OVER");
        }
        if (Input.GetKeyDown(KeyCode.Space)||SwipeManager.tap)
=======
        if (Input.GetKeyDown(KeyCode.Space))

        {
            animator.SetBool("Run", true);
        }

        if (Input.GetKeyDown(KeyCode.S)||SwipeManager.swipeDown)
        {
            animator.SetBool("Slide", true);
            SwipeManager.swipeDown=false;
        }

        else if (Input.GetKeyDown(KeyCode.W)||SwipeManager.swipeUp)
        {
            Debug.Log("jump");
            animator.SetBool("Jump", true);
            SwipeManager.swipeUp=false;
        }
        else if (Input.GetKeyDown(KeyCode.D)|| SwipeManager.swipeRight)
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide")){
            animator.SetBool("Right", true);
            SwipeManager.swipeRight=false;
            }

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
        else if (Input.GetKeyDown(KeyCode.A)||SwipeManager.swipeLeft)
        {
            if (!animator.GetBool("Jump") && !animator.GetBool("Slide")){
            animator.SetBool("Left", true);
            SwipeManager.swipeLeft=false;
            }

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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            animator.SetBool("Death", true);
        }
    }
}