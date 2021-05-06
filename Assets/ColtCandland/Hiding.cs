using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiding : MonoBehaviour
{
    public GameObject Player;
    public SpriteRenderer SR;


    // Start is called before the first frame update
    void Start()
    {
        SR = Player.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "MainCharacter")
        {
            SR.enabled = false;
            //collision.gameObject.SetActive(true);
        }


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "MainCharacter")
        {

            SR.enabled = true;
            //collision.gameObject.SetActive(true);

           


        }
    }
}
