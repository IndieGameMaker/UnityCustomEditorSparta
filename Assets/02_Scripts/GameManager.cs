using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    public Transform player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;        
    }

    public void SpawnEnemy()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector2 pos2D = Random.insideUnitCircle.normalized * Random.Range(10.0f, 20.0f);
            Vector3 pos3D = new Vector3(pos2D.x, 0, pos2D.y);
            
            Quaternion rot = Quaternion.LookRotation(player.position - pos3D);
            Instantiate(enemyPrefab, pos3D, rot);
        }
    }
}
