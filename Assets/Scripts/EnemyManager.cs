using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private Transform[] positions;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnTime;
    
    private GameManager _gameManager;


    private void Start()
    {
        _gameManager = GetComponent<GameManager>();
        InvokeRepeating("CreateEnemy", 1, spawnTime);
    }

    void CreateEnemy()
    {
        if (_gameManager.gameOver || _gameManager.gameWin) return;
        
        int index = Random.Range(0, positions.Length);
        Instantiate(enemyPrefab, positions[index]);
    }
}
