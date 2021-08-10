using UnityEngine;
using System.Collections.Generic;
using System;

public abstract class LogicObject : MonoBehaviour
{
    protected bool _destroyWhenCollide;
    protected bool _isObstacle;
    
    public bool destroyWhenCollide { get { return _destroyWhenCollide; } }
    public bool isObstacle { get { return _isObstacle; } }


    void Initialize()
    {
        _destroyWhenCollide = false;
        _isObstacle = true;
    }
}
