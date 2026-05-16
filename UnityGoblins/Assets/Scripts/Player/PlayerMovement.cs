using Fusion;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : NetworkBehaviour
{
    CharacterController _controller;
    Camera _camera;

    [SerializeField] float _playerSpeed = 6f;
    [SerializeField] Transform _head;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    public override void FixedUpdateNetwork()
    {
        InputSystem.Update(); // input needs to be manually updated for the networking stuff

        var moveAction = InputSystem.actions.FindAction("Move");
        var moveValue = moveAction.ReadValue<Vector2>();

        Quaternion cameraRotationY = Quaternion.Euler(0, _camera.transform.rotation.eulerAngles.y, 0);
        Vector3 move = cameraRotationY * new Vector3(moveValue.x, 0, moveValue.y) * Runner.DeltaTime * _playerSpeed;

        _controller.Move(move);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        _head.forward = _camera.transform.forward;
    }

    public override void Spawned()
    {
        if (!HasStateAuthority) //only the client that made this player
        {
            return;
        }

        _camera = Camera.main;
        _camera.GetComponent<FirstPersonCamera>().Target = transform;
    }
}
