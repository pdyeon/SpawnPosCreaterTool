using UnityEditor;
using UnityEngine;

public class SpawnModeSetting_Editor : EditorWindow
{

    public enum MAPSTATE
    {
        Single = 0,
        Team,
        Battle,
        Test
    }
    public MAPSTATE mapstate = MAPSTATE.Single;

    float buttonSize = 40f;

    [MenuItem("Tools/SpawnPointSetting")]
    public static void ShowWindow()
    {
        GetWindow(typeof(SpawnModeSetting_Editor), false, "Setting");
    }

    [System.Obsolete]
    private void OnGUI()
    {
        GUILayout.Label("Game Mode Setting", EditorStyles.boldLabel);

        mapstate = (MAPSTATE)EditorGUILayout.EnumPopup("Game Mode", mapstate);

        if (GUILayout.Button("Loading GameMode", GUILayout.Height(buttonSize)))
        {
            SpawnPoint_Editor.GetMapState((int)mapstate);

            if (GameObject.Find("PlayerSpawnGroup"))
            {
                GameObject ps = GameObject.Find("PlayerSpawnGroup");
                DestroyImmediate(ps);
            }
            if (GameObject.Find("ItemSpawnGroup"))
            {
                GameObject it = GameObject.Find("ItemSpawnGroup");
                DestroyImmediate(it);
            }
            if (GameObject.Find("ItemGroupManager"))
            {
                GameObject ig = GameObject.Find("ItemGroupManager");
                DestroyImmediate(ig);
            }

            if (EditorWindow.HasOpenInstances<SpawnPoint_Editor>())
            {
                SpawnPoint_Editor.OnDestroy();
            }

            if (!EditorWindow.HasOpenInstances<SpawnPoint_Editor>())
            {
                GetWindow(typeof(SpawnPoint_Editor), false, "SpawnPointData");
            }
        }

        if (GUILayout.Button("Remove Setting", GUILayout.Height(buttonSize)))
        {
            if(GameObject.Find("PlayerSpawnGroup"))
            {
                GameObject ps = GameObject.Find("PlayerSpawnGroup");
                DestroyImmediate(ps);
            }
            if(GameObject.Find("ItemSpawnGroup"))
            {
                GameObject it = GameObject.Find("ItemSpawnGroup");
                DestroyImmediate(it);
            }
            if(GameObject.Find("ItemGroupManager"))
            {
                GameObject ig = GameObject.Find("ItemGroupManager");
                DestroyImmediate(ig);
            }

            if (EditorWindow.HasOpenInstances<SpawnPoint_Editor>())
            {
                SpawnPoint_Editor.OnDestroy();
            }
        }
    }
}
