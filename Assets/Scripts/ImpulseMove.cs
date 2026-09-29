using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ImpulseMove : MonoBehaviour
{
    private Rigidbody _rb;

    [SerializeField] 
    private Vector3 moveVector;

    [SerializeField]
    private Space spaceOfMoveVector = Space.Self;

    private void Awake()
    {
        // Usually we need to check that GetComponent() returned null, but in our case we used RequireComponent which ensures a rigidbody on this gameobject exists.
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Move(20);
    }

    public void Move(float force)
    {
        Vector3 axis = moveVector.normalized;
        if (spaceOfMoveVector == Space.Self)
        {
            _rb.AddRelativeForce(axis * force,  ForceMode.Impulse);
        }
        else
        {
            _rb.AddForce(axis * force,  ForceMode.Impulse);
        }
    }
}
