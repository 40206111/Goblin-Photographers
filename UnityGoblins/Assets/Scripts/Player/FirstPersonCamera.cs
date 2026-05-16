using UnityEngine;
using UnityEngine.InputSystem;

public class FirstPersonCamera : MonoBehaviour
{
    [HideInInspector] public Transform Target;
    [SerializeField] float _mouseSensitivity = 10f;

    float _vertialRotation;
    float _horizontalRotation;

    private void LateUpdate()
    {
        if (Target ==  null) return;

        transform.position = Target.position;

        Vector2 mousePos = InputSystem.actions.FindAction("Look").ReadValue<Vector2>();

        _vertialRotation -= mousePos.y * _mouseSensitivity * Time.deltaTime;
        _vertialRotation = Mathf.Clamp(_vertialRotation, -50f, 25f);

        _horizontalRotation += mousePos.x * _mouseSensitivity * Time.deltaTime;

        transform.rotation = Quaternion.Euler(_vertialRotation, _horizontalRotation, 0);
    }
}
