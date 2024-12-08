using System;
using UnityEngine;
using UnityEngine.EventSystems;

[Serializable]
public enum ObstacleDIrectionEnum
{
    Slash, ReverseSlash
}

public class Mirror : Obstacle
{
    public ObstacleType obstacleType = ObstacleType.Mirror;
    public ObstacleDIrectionEnum ObstacleDIrection { get; set; } = ObstacleDIrectionEnum.Slash;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            DIrectionChangeRight();

        if (Input.GetKeyDown(KeyCode.Q))
            DIrectionChangeLeft();
    }

    public override void DIrectionChangeLeft()
    {
        base.DIrectionChangeLeft();
        ObstacleDIrection = ObstacleDIrection == ObstacleDIrectionEnum.Slash ? ObstacleDIrectionEnum.ReverseSlash : ObstacleDIrectionEnum.Slash;
        Debug.Log(ObstacleDIrection);
    }

    public override void DIrectionChangeRight()
    {
        base.DIrectionChangeRight();
        ObstacleDIrection = ObstacleDIrection == ObstacleDIrectionEnum.Slash ? ObstacleDIrectionEnum.ReverseSlash : ObstacleDIrectionEnum.Slash;
        Debug.Log(ObstacleDIrection);
    }

    public override void LightConversion(LightObj lightObj, Vector2 direction)
    {
        base.LightConversion(lightObj, direction);

        if (ObstacleDIrection == ObstacleDIrectionEnum.Slash && direction == Vector2.right)
        {
            lightObj.Direction = Vector2.up;
        }
        else if (ObstacleDIrection == ObstacleDIrectionEnum.Slash && direction == Vector2.left)
        {
            lightObj.Direction = Vector2.down;
        }
        else if (ObstacleDIrection == ObstacleDIrectionEnum.Slash && direction == Vector2.down)
        {
            lightObj.Direction = Vector2.left;
        }
        else if (ObstacleDIrection == ObstacleDIrectionEnum.Slash && direction == Vector2.up)
        {
            lightObj.Direction = Vector2.right;
        }


        if (ObstacleDIrection == ObstacleDIrectionEnum.ReverseSlash && direction == Vector2.right)
        {
            lightObj.Direction = Vector2.down;
        }
        else if (ObstacleDIrection == ObstacleDIrectionEnum.ReverseSlash && direction == Vector2.left)
        {
            lightObj.Direction = Vector2.up;
        }
        else if (ObstacleDIrection == ObstacleDIrectionEnum.ReverseSlash && direction == Vector2.down)
        {
            lightObj.Direction = Vector2.right;
        }
        else if (ObstacleDIrection == ObstacleDIrectionEnum.ReverseSlash && direction == Vector2.up)
        {
            lightObj.Direction = Vector2.left;
        }
    }

}
