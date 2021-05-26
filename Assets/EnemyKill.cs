using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyKill : MonoBehaviour
{
    public Transform Target;
    private float Distance;
    public GameObject Enemy;
    private float TimeStamp;
    private bool ClockIsTicking = false;
    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(Enemy.transform.position, Target.transform.position) <= 0.5f)
        {
            if (!ClockIsTicking)
            {
                TimeStamp = Time.time;
                ClockIsTicking = true;
            }
            else
            {
                if (Time.time - TimeStamp > 5)
                {
                    SceneManager.LoadScene("GameOver");
                }
            }


        }
        else
        {
            ClockIsTicking = false;
        }
    }
}
