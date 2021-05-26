using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class DontDestroy : MonoBehaviour
{
    private static DontDestroy _instance = null;

    public static DontDestroy Instance
    {
        get { return _instance; }
    }
    
    public static int sceneToDestroyObj = 0; //the index of the scene you want the object to Destroy on in your Build Settings
    public static int sceneToDestroyObj1 = 3; //the index of the scene you want the object to Destroy on in your Build Settings

    void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(transform.root.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(transform.root.gameObject);

        SceneManager.activeSceneChanged += DestroyOnMenuScreen;
    }

    void DestroyOnMenuScreen(Scene oldScene, Scene newScene)
    {
        if (newScene.buildIndex == sceneToDestroyObj || newScene.buildIndex == sceneToDestroyObj1) //could compare Scene.name instead
        {
            Destroy(transform.root.gameObject); //change as appropriate
        }
    }

}