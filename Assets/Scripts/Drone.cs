using UnityEngine;
using System.Collections;

public class Drone : MonoBehaviour
{
    ParticleSystem ps;
    bool flashDone = false;

    void Awake()
    {
        ps = GetComponentInChildren<ParticleSystem>();
    }

    void Initialize()
    {
        flashDone = false;
    }

    IEnumerator Flash()
    {
        var so = GetComponent<StageObject>();
        if (so != null)
        {
            var speed = so.movingSpeed;
            so.movingSpeed = 0.0f;
            yield return new WaitForSeconds(2.0f);
            so.movingSpeed = speed;
            ps.Play();
        }
    }
    
    void Update()
    {
        if (!flashDone && (transform.position.x - Camera.main.transform.position.x) < -1.5f)
        {
            StartCoroutine(Flash());
            flashDone = true;
        }
    }
}
