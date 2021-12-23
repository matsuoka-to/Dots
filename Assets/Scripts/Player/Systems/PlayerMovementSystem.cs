using UnityEngine;
using Unity.Entities;
using Unity.Mathematics;
using Unity.Transforms;

/// <summary>
/// プレイヤー移動処理
/// </summary>
[UpdateInGroup(typeof(InitializationSystemGroup))]
[UpdateAfter(typeof(PlayerInputSystem))]
public class PlayerMovementSystem : SystemBase
{
    private Camera _mainCamera;

    protected override void OnStartRunning()
    {
        _mainCamera = Camera.main;
    }

    protected override void OnUpdate()
    {
        var deltaTime = Time.DeltaTime;

        Entities
            .WithoutBurst()
            .WithAll<PlayerTag>()
            .ForEach((ref Translation translation, in PlayerData playerData) =>
            {
                // 向きを取得してその方向に動かす
                var moveDirection = math.normalizesafe(playerData.MoveDirection);
                translation.Value += moveDirection * playerData.MoveSpeed * playerData.MoveSpeedMultiplier * deltaTime;

            }).Run();
    }
}
