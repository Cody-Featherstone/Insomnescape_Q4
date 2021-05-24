using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public GameObject Player;
    public SpriteRenderer SR;
    public ParticleSystem PS;

    // Start is called before the first frame update
    void Start()
    {
        SR = Player.GetComponent<SpriteRenderer>();
        PS = Player.GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        
        if (collision.gameObject.name == "Player" && Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(collision.gameObject.name);
            SR.enabled = false;
            PS.Play();
            //collision.gameObject.SetActive(true);
            
        }
    }






   /* private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player" && Input.GetKeyUp(KeyCode.Space))
        {
            SR.enabled = false;
            //collision.gameObject.SetActive(true);
        }


    }*/

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player" )
        {

            SR.enabled = true;
            //collision.gameObject.SetActive(true);




        }
    }
}
