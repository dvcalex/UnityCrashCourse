using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShipController : MonoBehaviour
{
    [SerializeField] private ImpulseMove mover;
    [SerializeField] private float moveCooldownSecs;

    private bool _canMove = true;
    
    public void HandleMove(InputAction.CallbackContext context)
    {
        if (!context.performed || !_canMove)
            return;

        Vector2 input = context.action.ReadValue<Vector2>().normalized;
        
        mover.Move(new Vector3(-input.y, 0, input.x));
        StartCoroutine(DisableMove(moveCooldownSecs));
    }

    private IEnumerator DisableMove(float duration)
    {
        _canMove = false;
        yield return new WaitForSeconds(duration);
        _canMove = true;
    }
}
