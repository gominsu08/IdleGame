using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CreatLight : MonoBehaviour
{
    [SerializeField] private LightObj lightObj;
    [SerializeField] private LightDirectionSO _lightData;

    public void StartGame()
    {
        LightObj light = Instantiate(lightObj,transform.position,Quaternion.identity);
        light.Initalized(_lightData);
    }
}
