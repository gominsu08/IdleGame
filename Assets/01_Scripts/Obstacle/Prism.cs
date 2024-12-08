using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prism : Obstacle
{
    [SerializeField] private LightObj _red_Trail, _blue_Trail, _green_Trail;
    [SerializeField] private LightDirectionSO _blueData, _greenData, _redData;

    public override void DIrectionChangeLeft()
    {
        base.DIrectionChangeLeft();
    }

    public override void DIrectionChangeRight()
    {
        base.DIrectionChangeRight();
    }

    public override void LightConversion(LightObj lightObj, Vector2 direction)
    {
        base.LightConversion(lightObj, direction);
        Destroy(lightObj);
        LightObj red = Instantiate(_red_Trail,transform.position,Quaternion.identity);
        LightObj blue = Instantiate(_blue_Trail, transform.position,Quaternion.identity);
        LightObj green = Instantiate(_green_Trail, transform.position,Quaternion.identity);

        red.Initalized(_redData);
        blue.Initalized(_blueData);
        green.Initalized(_greenData);

        blue.Direction = direction;

        if (direction == Vector2.up)
        {
            red.Direction = direction + new Vector2(1, 1);
            green.Direction = direction + new Vector2(-1, 1);
        } 
        else if (direction == Vector2.down)
        {
            red.Direction = direction + new Vector2(-1, -1);
            green.Direction = direction + new Vector2(1, -1);
        } 
        else if (direction == Vector2.left)
        {
            red.Direction = direction + new Vector2(-1, 1);
            green.Direction = direction + new Vector2(-1, -1);
        } 
        else if (direction == Vector2.right) 
        {
            red.Direction = direction + new Vector2(1, 1);
            green.Direction = direction + new Vector2(1, -1);
        }


        

        Destroy(this);
    }
}
