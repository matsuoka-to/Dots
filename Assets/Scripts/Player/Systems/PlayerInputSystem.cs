using System;
using UnityEngine;
using Unity.Entities;

/// <summary>
/// 入力処理
/// </summary>
[AlwaysUpdateSystem]
[UpdateInGroup(typeof(InitializationSystemGroup))]
public class PlayerInputSystem : SystemBase
{
    protected override void OnUpdate()
    {
        Entities
            .WithAll<PlayerTag>()
            .ForEach((ref PlayerData playerData, in InputData inputData) =>
            {
                // 入力のboolを取得
                bool isRightKeyPressed = Input.GetKey(inputData.RightKey);
                bool isLeftKeyPressed  = Input.GetKey(inputData.LeftKey);
                bool isUpKeyPressed    = Input.GetKey(inputData.UpKey);
                bool isDownKeyPressed  = Input.GetKey(inputData.DownKey);

                // boolから移動方向を反映
                playerData.MoveDirection.x =  Convert.ToInt32(isRightKeyPressed);
                playerData.MoveDirection.x -= Convert.ToInt32(isLeftKeyPressed);
                playerData.MoveDirection.z =  Convert.ToInt32(isUpKeyPressed);
                playerData.MoveDirection.z -= Convert.ToInt32(isDownKeyPressed);

                playerData.MoveSpeedMultiplier = 1.0f;

            }).Run();
    }
}
