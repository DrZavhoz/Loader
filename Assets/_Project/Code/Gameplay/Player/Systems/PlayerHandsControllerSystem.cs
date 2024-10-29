using UnityEngine;

namespace _Project.Code.Gameplay.Player.Systems
{
  public class PlayerHandsControllerSystem : MonoBehaviour
  {
    [SerializeField] Transform _playerHandsTransform;
    [SerializeField] private Transform _cameraTransform;
    private RaycastHit _hit;
    private int _layerMask;

    [Space] [SerializeField] private bool _inHands;
    [SerializeField] private Props.Props _props;

    private void Start()
    {
      _layerMask = 1 << 6;
      _inHands = false;
    }

    private void Update()
    {
      if (Input.GetMouseButtonDown(0))
      {
        if (_props)
        {
          if (!_inHands)
          {
            _inHands = true;
            _props.OnHightlight(false);
            TakeProps();
          }
          else
          {
            DropProps();
            _props = null;
            _inHands = false;
          }
        }
      }
    }

    private void FixedUpdate()
    {
      if (_inHands) return;
      if (Physics.Raycast(
            _cameraTransform.position
            , _cameraTransform.TransformDirection(Vector3.forward)
            , out _hit
            , 3f
            , _layerMask))
      {
        Debug.DrawRay(
          _cameraTransform.position
          , _cameraTransform.TransformDirection(Vector3.forward) * _hit.distance
          , Color.yellow);
        Debug.Log(_hit.transform.name);
        if (_hit.transform.CompareTag("Props") && _hit.transform.TryGetComponent(out Props.Props props))
        {
          if(_props && _props != props)
            _props.OnHightlight(false);

          _props = props;
          _props.OnHightlight(true);
        }
        else
        {
          if (_props)
          {
            _props.OnHightlight(false);
            _props = null;
          }
        }
      }
      else
      {
        if (_props)
        {
          _props.OnHightlight(false);
          _props = null;
        }
      }
    }

    private void TakeProps()
    {
      _props.OnDrag(_playerHandsTransform);
    }

    private void DropProps()
    {
      _props.OnDrag();
    }
  }
}