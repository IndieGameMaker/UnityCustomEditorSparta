using System;
using UnityEngine;

// Event Channel
[CreateAssetMenu(fileName = "HealthEventSO", menuName = "EventBus/HealthEventSO")]
public class HealthEventSO : ScriptableObject
{
    // 구독자를 저장할 리스너
    private event Action<int> listeners;

    // 구독자 추가 메소드
    public void Subscribe(Action<int> listener)
    {
        listeners += listener;
    }

    // 구독자 해지 메소드
    public void Unsubscribe(Action<int> listener) { listeners -= listener; }

    // 이벤트 발생 요청 메소드
    public void Raise(int hp)
    {
        listeners?.Invoke(hp);
    }
}
