using UnityEngine;
using System.Linq;
using System;
using System.Collections.Generic;

public class Rain : MonoBehaviour
{
    ParticleSystem ps;
    public int maxRate = 0;

    void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    void Update()
    {
        SetIntensity(Environment.Instance.RainIntensity);
    }
    
    public void SetIntensity(float i)
    {
        if (ps != null)
        {
            var em = ps.emission;
            var rate = em.rateOverTime;
            rate.constant = maxRate * i;

            em.rateOverTime = rate;
        }
    }
}
