using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MiniExcelLibs;
using System.Linq;

public class FileLoad : MonoBehaviour
{
    public static void P_SpawnLoadData(int gameModeState, string xlsxPath, string xlsxName,
        GameObject PlayerSpawnGroup, P_SpawnData p_PointPrefab)
    {
        var path = Path.Combine(xlsxPath, xlsxName);

        using (var stream = File.OpenRead(path))
        {
            var rows_P = stream.Query<FileData.StartPositionTable>(sheetName: "StartPositionTable").ToList();

            for (int i = 0; i < rows_P.Count; i++)
            {
                if (rows_P[i].GameRuleID == gameModeState)
                {
                    var sponPos = new Vector3(rows_P[i].X, rows_P[i].Y, rows_P[i].Z);
                    P_SpawnData p_f = Instantiate(p_PointPrefab, sponPos, Quaternion.identity);
                    p_f.transform.SetParent(PlayerSpawnGroup.transform);
                    p_f.GetPositionType(rows_P[i].PositionType);
                    p_f.Getpositionindex(rows_P[i].positionindex);
                }
            }

        }
    }

    public static void I_SpawnLoadData(int gameModeState, string xlsxPath, string xlsxName,
        GameObject ItemSpawnGroup, I_SpawnData i_PointPrefab)
    {
        var path = Path.Combine(xlsxPath, xlsxName);

        using (var stream = File.OpenRead(path))
        {
            var rows_I = stream.Query<FileData.SpawnGroupPositionTable>(sheetName: "SpawnGroupPositionTable").ToList();

            for (int i = 0; i < rows_I.Count; i++)
            {
                if (rows_I[i].GameRuleID == gameModeState)
                {
                    var sponPos = new Vector3(rows_I[i].x, rows_I[i].y, rows_I[i].z);
                    I_SpawnData i_f = Instantiate(i_PointPrefab, sponPos, Quaternion.identity);
                    i_f.transform.SetParent(ItemSpawnGroup.transform);
                    i_f.GetItemGroup(rows_I[i].SpawnGroupID);
                }
            }
        }
    }

    public static void IG_SpawnLoadData(int gameModeState, string xlsxPath, string xlsxName,
        GameObject ItemGroupManager, ItemGroupData itemGroup_Prefab)
    {
        var path = Path.Combine(xlsxPath, xlsxName);

        using (var stream = File.OpenRead(path))
        {
            var rows_G = stream.Query<FileData.SpawnGroupTable>(sheetName: "SpawnGroupTable").ToList();
            var rows_GI = stream.Query<FileData.SpawnGroupItemTable>(sheetName: "SpawnGroupItemTable").ToList();

            for (int i = 0; i < rows_G.Count; i++)
            {
                if (rows_G[i].GameRuleID == gameModeState)
                {
                    ItemGroupData _itemGroup = Instantiate(itemGroup_Prefab);
                    _itemGroup.transform.SetParent(ItemGroupManager.transform);
                    _itemGroup.SpawnGroupID = rows_G[i].SpawnGroupID;
                    _itemGroup.Name = rows_G[i].Name;
                    _itemGroup.SpawnType = rows_G[i].SpawnType;
                    _itemGroup.SpawnCount = rows_G[i].SpawnCount;

                    for (int j = 0; j < rows_GI.Count; j++) //Item Components를 채우기
                    {
                        if (rows_GI[j].SpawnGroupID == rows_G[i].SpawnGroupID)
                        {
                            ItemGroupData.ItemComponents GI_Data = new ItemGroupData.ItemComponents();
                            GI_Data.ItemID = rows_GI[j].ItemID;
                            GI_Data.Count = rows_GI[j].Count;
                            _itemGroup._ItemComponents.Add(GI_Data);
                        }
                    }
                }
            }
        }
    }

}
