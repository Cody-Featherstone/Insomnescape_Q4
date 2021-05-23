using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour
{
    
    public float speed;
    public float startWaitTime;
    //private float waitTime;
    private GameObject Enemy;
    //public Transform[] moveSpot;

    SpriteRenderer SR; 

    public float agroRange;
    //Rigidbody2D rb;



    public float distance;
    //public float rotationSpeed;

    //public LineRenderer lineOfSight;
    //public Gradient redColor;
    //public Gradient greenColor;

    private Transform playerPos;
    private Vector2 VelVec;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.queriesStartInColliders = false;
        SR = animator.GetComponent<SpriteRenderer>();
        Enemy = animator.gameObject;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("Horizontal", VelVec.x);
        animator.SetFloat("Vertical", VelVec.y);
        if (playerPos.GetComponent<SpriteRenderer>().enabled)
        {
            /* if (Vector3.Distance(animator.transform.position, playerPos.position) < agroRange) //Agro range
         {  //rotate to look at the player
             //animator.transform.LookAt(playerPos.position);
             //animator.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
         }*/
            

            if (Vector3.Distance(animator.transform.position, playerPos.position) < agroRange) //Agro range
        {   //move towards the player
            animator.SetBool("IsFollowing", true);
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
                VelVec = playerPos.position - animator.transform.position;
                if (Vector3.Distance(animator.transform.position, playerPos.position) > distance)
            {//move if distance from target is greater than distance
                animator.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                //animator.SetBool("IsFollowing", false);
                //animator.SetBool("IsPatrolling", true);

            }

        }
        else
        {
            animator.SetBool("IsFollowing", false);
                 animator.SetBool("IsPatrolling", true);
        }
        }
        else
        {
            animator.SetBool("IsPatrolling", true);
            animator.SetBool("IsFollowing", false);
        }
        //animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        /*
        
           
            if (Vector2.Distance(animator.transform.position, playerPos.position) < 0.2f)
            {
               
            }
            //the Rotation and detection of the player and LOS
            animator.transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


            RaycastHit2D hitInfo = Physics2D.Raycast(animator.transform.position, animator.transform.right, distance);
            if (hitInfo.collider != null)
            {
                Debug.DrawLine(animator.transform.position, hitInfo.point, Color.red);
                lineOfSight.SetPosition(1, hitInfo.point);
                lineOfSight.colorGradient = redColor;

                if (hitInfo.collider.CompareTag("Player"))
                {
                    animator.SetBool("IsFollowing", false);
                    animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
                }

            }
            else
            {

                Debug.DrawLine(animator.transform.position, animator.transform.position + animator.transform.right * distance, Color.green);
                lineOfSight.SetPosition(1, animator.transform.position + animator.transform.right * distance);
                lineOfSight.colorGradient = greenColor;
            }
            //
            lineOfSight.SetPosition(0, animator.transform.position);*/

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
