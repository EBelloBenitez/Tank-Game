using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private Slider slider;
    
    private int _currentHealth;
    
    private GameManager _gameManager;
    private Collider _coll;
    private AudioSource _audioSource;

    void Awake()
    {
        _currentHealth = maxHealth;
        slider.maxValue = maxHealth;
        slider.value = maxHealth;

        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _coll = GetComponent<Collider>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("ShellEnemy"))
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
            Death();
        }
    }

    private void Death()
    {
        if (_gameManager.gameOver) return;
        _gameManager.GameOver();
    }

    public void  TurnOffPlayer()
    {
        // Detach camera
        Camera.main.transform.SetParent(null);
        
        // Deactivate player components
        _coll.enabled = false;
        _audioSource.enabled = false;
    }
}
