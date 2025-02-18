using UnityEngine;
using UnityEngine.InputSystem.XR;

public class Player : MonoBehaviour
{
    private Vector3 _velocity;
    private Vector3 _playerMovementInput;
    private Vector2 _mouseInput;
    private float _rotation;

    [SerializeField] private CharacterController _controller;
    [SerializeField] private Transform _playerCamera;
    [SerializeField] private float _speed;
    [SerializeField] private float _sens;
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _gravity = -9.81f;

    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        _playerMovementInput = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));
        _mouseInput = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        MovePlayer();
        MoveCamera();
    }

    private void MovePlayer()
    {
        Vector3 _newDirection = transform.TransformDirection(_playerMovementInput);

        if (_controller.isGrounded)
        {
            _velocity.y = -1f;

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _velocity.y = _jumpForce;
            }
        }
        else
        {
            _velocity.y -= _gravity * -2f * Time.deltaTime;
        }

        _controller.Move(_newDirection * _speed * Time.deltaTime);
        _controller.Move(_velocity * Time.deltaTime);
    }

    private void MoveCamera()
    {
        _rotation -= _mouseInput.y * _sens;
        transform.Rotate(0f, _mouseInput.x * _sens, 0f);
    
        if (_rotation > 90)
        {
            _rotation = 90;
        }

        if (_rotation < -90)
        {
            _rotation = -90;
        }

        _playerCamera.transform.localRotation = Quaternion.Euler(_rotation, 0f, 0f);
    }
}
