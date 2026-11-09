using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

[CreateAssetMenu(fileName = "ScenePathSo", menuName = "Scriptable Objects/ScenePathSo")]
public class ScenePathSo : ScriptableObject
 {
    public string Path => _path;


   [SerializeField][HideInInspector] private string _path;




#if UNITY_EDITOR

    [SerializeField] private SceneAsset _asset;
    private void OnValidate()
    {
        _path = _asset != null ? AssetDatabase.GetAssetPath(_asset) : string.Empty;
    }


#endif

}
