using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody shellEnemyPrefab;
    [SerializeField] private Transform posShell;

    [SerializeField] private float timeBetweenAttacks,
                                   launchForce,
                                   factorLaunchForce;
    [SerializeField] private AudioSource audioSource;

    private AudioSource _audioSource;
    private float _timer;
    private Ray _ray;
    private RaycastHit _hit;
    private float _distance;
    
    void Start()
    {
    }
    
    void Update()
    {
        // Determine the raycast properties
        _ray.origin = transform.position;
        _ray.direction = transform.forward;
        
        // Determine the attack conditions
        _timer += Time.deltaTime;
        
        if (Physics.Raycast(_ray, out _hit))
        {
            if (_hit.collider.CompareTag("Player")  &&  _timer >= timeBetweenAttacks)
            {
                _distance = _hit.distance;
                _timer = 0;
                FireShell();
            }
        }
    }
    
    private void FireShell()
    {
        // Compute the launch force
        float launchForceFinal = launchForce * _distance * factorLaunchForce;
        // Create and launch shell clone
        Rigidbody shellClone = Instantiate(shellEnemyPrefab,posShell.position,posShell.rotation);
        shellClone.velocity = launchForceFinal * posShell.forward;
        audioSource.Play();
    }
    
    
}
