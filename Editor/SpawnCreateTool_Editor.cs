using UnityEngine;
using UnityEditor;
using UnityEditor.EditorTools;

[EditorTool("SponPointCreate Tool")]
public class SpawnCreateTool_Editor : EditorTool
{
    public enum SPAWNSTATE
    {
        None = 0,
        Spawn,
    }
    public SPAWNSTATE _SPAWNSTATE = SPAWNSTATE.None;

    private GameObject p_Group;
    private GameObject i_Group;

    private Vector3 pos;

    private void OnEnable()
    {
        Debug.Log("None Mode");
        
    }

    Vector3 OnSceneGUI()
    {
        Vector3 target = Vector3.zero;

        var mousePosition = Event.current.mousePosition * EditorGUIUtility.pixelsPerPoint;
        mousePosition.y = Camera.current.pixelHeight - mousePosition.y;
        Ray ray = Camera.current.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }

        return target;
    }

    public void CallBack(object obj)
    {
        GameObject sp;
        
        switch (obj)
        {
            case 1:
                sp = Resources.Load("PlayerSpawnPoint") as GameObject;
                sp = Instantiate(sp, pos, Quaternion.identity);
                p_Group = GameObject.Find("PlayerSpawnGroup");
                sp.transform.SetParent(p_Group.transform);
                break;
            case 2:
                sp = Resources.Load("ItemSpawnPoint") as GameObject;
                sp = Instantiate(sp, pos, Quaternion.identity);
                i_Group = GameObject.Find("ItemSpawnGroup");
                sp.transform.SetParent(i_Group.transform);
                break;
        }
    }

    public override void OnToolGUI(EditorWindow window)
    {
        pos = OnSceneGUI();
        Event e = Event.current;

        if (e.type == EventType.MouseDown && e.button == 0)
        {
            switch (_SPAWNSTATE)
            {
                case SPAWNSTATE.None:
                    break;
                case SPAWNSTATE.Spawn:
                    GenericMenu menu = new GenericMenu();
                    menu.AddItem(new GUIContent("PlayerSpawnPoint"), false, CallBack, 1);
                    menu.AddItem(new GUIContent("ItemSpawnPoint"), false, CallBack, 2);
                    menu.ShowAsContext();
                    break;
            }
        }

        if(e.type == EventType.KeyDown && e.keyCode == KeyCode.LeftShift) // Shift 키를 눌러 스폰 모드를 설정
        {
            switch(_SPAWNSTATE)
            {
                case SPAWNSTATE.None:
                    _SPAWNSTATE = SPAWNSTATE.Spawn;
                    Debug.Log("Spawn Mode");
                    break;
                case SPAWNSTATE.Spawn:
                    _SPAWNSTATE = SPAWNSTATE.None;
                    Debug.Log("None Mode");
                    break;
            }   
        }

    }

}
