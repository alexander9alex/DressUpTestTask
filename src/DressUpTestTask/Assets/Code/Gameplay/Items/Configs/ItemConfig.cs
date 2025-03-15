using Code.Gameplay.Items.Data;
using Code.Infrastructure.Views;
using UnityEngine;

namespace Code.Gameplay.Items.Configs
{
  [CreateAssetMenu(menuName = "Static Data/Item Config", fileName = "ItemConfig", order = 0)]
  internal class ItemConfig : ScriptableObject
  {
    public ItemId ItemId;
    public EntityBehaviour ItemPrefab;
  }
}
