using Unity.Entities;
using UnityEngine;

namespace Authorings
{
    public struct BouleTag : IComponentData {}

    public class BouleAuthoring : MonoBehaviour
    {
        public GameObject Wall;
        public class GuardBaker : Baker<BouleAuthoring>
        {
            public override void Bake(BouleAuthoring authoring)
            {
                Entity entity = GetEntity(authoring, TransformUsageFlags.Dynamic);
                
                AddComponent<BouleTag>(entity);
            }
        }
    }
}