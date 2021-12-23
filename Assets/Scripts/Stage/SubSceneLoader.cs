using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Scenes;
using Unity.Transforms;
using Hash128 = Unity.Entities.Hash128;

/// <summary>
/// マップ切り替えロード
/// </summary>
public class SubSceneLoader : ComponentSystem
{
    private EntityManager entityManager;
    private SceneSystem sceneSystem;
    
    protected override void OnCreate()
    {
        entityManager = World.DefaultGameObjectInjectionWorld.EntityManager;
        sceneSystem = entityManager.World.GetExistingSystem<SceneSystem>();
    }

    protected override void OnUpdate()
    {
        Entities.WithAll<PlayerTag>().ForEach((ref Translation translation) =>
        {
            foreach (var subScene in SubSceneReferences.Instance.map)
            {
                float loadDistance = 80.0f;
                if (math.distance(translation.Value, subScene.transform.position) < loadDistance)
                {
                    LoadSubScene(subScene);
                }
                else
                {
                    UnLoadSubScene(subScene);
                }
            }
        });

    }

    /// <summary>
    /// マップロード
    /// </summary>
    void LoadSubScene(SubScene subScene)
    {
        var sceneEntity = sceneSystem.GetSceneEntity(subScene.SceneGUID);
        if (!entityManager.HasComponent<RequestSceneLoaded>(sceneEntity))
        {
            sceneSystem.LoadSceneAsync(subScene.SceneGUID);
        }
    }

    /// <summary>
    /// マップ破棄
    /// </summary>
    void UnLoadSubScene(SubScene subScene)
    {
        var sceneEntity = sceneSystem.GetSceneEntity(subScene.SceneGUID);
        if (entityManager.HasComponent<RequestSceneLoaded>(sceneEntity))
        {
            sceneSystem.UnloadScene(subScene.SceneGUID);
        }
    }
}
