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

}
