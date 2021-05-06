using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolBehavior : StateMachineBehaviour
{
    public int Array;
    public float startWaitTime;
    private float waitTime;
    public float speed;
    public Transform[] moveSpots;
    
    private int randomSpots;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        moveSpots = animator.GetComponent<Enemy>().moveSpots;
        waitTime = startWaitTime;
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        Array++;
            animator.transform.position = Vector2.MoveTowards(animator.transform.position, moveSpots[Array].position, speed * Time.deltaTime);

            if (Vector2.Distance(animator.transform.position, moveSpots[Array].position) < 0.2f)
            {
                if (waitTime <= 0)
                {

                    waitTime = startWaitTime;
                Array++;
                }
                else
                {
                    waitTime -= Time.deltaTime;
                }
                if (Input.GetKeyDown(KeyCode.P))
                {
                animator.SetBool("isPatrolling", true);
                }
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    animator.SetBool("isFollowing", true);
                }
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
