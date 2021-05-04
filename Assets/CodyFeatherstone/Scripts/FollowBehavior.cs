using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowBehavior : StateMachineBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] moveSpot;
    

//Rigidbody2D rb;



    public float distance;
    public float rotationSpeed;

    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;

    private Transform playerPos;
    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.queriesStartInColliders = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
        
        
           
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
            lineOfSight.SetPosition(0, animator.transform.position);
        
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
