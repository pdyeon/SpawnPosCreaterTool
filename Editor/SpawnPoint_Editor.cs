using UnityEditor;
using UnityEngine;
using System.Threading.Tasks;

public partial class SpawnPoint_Editor : EditorWindow
{
    public static SpawnPoint_Editor instance;

    int selected;

    string xlsxPath = "Assets/Table";
    string xlsxName = "6. ¹«Çù VR_Data_List_Å×½ºÆ®¿ë.xlsx";

    static int gameModeState;

    GameObject PlayerSpawnGroup;
    GameObject ItemSpawnGroup;
    GameObject ItemGroupManager;

    I_SpawnData i_PointPrefab;
    P_SpawnData p_PointPrefab;
    ItemGroupData itemGroup_Prefab;

    Vector2 scrollPos = Vector2.zero;

    private async Task OnEnable()
    {
        instance = this;

        i_PointPrefab = Resources.Load<I_SpawnData>("ItemSpawnPoint");
        p_PointPrefab = Resources.Load<P_SpawnData>("PlayerSpawnPoint");
        itemGroup_Prefab = Resources.Load<ItemGroupData>("ItemGroup");

        CreateGroup("PlayerSpawnGroup", PlayerSpawnGroup);
        //if (!GameObject.Find("PlayerSpawnGroup")) PlayerSpawnGroup = new GameObject("PlayerSpawnGroup");
        //else
        //{
        //    DestroyImmediate(PlayerSpawnGroup);
        //    PlayerSpawnGroup = new GameObject("PlayerSpawnGroup");
        //}
        CreateGroup("ItemSpawnGroup", ItemSpawnGroup);
        //if (!GameObject.Find("ItemSpawnGroup")) ItemSpawnGroup = new GameObject("ItemSpawnGroup");
        //else
        //{
        //    DestroyImmediate(ItemSpawnGroup);
        //    ItemSpawnGroup = new GameObject("ItemSpawnGroup");
        //}
        CreateGroup("ItemGroupManager", ItemGroupManager);
        //if (!GameObject.Find("ItemGroupManager")) ItemGroupManager = new GameObject("ItemGroupManager");
        //else
        //{
        //    DestroyImmediate(ItemGroupManager);
        //    ItemGroupManager = new GameObject("ItemGroupManager");
        //}

        //FileLoad.P_SpawnLoadData(gameModeState, xlsxPath, xlsxName, PlayerSpawnGroup, p_PointPrefab);
        //FileLoad.I_SpawnLoadData(gameModeState, xlsxPath, xlsxName, ItemSpawnGroup, i_PointPrefab);
        //FileLoad.IG_SpawnLoadData(gameModeState, xlsxPath, xlsxName, ItemGroupManager, itemGroup_Prefab);
    }

    void CreateGroup(string GroupObjName, GameObject Group)
    {
        if (!GameObject.Find(GroupObjName)) Group = new GameObject(GroupObjName);
        else
        {
            DestroyImmediate(Group);
            Group = new GameObject(GroupObjName);
        }
    }

