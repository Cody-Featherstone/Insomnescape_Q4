using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour

    
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject musicObj = GameObject.Find(Music);
        Destroy(Music);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
