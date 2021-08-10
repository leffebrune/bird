using UnityEngine;
using System.Collections;

public class Mailbox : LogicObject
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    void Initialize()
    {
       _destroyWhenCollide = false;
       _isObstacle = false;
       _animator.SetBool("closed", false);
    }

    void OnTriggered(Player b)
    {
        if (b == null)
            return;

        b.Score += 200;

        _animator.SetBool("closed", true);
    }
}
