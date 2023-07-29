using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;
   public float speed = 10.0f;
   public float sidespeed = 12.0f;
   private bool isJumping;

   private Vector3 fp;   //First touch position
    private Vector3 lp;   //Last touch position
    private float dragDistance;  //minimum distance for a swipe to be registered
 
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        isJumping = false;
        dragDistance = Screen.height * 10 / 100; //dragDistance is 15% height of the screen
    }
 
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime,Space.World);//add constant force
        
        if (Input.touchCount == 1) // user is touching the screen with a single touch
        {
            Touch touch = Input.GetTouch(0); // get the touch
            if (touch.phase == TouchPhase.Began) //check for the first touch
            {
                fp = touch.position;
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved) // update the last position based on where they moved
            {
                lp = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended) //check if the finger is removed from the screen
            {
                lp = touch.position;  //last touch position. Ommitted if you use list
 
                //Check if drag distance is greater than 20% of the screen height
                if (Mathf.Abs(lp.x - fp.x) > dragDistance || Mathf.Abs(lp.y - fp.y) > dragDistance)
                {//It's a drag
                 //check if the drag is vertical or horizontal
                    if (Mathf.Abs(lp.x - fp.x) > Mathf.Abs(lp.y - fp.y))
                    {   //If the horizontal movement is greater than the vertical movement...
                        if ((lp.x > fp.x))  //If the movement was to the right)
                        {   //Right swipe
                            Debug.Log("Right Swipe");
                            //if(this.gameObject.transform.position.x > LevelBoundry.leftSide)
                           
                            transform.Translate(Vector3.right *sidespeed *Time.deltaTime);
                            


                        }
                        else
                        {   //Left swipe
                            Debug.Log("Left Swipe");
                            //if(this.gameObject.transform.position.x > LevelBoundry.RightSide)
                        
                            transform.Translate(Vector3.left *sidespeed *Time.deltaTime);

                        }
                    }
                    else
                    {   //the vertical movement is greater than the horizontal movement
                        if (lp.y > fp.y && isJumping == false)  //If the movement was up
                        {   //Up swipe
                            Debug.Log("Up Swipe");
                             rb.velocity = new Vector3(0, 7, 0);
                             isJumping = true;
                        }
                        else
                        {   //Down swipe
                            Debug.Log("Down Swipe");
                        }
                    }
                }
                else
                {   //It's a tap as the drag distance is less than 20% of the screen height
                    Debug.Log("Tap");
                }
            }
        }

    }
     
    private void OnCollisionEnter(Collision collision)
    {
        isJumping = false;
    }

}
 