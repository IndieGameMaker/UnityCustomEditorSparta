using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable
{
    void TakeDamage(int damage);
}


public class PlayerStats : MonoBehaviour, IDamageable
{
    public int hp = 100;
    public int mp = 100;

    public bool isGodMode = false;

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
    }
}
