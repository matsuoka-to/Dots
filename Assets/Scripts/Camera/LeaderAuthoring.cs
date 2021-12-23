using Unity.Entities;
using UnityEngine;

/// <summary>
/// ターゲット設定
/// </summary>
public class LeaderAuthoring : MonoBehaviour, IConvertGameObjectToEntity
{
    public GameObject followerObject;

    public void Convert(Entity entity, EntityManager manager, GameObjectConversionSystem conversionSystem)
    {
        var followEntity = followerObject.GetComponent<FollowEntity>();
        if (followEntity == null)
        {
            followEntity = followerObject.AddComponent<FollowEntity>();
        }

        followEntity.entityToFloow = entity;
    }
}
