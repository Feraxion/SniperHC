using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public float slowdownFactor = 0.05f;
    public GameObject bulletPlayer;


    private void Update()
    {
        //Time.timeScale += (0.8f / slowdownLength) * Time.unscaledDeltaTime;
        //Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
        
        Debug.Log(Time.timeScale);
    }

    public void DoSlowMotion()
    {
        Time.timeScale = slowdownFactor;
        Time.fixedDeltaTime = Time.timeScale * .02f;


    }
    public void ReverseMotion()
    {
        Time.timeScale = 1f;
    }
}
