using UnityEngine;
using System.Collections;

public class Obstacle : LogicObject
{
    void Initialize()
    {
        _destroyWhenCollide = false;
        _isObstacle = true;
    }
}
