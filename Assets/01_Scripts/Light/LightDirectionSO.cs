using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Light/DirectionData")]
public class LightDirectionSO : ScriptableObject
{
    public Vector2 direction;
    public int stageNumber;
}
