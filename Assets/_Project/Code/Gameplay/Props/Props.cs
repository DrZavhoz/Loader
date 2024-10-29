using DG.Tweening;
using UnityEngine;

namespace _Project.Code.Gameplay.Props
{
  public class Props : MonoBehaviour
  {
    [SerializeField] private Transform _propsTransform;
    [SerializeField] private Rigidbody _propsRigidBody;
    [SerializeField] private Material _propsMaterial;
    [SerializeField] private Collider _propsCollider;

    private void Start()
    {
      _propsTransform = transform;
      _propsRigidBody = _propsTransform.GetComponent<Rigidbody>();
      _propsMaterial = _propsTransform.GetComponent<Renderer>().material;
      _propsCollider = _propsTransform.GetComponent<Collider>();
      _propsMaterial.SetFloat("_OtlWidth",0f);

    }

    public void OnDrag(Transform parent)
    {
      _propsRigidBody.isKinematic = true;
      _propsCollider.isTrigger = true;
      _propsTransform.parent = parent;
      _propsTransform.DOLocalMove(Vector3.zero, 0.3f);
    }

    public void OnDrag()
    {
      _propsTransform.parent = null;
      _propsCollider.isTrigger = false;
      _propsRigidBody.isKinematic = false;
    }

    public void OnHightlight(bool state)
    {
      _propsMaterial.SetFloat("_OtlWidth",state?2f:0f);
    }
  }
}