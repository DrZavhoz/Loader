using UnityEngine;

namespace _Project.Code.Gameplay.Player.Systems
{
  public class PlayerControllerSystem : MonoBehaviour
  {
    [SerializeField] private float sunsivity = 1f;
    [SerializeField] private float moveSpeed = 1f;


    private Transform _playerTransform;
    private Transform _cameraTransform;
    private CharacterController _characterController;

    Vector3 _moveDirectionValue;
    private float _cameraRotationValue;


    private void Start()
    {
      Cursor.lockState = CursorLockMode.Locked;

      _playerTransform = transform;
      _cameraTransform = _playerTransform.GetChild(0);
      _characterController = _playerTransform.GetComponent<CharacterController>();
    }

    void Update()
    {
      RotateCamera();
      RotatePlayer();
      MovePlayer();
    }

    private void RotatePlayer()
    {
      _playerTransform.Rotate(Vector3.up * (Input.GetAxis("Mouse X") * (sunsivity * Time.deltaTime)));
    }


    private void RotateCamera()
    {
      _cameraRotationValue -= Input.GetAxis("Mouse Y") * (sunsivity * Time.deltaTime);
      _cameraRotationValue = Mathf.Clamp(_cameraRotationValue, -90f, 90f);
      _cameraTransform.localRotation = Quaternion.Euler(_cameraRotationValue, 0f, 0f);
    }

    private void MovePlayer()
    {
      _moveDirectionValue = _playerTransform.forward * Input.GetAxis("Vertical") +
                            _playerTransform.right * Input.GetAxis("Horizontal");
      _moveDirectionValue *= (moveSpeed * Time.deltaTime);

      _characterController.SimpleMove(_moveDirectionValue);
    }
  }
}