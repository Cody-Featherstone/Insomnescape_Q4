using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour
{
    public FollowBehavior isFollowing;
    public int Array;
    public float startWaitTime;
    private float waitTime;
    public float speed;
    public Transform[] moveSpots;
    private Transform playerPos;
    public float distance;
    public float agroRange;

    private int randomSpots;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveSpots = animator.GetComponent<Enemy>().moveSpots;
        waitTime = startWaitTime;
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
            if (isFollowing == false)
            {
                //Array++;

                //Debug.Log("The value of Array is " + Array);
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, moveSpots[Array].position, speed * Time.deltaTime);

                if (Vector2.Distance(animator.transform.position, moveSpots[Array].position) < 0.2f)
                {
                    if (waitTime <= 0)
                    {

                        waitTime = startWaitTime;
                        Array++;
                        Array = Array % moveSpots.Length;
                    }
                    else
                    {
                        waitTime -= Time.deltaTime;

                    }

                }
            }
        if (playerPos.GetComponent<SpriteRenderer>().enabled)
        {
            if (Vector3.Distance(animator.transform.position, playerPos.position) < agroRange) //Agro range
            {  //rotate to look at the player
                animator.transform.LookAt(playerPos.position);
                animator.transform.Rotate(new Vector3(0, -90, 0), Space.Self);//correcting the original rotation
            }

            if (Vector3.Distance(animator.transform.position, playerPos.position) < agroRange) //Agro range
            {   //move towards the player
                animator.SetBool("IsFollowing", true);
                animator.SetBool("IsPatrolling", false);
                animator.transform.position = Vector2.MoveTowards(animator.transform.position, playerPos.position, speed * Time.deltaTime);
                if (Vector3.Distance(animator.transform.position, playerPos.position) > distance)
                {//move if distance from target is greater than distance
                    animator.transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
                    //animator.SetBool("IsFollowing", false);


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
