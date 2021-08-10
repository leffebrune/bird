using UnityEngine;
using System.Collections;

public class Smallbird : MonoBehaviour
{
    public float lifetime = 5.0f;

    Animator _animator;
    bool flying;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Initialize()
    {
        _animator.SetBool("Fly", false);
        flying = false;
    }

    IEnumerator FlyOut()
    {
        flying = true;
        yield return new WaitForSeconds(Random.Range(0.5f, 1.0f));
        _animator.SetBool("Fly", true);
        var startTime = Time.time;

        var xSpeed = Random.Range(2.5f, 5.5f);
        var ySpeed = Random.Range(1.5f, 3.0f);

        while (Time.time < startTime + lifetime)
        {
            gameObject.MoveXY(xSpeed * Time.deltaTime, ySpeed * Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }

        gameObject.SetPosXY(-100, 0);
    }
    
    void Update()
    {
        if (!flying && (transform.position.x < Camera.main.transform.position.x - 1.0f)) 
        {
            StartCoroutine(FlyOut());
        }
    }
}
