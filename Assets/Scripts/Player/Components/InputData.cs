using UnityEngine;
using Unity.Entities;


/// <summary>
/// 上下左右キーを決めるコンポーネント
/// </summary>
[GenerateAuthoringComponent]
public struct InputData : IComponentData
{
    public KeyCode UpKey;
    public KeyCode DownKey;
    public KeyCode RightKey;
    public KeyCode LeftKey;
}