    void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(150), GUILayout.ExpandHeight(true));

        selected = GUILayout.SelectionGrid(selected, new string[] { "Player", "Item", "ItemGroup" }, 1, GUILayout.Height(200));

        EditorGUILayout.EndVertical();

        EditorGUILayout.BeginVertical("box", GUILayout.MaxWidth(400), GUILayout.ExpandHeight(true));

        var label_style = new GUIStyle(GUI.skin.button);
        label_style.normal.textColor = Color.yellow;
        label_style.fontSize = 20;

        switch (selected)
        {
            #region Player
            case 0:
                
                if (GUILayout.Button("Save Data", GUILayout.Height(40))) 
                { FileSave.SaveData(gameModeState, xlsxPath, xlsxName,
                    PlayerSpawnGroup, ItemSpawnGroup, ItemGroupManager); }
                scrollPos = GUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Height(700));

                for (int i = 0; i < PlayerSpawnGroup.transform.childCount; i++)
                {
                    EditorGUILayout.BeginHorizontal();

                    GUILayout.Label("PlayerSponPoint_" + (i + 1), label_style);
                    
                    if (GUILayout.Button("X", GUILayout.Width(27), GUILayout.Height(27))) 
                    { DestroyImmediate(PlayerSpawnGroup.transform.GetChild(i).gameObject); return; }

                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal(GUILayout.Height(100));
                    Display(PlayerSpawnGroup.transform.GetChild(i).gameObject);
                    EditorGUILayout.BeginVertical();
                    
                    PlayerSpawnGroup.transform.GetChild(i).GetComponent<P_SpawnData>().PositionType = 
                        EditorGUILayout.IntField("PositionType", PlayerSpawnGroup.transform.GetChild(i).GetComponent<P_SpawnData>().PositionType);
                    PlayerSpawnGroup.transform.GetChild(i).GetComponent<P_SpawnData>().positionindex = 
                        EditorGUILayout.IntField("positionindex", PlayerSpawnGroup.transform.GetChild(i).GetComponent<P_SpawnData>().positionindex);
                    PlayerSpawnGroup.transform.GetChild(i).transform.position = 
                        EditorGUILayout.Vector3Field("Position", PlayerSpawnGroup.transform.GetChild(i).transform.position);
                    
                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndScrollView();
                break;
            #endregion

            #region Item
            case 1:
                if (GUILayout.Button("Save Data", GUILayout.Height(40))) 
                { FileSave.SaveData(gameModeState, xlsxPath, xlsxName,
                    PlayerSpawnGroup, ItemSpawnGroup, ItemGroupManager); }
                //if (GUILayout.Button("Apply Color", GUILayout.Height(40))) { Repaint(); }
                scrollPos = GUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Height(700));
                
                for (int i = 0; i < ItemSpawnGroup.transform.childCount; i++)
                {
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("ItemSponPoint_" + (i + 1), label_style);
                    if (GUILayout.Button("X", GUILayout.Width(27), GUILayout.Height(27)))
                    { DestroyImmediate(ItemSpawnGroup.transform.GetChild(i).gameObject); return; }
                    EditorGUILayout.EndHorizontal();
                    EditorGUILayout.BeginHorizontal(GUILayout.Height(100));

                    Display(ItemSpawnGroup.transform.GetChild(i).gameObject);

                    EditorGUILayout.BeginVertical();

                    ItemSpawnGroup.transform.GetChild(i).GetComponent<I_SpawnData>().SpawnGroupID = 
                        EditorGUILayout.IntField("SpawnGroupID", ItemSpawnGroup.transform.GetChild(i).GetComponent<I_SpawnData>().SpawnGroupID);
                    ItemSpawnGroup.transform.GetChild(i).transform.position = 
                        EditorGUILayout.Vector3Field("Position", ItemSpawnGroup.transform.GetChild(i).transform.position);

                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndScrollView();
                break;
            #endregion

            #region ItemGroup
            case 2:
                if (GUILayout.Button("Save Data", GUILayout.Height(40))) 
                { FileSave.SaveData(gameModeState, xlsxPath, xlsxName,
                    PlayerSpawnGroup, ItemSpawnGroup, ItemGroupManager); }
                if (GUILayout.Button("Create ItemGroup", GUILayout.Height(40))) { CreateItemGroup(); }
                scrollPos = GUILayout.BeginScrollView(scrollPos, false, false, GUILayout.Height(700));

                for (int i = 0; i < ItemGroupManager.transform.childCount; i++)
                {
                    for (int j = 0; j < ItemSpawnGroup.transform.childCount; j++) // ItemGroupÀÇ Ä®¶ó°ªÀ» °¡Á®¿È
                    {
                        if (ItemSpawnGroup.transform.GetChild(j).GetComponent<I_SpawnData>().SpawnGroupID ==
                            ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnGroupID)
                        {
                            //Color itemColor = ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().GroupColor;
                            //ItemSpawnGroup.transform.GetChild(j).GetComponent<Renderer>().material.color = itemColor;
                            MaterialPropertyBlock _propBlock = new MaterialPropertyBlock();
                            _propBlock.SetColor("_Color", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().GroupColor);
                            ItemSpawnGroup.transform.GetChild(j).GetComponent<Renderer>().SetPropertyBlock(_propBlock);
                        }
                    }
                    EditorGUILayout.BeginHorizontal();
                    GUILayout.Label("ItemGroup_" + (i+1), label_style);
                    if (GUILayout.Button("X", GUILayout.Width(27), GUILayout.Height(27)))
                    { DestroyImmediate(ItemGroupManager.transform.GetChild(i).gameObject); return; }
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal(GUILayout.Height(100));
                    EditorGUILayout.BeginVertical();

                    ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().GroupColor =
                        EditorGUILayout.ColorField("GroupColor", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().GroupColor);
                    ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnGroupID = 
                        EditorGUILayout.IntField("SpawnGroupID", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnGroupID);
                    ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().Name = 
                        EditorGUILayout.TextField("Name", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().Name);
                    ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnType = 
                        EditorGUILayout.IntField("SpawnType", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnType);
                    ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnCount = 
                        EditorGUILayout.IntField("SpawnCount", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnCount);

                    var ItemComp = new SerializedObject(ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>());
                    var Comp_Data = ItemComp.FindProperty("_ItemComponents");
                    EditorGUILayout.PropertyField(Comp_Data, true);

                    EditorGUILayout.EndVertical();
                    EditorGUILayout.EndHorizontal();
                }
                EditorGUILayout.EndScrollView();
                break;
                #endregion
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.EndHorizontal();
    }

    public void Display(GameObject prefab)
    {
        EditorGUILayout.BeginVertical();

        GUILayout.FlexibleSpace();
        if (GUILayout.Button(AssetPreview.GetAssetPreview(prefab), GUILayout.Height(128), GUILayout.Width(128)))
        {
            Selection.activeObject = prefab;
            SceneView.FrameLastActiveSceneView();
        }

        EditorGUILayout.EndVertical();
    }

    public static void OnDestroy()
    {
        instance.Close();
    }

    public void CreateItemGroup()
    {
        ItemGroupData _itemGroup = Instantiate(itemGroup_Prefab);
        _itemGroup.transform.SetParent(ItemGroupManager.transform);
    }

    public static void GetMapState( int _mapstate)
    {
        gameModeState = _mapstate;
    }

}
