using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    CharacterController _controller;

    [SerializeField] float _playerSpeed;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        InputSystem.Update(); // input needs to be manually updated for the networking stuff

        var moveAction = InputSystem.actions.FindAction("Move");
        var moveValue = moveAction.ReadValue<Vector2>();

        Vector3 move = new Vector3(moveValue.x, 0, moveValue.y) * Runner.DeltaTime * _playerSpeed;

        _controller.Move(move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
    }
}
