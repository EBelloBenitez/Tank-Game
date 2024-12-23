using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shell : MonoBehaviour
{
    [SerializeField] private ParticleSystem explosionShell;
    public int damageShell;

    private Rigidbody _rb;
    private AudioSource _audioSource;
    private Renderer _rend;
    private Collider _coll;
    
    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _rb = GetComponent<Rigidbody>();
        _coll = GetComponent<Collider>();
        _rend = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        RotateShell();
    }

    private void OnCollisionEnter(Collision other)
    {
        _coll.enabled = false;
        _rend.enabled = false;
        _rb.isKinematic = true;
        
        explosionShell.Play();
        _audioSource.Play();
        Destroy(gameObject, 0.5f);
    }

    private void RotateShell()
    {
        Vector3 targetForward = _rb.velocity.normalized;
        // Quaternion rotation = Quaternion.FromToRotation(transform.forward, targetForward);
        Quaternion rotation = Quaternion.LookRotation(targetForward);
        _rb.MoveRotation(rotation);
        
    }
}
