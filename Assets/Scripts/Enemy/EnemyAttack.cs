using UnityEngine;
using Vector3 = UnityEngine.Vector3;

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
    private float _sinAngle, _cosAngle;
    private Vector3 _relPositionShell;
    
    void Start()
    {
        _relPositionShell = posShell.position - transform.position; 
        _cosAngle = Vector3.Dot(posShell.forward, transform.forward);
        _sinAngle = Vector3.Dot(posShell.forward, transform.up);
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
        float launchForceFinal = ComputeLaunchVel();
        // Create and launch shell clone
        Rigidbody shellClone = Instantiate(shellEnemyPrefab,posShell.position,posShell.rotation);
        shellClone.velocity = launchForceFinal * posShell.forward;
        audioSource.Play();
    }

    private float ComputeLaunchVel()
    {
        float g = -Physics.gravity.y;
        float y0 = _relPositionShell.y;
        float z0 = _relPositionShell.z;
        
        return (_distance-z0) / Mathf.Sqrt(2f*_cosAngle*_cosAngle*y0/g + 2f*(_distance-z0)*_sinAngle*_cosAngle/g);
    }
    
    
}
