using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;
using UnityEngine;

/// <summary>
/// カメラ処理
/// </summary>
public class FollowEntity : MonoBehaviour
{
    public Entity entityToFloow;
    public float3 offset = float3.zero;

    private EntityManager manager;
    
    void Awake()
    {
        manager = World.DefaultGameObjectInjectionWorld.EntityManager;
    }

    void LateUpdate()
    {
        if (entityToFloow == null)
        {
            return;
        }

        var pos = manager.GetComponentData<Translation>(entityToFloow);
        transform.position = pos.Value + offset;
    }
}
