using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class KeyPickUp : MonoBehaviour
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(GameManager.KeyCount == 5)
        {
            //switch scenes
            SceneManager.LoadScene("Credits");
            Debug.Log("YOU WIN!!");
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if (collision.gameObject.name == "Player")
        {
            GameManager.KeyCount++;
            gameObject.SetActive(false);
        }
    }
}
