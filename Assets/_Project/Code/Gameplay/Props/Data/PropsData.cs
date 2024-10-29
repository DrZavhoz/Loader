using UnityEngine;

namespace _Project.Code.Gameplay.Props.Data
{
  [CreateAssetMenu(fileName = "PropsData", menuName = "Data/Props Data", order = 52)]   
  public class PropsData : ScriptableObject
  {
    public Transform[] Props;
  }
}