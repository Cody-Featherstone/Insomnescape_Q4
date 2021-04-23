using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    public float startWaitTime;
    private float waitTime;

    public Transform[] moveSpots;
    private int randomSpots;



    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        randomSpots = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpots].position, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, moveSpots[randomSpots].position) < 0.2f)
        {
            if(waitTime<= 0)
            {
                randomSpots = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }
}
