
using UnityEngine;

public class Cooldowns { 

    float startWaitTime = 0;
    float duration = 0;

    public Cooldowns(float duration)
    {
        this.duration = duration;
    }

    public bool Wait()
    {
        float nextAvailableTime = startWaitTime + duration;

        if (Time.time > nextAvailableTime)
        {
            startWaitTime = Time.time;
            return true;
        }

        return false;
    }
}