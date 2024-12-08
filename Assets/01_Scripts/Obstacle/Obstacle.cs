using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ObstacleType
{
    Mirror,
    Lens,
    Prism,
    Portal,
    Filter
}

public abstract class Obstacle : MonoBehaviour, IObstacle
{
    public bool IsCanRotation { get; set; } = true;

    public ObstacleData obstacleData { get; set; }

    public virtual void DIrectionChangeLeft()
    {
        if (!IsCanRotation) return;
    }

    public virtual void DIrectionChangeRight()
    {
        if (!IsCanRotation) return;
    }

    public virtual void LightConversion(LightObj lightObj, Vector2 direction)
    {
        if(lightObj == null) return;
    }
}




