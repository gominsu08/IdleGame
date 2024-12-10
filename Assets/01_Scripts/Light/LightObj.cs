using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightObj : MonoBehaviour
{
    public UnityEvent OnGameOverEvent;

    private LightDirectionSO _lightData;
    private TrailRenderer _lightSource;

    public float speed = 5;
    private Vector2 _direction;
    public Vector2 Direction
    {
        get
        {
            return _direction;
        }
        set
        {
            _direction = value.normalized;
        }
    }

    public void Initalized(LightDirectionSO lightData)
    {
        _lightSource = GetComponent<TrailRenderer>();
        _lightData = lightData;
        Direction = _lightData.direction;
    }

    private void Update()
    {
        if (Direction == Vector2.zero) return;

        transform.position += (Vector3)Direction * Time.deltaTime * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<IObstacle>(out IObstacle iObstacle))
        {
            iObstacle.LightConversion(this, Direction);
        }

        if (collision.gameObject.layer == LayerMask.NameToLayer("Wall"))
        {
            Debug.Log("GameOver");
            OnGameOverEvent?.Invoke();
            Direction = Vector2.zero;
            Destroy(this);
        }
    }

}
