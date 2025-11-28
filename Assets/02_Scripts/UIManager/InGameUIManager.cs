using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIManager : MonoBehaviour
{
    [SerializeField] private Image hpBar;
    [SerializeField] private HealthEventSO healthEventSO;

    private void OnEnable()
    {
        healthEventSO.Subscribe(OnHpChanged);
    }

    private void OnDisable()
    {
        healthEventSO.Unsubscribe(OnHpChanged);
    }

    // 이벤트를 수신했을 때 호출할 함수
    private void OnHpChanged(int hp)
    {
        hpBar.fillAmount = hp / 100.0f;
    }
}
