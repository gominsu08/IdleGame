
using UnityEngine;

public interface IObstacle
{
    public bool IsCanRotation { get; set; }
    public void LightConversion(LightObj lightObj , Vector2 direction);
    public void DIrectionChangeRight();
    public void DIrectionChangeLeft();

}
