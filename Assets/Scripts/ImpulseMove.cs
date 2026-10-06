using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ImpulseMove : MonoBehaviour
{
    private Rigidbody _rb;
    [SerializeField] private float force;
    [SerializeField] private Space space = Space.Self;

    private void Awake()
    {
        // Usually we need to check that GetComponent() returned null, but in our case we used RequireComponent which ensures a rigidbody on this gameobject exists.
        _rb = GetComponent<Rigidbody>();
    }

    public void Move(Vector3 dir)
    {
        dir = dir.normalized;
        if (space == Space.Self)
        {
            _rb.AddRelativeForce(dir * force,  ForceMode.Impulse);
        }
        else
        {
            _rb.AddForce(dir * force,  ForceMode.Impulse);
        }
    }
}
