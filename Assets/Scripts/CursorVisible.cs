#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class CursorVisible : MonoBehaviour
{
    void Start()
    {
#if UNITY_EDITOR
        Cursor.SetCursor(PlayerSettings.defaultCursor, new Vector2(60,60), CursorMode.ForceSoftware);
#endif
    }
}