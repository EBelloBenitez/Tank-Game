using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float turnSpeed;
    [SerializeField] private AudioClip idleClip;
    [SerializeField] private AudioClip drivingClip;

    private float _horizontal, _vertical;
    private Rigidbody _rb;
    private AudioSource _audioSource;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        InputPlayer();
        AudioEngine();
    }

    private void FixedUpdate()
    {
        Movement();
        Rotation();
    }

    private void InputPlayer()
    {
        _vertical = Input.GetAxis("Vertical");
        _horizontal = Input.GetAxis("Horizontal");
    }

    private void Movement()
    {
        Vector3 movement = _vertical * speed * Time.deltaTime * transform.forward;
        _rb.MovePosition(transform.position + movement);
    }

    private void Rotation()
    {
        // Quaternion rotation = Quaternion.AngleAxis(_horizontal * turnSpeed * Time.deltaTime, transform.up);
        Quaternion rotation = Quaternion.Euler(0, _horizontal * turnSpeed * Time.deltaTime, 0);
        _rb.MoveRotation(transform.rotation * rotation);
    }

    private void AudioEngine()
    {
        bool isClipIdle = (_audioSource.clip == idleClip);
        
        if (_vertical != 0 || _horizontal != 0)
        {
            if (_audioSource.clip != drivingClip)
            {
                _audioSource.clip = drivingClip;
                _audioSource.Play();
            }
        }
        else 
        {
            if (_audioSource.clip != idleClip)
            {
                _audioSource.clip = idleClip;
                _audioSource.Play();
            }
        }

    }
}
