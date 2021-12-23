using UnityEngine;
using Unity.Scenes;

/// <summary>
/// マップデータ
/// </summary>
public class SubSceneReferences : MonoBehaviour
{
    public static SubSceneReferences Instance { get; private set; }

    public SubScene[] map;

    private void Awake()
    {
        Instance = this;
    }
}
