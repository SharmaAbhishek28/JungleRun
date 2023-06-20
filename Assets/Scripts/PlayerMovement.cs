using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Animator animator;
    private Rigidbody m_rigidbody;
    [SerializeField] private GameObject StartScreen;
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
    private Vector2 TouchBegan, TouchMove;
    private float DRAG_X, DRAG_Y;
    private bool CanDrag;
    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                CanDrag = true;
                TouchBegan = touch.position;
                TouchMove = Vector2.zero;
            }
            else  if (touch.phase == TouchPhase.Moved && CanDrag)
            {
                TouchMove = touch.position;

                DRAG_X = Mathf.Abs(TouchBegan.x - TouchMove.x);
                DRAG_Y = Mathf.Abs(TouchBegan.y - TouchMove.y);

                if (DRAG_Y > DRAG_X)
                {
                    //swipe up
                    if (TouchMove.y > TouchBegan.y)
                    {
                        CanDrag = false;
                        animator.SetBool("Jump", true);
                    }
                    //swipe down
                    else
                    {
                        CanDrag = false;
                        animator.SetBool("Slide", true);
                    }
                }
                else if (DRAG_X > DRAG_Y)
                {
                    //swipe RIGHT
                    if (TouchMove.x > TouchBegan.x)
                    {
                        CanDrag = false;
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
                    //swipe LEFT
                    else
                    {
                        CanDrag = false;
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
            }
        }

        if (animator.GetBool("Death"))
        {
            SceneManager.LoadScene("GAME_OVER");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartScreen.SetActive(false);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.CompareTag("Obstacle"))
        {
            animator.SetBool("Death", true);
        }
    }
}