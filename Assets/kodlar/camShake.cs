using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class camShake : MonoBehaviour
{
    public static camShake Instance { get; private set; }
    private CinemachineVirtualCamera cinemachineVirtualCamera;
    private float shakeTimer;
    private float rotateTimer;
    public Animator anim;
    private void Awake()
    {
        Instance = this;
        cinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        anim = GetComponent<Animator>();

    }
    public void shakeCamera(float intens,float time)
    {
        CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = intens;
        shakeTimer = time;


    }

   public void rotateCamera()
    {
        rotateTimer = 2.4f;
        anim.SetBool("sallaniyor", true);
        
        
        
        
    }


    private void Update()
    {
        if(shakeTimer > 0f)
        {
            shakeTimer -= Time.deltaTime;
            if (shakeTimer <= 0f)
            {
                CinemachineBasicMultiChannelPerlin cinemachineBasicMultiChannelPerlin = cinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
                cinemachineBasicMultiChannelPerlin.m_AmplitudeGain = 0f;

            }
        }
        if(rotateTimer > 0f)
        {
            rotateTimer -= Time.deltaTime;
            if(rotateTimer <= 0f)
            {
                anim.SetBool("sallaniyor", false);
            }
        }
    
    }


}
