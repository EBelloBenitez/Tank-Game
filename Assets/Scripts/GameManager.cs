using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject panelGameOver, 
                                panelWin;
    [SerializeField] private int numDefeatedVictory;
    [SerializeField] private TextMeshProUGUI textUI;
    
    [HideInInspector] public bool gameOver, 
                                  gameWin;
    
    private int _numDefeated;
    private TankHealth _player;

    private void Awake()
    {
        gameOver = false;
        gameWin = false;
        _numDefeated = 0;
        textUI.text = $"Enemies down: {_numDefeated}";
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<TankHealth>();
    }

    public void AddEnemyUI()
    {
        _numDefeated++;
        textUI.text = $"Enemies down: {_numDefeated}";

        if (_numDefeated >= numDefeatedVictory)
            GameWin();
            
    }

    private void GameWin()
    {
        gameWin = true;
        textUI.enabled = false;
        panelWin.SetActive(true);
        _player.TurnOffPlayer();
    }
    public void GameOver()
    {
        gameOver = true;
        panelGameOver.SetActive(true);
        _player.TurnOffPlayer();
    }
    
}
