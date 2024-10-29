using _Project.Code.Gameplay.Props.Data;
using UnityEngine;

namespace _Project.Code.Gameplay.Props.Systems
{
  public class PropsSpawnerSystem : MonoBehaviour
  {
    [SerializeField] private PropsData _propsData;

    private void Start()
    {
      SpawnProps();
    }

    private void SpawnProps()
    {
      Transform[] childrens = gameObject.GetComponentsInChildren<Transform>();

      foreach (Transform point in childrens)
      {
        if (point.CompareTag("SpawnPoint"))
        {
          Instantiate(_propsData.Props[Random.Range(0,_propsData.Props.Length)], point.position, point.rotation) ;
        }
      }
    }
  }
}