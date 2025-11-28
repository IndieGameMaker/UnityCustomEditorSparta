using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private HealthEventSO healthEventSO;
    
    public Transform player;

    private void OnEnable()
    {
        healthEventSO.Subscribe(OnPlayerDamaged);
    }

    private void OnDisable()
    {
        healthEventSO.Unsubscribe(OnPlayerDamaged);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void OnPlayerDamaged(int hp)
    {
        if (hp <= 0)
        {
            Debug.Log("게임 오버");
        }
    }
    
    public void SpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2 pos2D = Random.insideUnitCircle.normalized * Random.Range(10.0f, 20.0f);
            Vector3 pos3D = new Vector3(pos2D.x, 0, pos2D.y);


            if (Application.isPlaying)
            {
                Quaternion rot = Quaternion.LookRotation(player.position - pos3D);
                Instantiate(enemyPrefab, pos3D, rot);
            }
            else
            {
                player = GameObject.FindGameObjectWithTag("Player").transform;
                Quaternion rot = Quaternion.LookRotation(player.position - pos3D);
                Instantiate(enemyPrefab, pos3D, rot);
            }
        }
    }
}