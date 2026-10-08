using System;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Spin))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(ImpulseMove))]
public class Asteroid : MonoBehaviour
{
    private Spin _spin;
    private ImpulseMove _impulseMove;
    
    private void Start()
    {
        _spin = GetComponent<Spin>();
        _spin.RotationStep = new Vector3(Random.Range(-100f, 100), Random.Range(-100f, 100), Random.Range(-100f, 100));
        
        _impulseMove = GetComponent<ImpulseMove>();
        _impulseMove.Move(new Vector3(1f, 0f, 0f));
    }
    
    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided with " + collision.gameObject.name); 
        
        Spin s = collision.gameObject.GetComponent<Spin>();
        if (s != null)
        {
            s.RotationStep = new Vector3(Random.Range(-100f, 100), Random.Range(-100f, 100), Random.Range(-100f, 100));
        }
    }
}
