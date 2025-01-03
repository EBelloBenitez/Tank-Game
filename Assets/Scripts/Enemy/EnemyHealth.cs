using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider slider;
    
    private int _currentHealth;
    
    private GameManager _gameManager;
    
    void Awake()
    {
        _currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;
        
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ShellPlayer"))
        {
            TakeDamage(collision.collider.GetComponent<Shell>().damageShell);
        }
    }
   
    private void TakeDamage(int damageAmount)
    {
        _currentHealth -= damageAmount;
        slider.value = _currentHealth;

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            _gameManager.AddEnemyUI();
        }
        
    }
    
    
}
