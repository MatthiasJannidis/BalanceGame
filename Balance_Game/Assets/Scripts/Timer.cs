using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer
{
    float timer = .0f;
    float passedTime = .0f;
    public float PassedTime { get { return passedTime; } }
    public float GetTimer { get { return timer; } }
    public bool isDone { get { return passedTime > timer; } }

    public Timer(float timer) { this.timer = timer; }

    public void tick() 
    {
        passedTime += Time.deltaTime;
    }

    public void reset(float newTimer) 
    {
        timer = newTimer;
        passedTime = .0f;
    }

}
