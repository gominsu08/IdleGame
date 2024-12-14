using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class ObstacleSettingPanelSetUp : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public event Action<bool> OnMoveObstacleSettingPanelEvent;
    private bool isCanBack;
    private bool isCanClick;
    private bool isCoolTime = true;

    private void Awake()
    {
        MoveOption[] moveOptions = GetComponentsInChildren<MoveOption>();
        foreach (MoveOption item in moveOptions)
        {
            OnMoveObstacleSettingPanelEvent += item.Move;
        }
    }

    private void OnDestroy()
    {
        OnMoveObstacleSettingPanelEvent = null;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && isCanClick && isCoolTime)
        {
            StartCoroutine(_5_TimeDelay());
            OnMoveObstacleSettingPanelEvent?.Invoke(isCanBack);
            isCanBack = !isCanBack;
        }
    }

    public IEnumerator _5_TimeDelay()
    {
        isCoolTime = false;
        yield return new WaitForSeconds(0.15f);
        isCoolTime = true;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isCanClick = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isCanClick = false;
    }
}
