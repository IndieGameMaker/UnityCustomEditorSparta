using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public interface IDamageable
{
    void TakeDamage(int damage);
}


public class PlayerStats : MonoBehaviour, IDamageable
{
    public int hp = 100;
    public int mp = 100;
    public bool isGodMode = false;

    private HealthEventSO healthEventSO;

    private void OnEnable()
    {
        Addressables.LoadAssetAsync<ScriptableObject>("HealthEventSO").Completed += (handle) =>
        {
            if (handle.Status == AsyncOperationStatus.Succeeded)
            {
                healthEventSO = handle.Result as HealthEventSO;
            }
        };
    }

    public void InitPlayerData()
    {
        hp = 100;
        mp = 100;
        isGodMode = false;
        Debug.Log("플레이어 데이터 초기화");
    }

    public void TakeDamage(int damage)
    {
        hp -= damage;
        healthEventSO.Raise(hp);
    }
}
