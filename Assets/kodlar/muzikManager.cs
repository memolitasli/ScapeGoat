using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;
public class muzikManager : MonoBehaviour
{
    public ses[] sesler;
    public void Awake()
    {
        foreach(ses s in sesler)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }
  
    public void playSound(string name)
    {
       ses s =  Array.Find(sesler, ses => ses.name == name);
        if(s == null)
        {
            return;
        }
        s.source.Play();
    }
    public void Start()
    {
        int bolumindeksi = SceneManager.GetActiveScene().buildIndex;
        if (bolumindeksi % 2 == 0 && bolumindeksi != 2)
        {
            playSound("theme1");
        }
        else if (bolumindeksi %2 == 1 && bolumindeksi != 5)
        {
            playSound("theme2");
        }
    }
}
