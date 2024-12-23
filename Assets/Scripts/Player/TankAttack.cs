using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankAttack : MonoBehaviour
{
    [SerializeField] private Rigidbody shellPrefab;
    [SerializeField] private Transform posShell;
    [SerializeField] private float launchForce;
    [SerializeField] private AudioSource audioSource;

    void Update()
    {
        FireShell();
    }

    private void FireShell()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Rigidbody shellClone = Instantiate(shellPrefab,posShell.position,posShell.rotation);
            shellClone.velocity = launchForce * posShell.forward;
            audioSource.Play();
        }
    }
}
