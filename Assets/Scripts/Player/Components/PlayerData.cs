using Unity.Entities;
using Unity.Mathematics;
using UnityEngine;

/// <summary>
/// プレイヤー情報を持つコンポーネント
/// </summary>
[GenerateAuthoringComponent]
public struct PlayerData : IComponentData
{
    [HideInInspector]
    public float3 MoveDirection;      // 向く方向
    
    public float MoveSpeedMultiplier; // 移動速度係数
    
    public float MoveSpeed;           // 移動速度
}
