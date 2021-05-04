using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform[] moveSpots;
    public Vector2 currentSpot;
    public float speed;
    public float startWaitTime;
    private float waitTime;

    
    public float minX;
    public float maxX;
    public float minY;
    public float maxY;

    //Rigidbody2D rb;



    public float distance;
    public float rotationSpeed;

    public LineRenderer lineOfSight;
    public Gradient redColor;
    public Gradient greenColor;


    // Start is called before the first frame update
    void Start()
    {
        waitTime = startWaitTime;
        currentSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        //Spotting Mechanic
        Physics2D.queriesStartInColliders = false;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, currentSpot, speed * Time.deltaTime);

        if(Vector2.Distance(transform.position, currentSpot) < 0.2f)
        {
            if(waitTime<= 0)
            {
                
                waitTime = startWaitTime;
                currentSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
        //the Rotation and detection of the player and LOS
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);


        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            lineOfSight.SetPosition(1, hitInfo.point);
            lineOfSight.colorGradient = redColor;

            if (hitInfo.collider.CompareTag("Player"))
            {
                //Destroy(hitInfo.collider.gameObject);
            }

        }
        else
        {

            Debug.DrawLine(transform.position, transform.position + transform.right * distance, Color.green);
            lineOfSight.SetPosition(1, transform.position + transform.right * distance);
            lineOfSight.colorGradient = greenColor;
        }

        lineOfSight.SetPosition(0, transform.position);
    }
   
}
