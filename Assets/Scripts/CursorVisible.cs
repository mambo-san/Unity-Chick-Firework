#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;
#endif

public class cursorVisible : MonoBehaviour
{
    void Start()
    {
#if UNITY_EDITOR
        Cursor.SetCursor(PlayerSettings.defaultCursor, Vector2.zero, CursorMode.ForceSoftware);
#endif
    }
}