using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class DontDestroy : MonoBehaviour
{
    AudioSource src = null;

    void Awake()
    {
        src = GetComponent<AudioSource>();
        src.time = PlayerPrefs.GetFloat("SongPoint");
    }

    void OnDestroy()
    {
        PlayerPrefs.SetFloat("SongPoint", src.time);
    }
}