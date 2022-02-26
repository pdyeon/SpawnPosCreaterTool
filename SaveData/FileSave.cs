using System.Collections.Generic;
using UnityEngine;
using System.IO;
using MiniExcelLibs;
using System.Linq;

public class FileSave
{
    public static void SaveData(int gameModeState, string xlsxPath, string xlsxName, 
        GameObject PlayerSpawnGroup, GameObject ItemSpawnGroup, GameObject ItemGroupManager)
    {
        var path = Path.Combine(xlsxPath, xlsxName);// 파일경로설정

        //----------------------------------------------------------------------------------------------------------------------------------AbnormalTable
        var AbnormalTable = new List<Dictionary<string, object>>();
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.AbnormalTable>(sheetName: "AbnormalTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                var _AbnormalTable = new Dictionary<string, object>
                {
                    { "AbnormalID",      ReadTable[i].AbnormalID },
                    { "Name",            ReadTable[i].Name },
                    { "AbnormalType",    ReadTable[i].AbnormalType },
                    { "AbnormalFlag",    ReadTable[i].AbnormalFlag },
                    { "AbnormalTime",    ReadTable[i].AbnormalTime },
                    { "AbnormalDotTime", ReadTable[i].AbnormalDotTime },
                    { "Value1",          ReadTable[i].Value1 },
                    { "Value2",          ReadTable[i].Value2 },
                    { "Value3",          ReadTable[i].Value3 }
                };

                AbnormalTable.Add(_AbnormalTable);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------GameRuleTable

        var GameRuleTable = new List<Dictionary<string, object>>();// GameRuleTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.GameRuleTable>(sheetName: "GameRuleTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                var _GameRuleTable = new Dictionary<string, object>
                {
                    { "GameRuleID",           ReadTable[i].GameRuleID },
                    { "GameRuleTeamType",     ReadTable[i].GameRuleTeamType },
                    { "GameRuleDeadType",     ReadTable[i].GameRuleDeadType },
                    { "MinCountPerTeam",      ReadTable[i].MinCountPerTeam },
                    { "StartMinTime",         ReadTable[i].StartMinTime },
                    { "MaxCountPerTeam",      ReadTable[i].MaxCountPerTeam },
                    { "MapID",                ReadTable[i].MapID },
                    { "Play_Time",            ReadTable[i].Play_Time },
                    { "GameRuleMatchingType", ReadTable[i].GameRuleMatchingType },
                    { "ArrowID1",             ReadTable[i].ArrowID1 },
                    { "ArrowID2",             ReadTable[i].ArrowID2 },
                    { "ArrowID3",             ReadTable[i].ArrowID3 },
                    { "ArrowID4",             ReadTable[i].ArrowID4 },
                    { "ArrowID5",             ReadTable[i].ArrowID5 }
                };

                GameRuleTable.Add(_GameRuleTable);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------ItemTable

        var ItemTable = new List<Dictionary<string, object>>();// ItemTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.ItemTable>(sheetName: "ItemTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                var _ItemTable = new Dictionary<string, object>
                {
                    { "ItemID",      ReadTable[i].ItemID },
                    { "Name",        ReadTable[i].Name },
                    { "ItemType",    ReadTable[i].ItemType },
                    { "ItemSubType", ReadTable[i].ItemSubType },
                    { "Value1",      ReadTable[i].Value1 },
                    { "Value2",      ReadTable[i].Value2 },
                    { "Value3",      ReadTable[i].Value3 }
                };

                ItemTable.Add(_ItemTable);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------ArrowTable

        var ArrowTable = new List<Dictionary<string, object>>();// ArrowTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.ArrowTable>(sheetName: "ArrowTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                var _ArrowTable = new Dictionary<string, object>
                {
                    { "ArrowID",    ReadTable[i].ArrowID },
                    { "Name",       ReadTable[i].Name },
                    { "Damage",     ReadTable[i].Damage },
                    { "AbnormalID", ReadTable[i].AbnormalID },
                    { "Range",      ReadTable[i].Range }
                };

                ArrowTable.Add(_ArrowTable);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------NPCTable

        var NPCTable = new List<Dictionary<string, object>>();// NPCTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.NPCTable>(sheetName: "NPCTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                var _NPCTable = new Dictionary<string, object>
                {
                    { "NPCID",   ReadTable[i].NPCID },
                    { "MaxHP",   ReadTable[i].MaxHP },
                    { "NPCPath", ReadTable[i].NPCPath }
                };

                NPCTable.Add(_NPCTable);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------NPCPosTable

        var NPCPosTable = new List<Dictionary<string, object>>();// NPCPosTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.NPCPosTable>(sheetName: "NPCPosTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                var _NPCPosTable = new Dictionary<string, object>
                {
                    { "GameRuleID", ReadTable[i].GameRuleID },
                    { "NPCID",      ReadTable[i].NPCID },
                    { "Position_x", ReadTable[i].Position_x },
                    { "Position_y", ReadTable[i].Position_y },
                    { "Position_z", ReadTable[i].Position_z },
                    { "Rotation_x", ReadTable[i].Rotation_x },
                    { "Rotation_y", ReadTable[i].Rotation_y },
                    { "Rotation_z", ReadTable[i].Rotation_z }
                };

                NPCPosTable.Add(_NPCPosTable);
            }
        }

        //----------------------------------------------------------------------------------------------------------------------------------SpawnGroupTable

        var SpawnGroupTable = new List<Dictionary<string, object>>();// SpawnGroupTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.SpawnGroupTable>(sheetName: "SpawnGroupTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                if (ReadTable[i].GameRuleID != gameModeState) // 현재 설정한 게임모드와 다른 데이터를 남겨둠
                {
                    var _SpawnGroupTable = new Dictionary<string, object>
                    {
                        { "GameRuleID",   ReadTable[i].GameRuleID },
                        { "SpawnGroupID", ReadTable[i].SpawnGroupID },
                        { "Name",         ReadTable[i].Name },
                        { "SpawnType",    ReadTable[i].SpawnType },
                        { "SpawnCount",   ReadTable[i].SpawnCount }
                    };

                    SpawnGroupTable.Add(_SpawnGroupTable);
                }
            }
        }
        for (int i = 0; i < ItemGroupManager.transform.childCount; i++)
        {
            var _SpawnGroupTable = new Dictionary<string, object>
            {
                { "GameRuleID",   gameModeState },
                { "SpawnGroupID", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnGroupID },
                { "Name",         ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().Name },
                { "SpawnType",    ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnType},
                { "SpawnCount",   ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnCount}
            };

            SpawnGroupTable.Add(_SpawnGroupTable);

        }

        //----------------------------------------------------------------------------------------------------------------------------------SpawnGroupItemTable

        var SpawnGroupItemTable = new List<Dictionary<string, object>>();// SpawnGroupItemTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.SpawnGroupItemTable>(sheetName: "SpawnGroupItemTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                if (ReadTable[i].GameRuleID != gameModeState) // 현재 설정한 게임모드와 다른 데이터를 남겨둠
                {
                    var _SpawnGroupItemTable = new Dictionary<string, object>
                    {
                        { "GameRuleID",   ReadTable[i].GameRuleID },
                        { "SpawnGroupID", ReadTable[i].SpawnGroupID },
                        { "Name",         ReadTable[i].Name },
                        { "ItemID",       ReadTable[i].ItemID },
                        { "Count",        ReadTable[i].Count }
                    };

                    SpawnGroupItemTable.Add(_SpawnGroupItemTable);
                }
            }
        }
        using (var stream = File.OpenRead(path))
        {
            var ItemTable_ReadTable = stream.Query<FileData.ItemTable>(sheetName: "ItemTable").ToList(); // SpawnGroupItemTable ItemID과 비교할 ReadTable가져오기

            for (int i = 0; i < ItemGroupManager.transform.transform.childCount; i++)
            {
                for (int j = 0; j < ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>()._ItemComponents.Count; j++)
                {
                    string _Name = ""; // SpawnGroupItemTable ItemID와 ItemTable의 ItemID를 비교 후 동일한 ItemID

                    for (int k = 0; k < ItemTable.Count; k++)
                    {
                        if (ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>()._ItemComponents[j].ItemID == ItemTable_ReadTable[k].ItemID)
                            _Name = ItemTable_ReadTable[k].Name;
                    }

                    var _SpawnGroupItemTable = new Dictionary<string, object>
                        {
                        { "GameRuleID",   gameModeState },
                        { "SpawnGroupID", ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>().SpawnGroupID },
                        { "Name",         _Name },
                        { "ItemID",       ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>()._ItemComponents[j].ItemID},
                        { "Count",        ItemGroupManager.transform.GetChild(i).GetComponent<ItemGroupData>()._ItemComponents[j].Count}
                    };
                    SpawnGroupItemTable.Add(_SpawnGroupItemTable);
                }
            }
        }



        //----------------------------------------------------------------------------------------------------------------------------------SpawnGroupPositionTable

        var SpawnGroupPositionTable = new List<Dictionary<string, object>>();// SpawnGroupPositionTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.SpawnGroupPositionTable>(sheetName: "SpawnGroupPositionTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                if (ReadTable[i].GameRuleID != gameModeState) // 현재 설정한 게임모드와 다른 데이터를 남겨둠
                {
                    var _SpawnGroupPositionTable = new Dictionary<string, object>
                    {
                        { "GameRuleID",   ReadTable[i].GameRuleID },
                        { "SpawnGroupID", ReadTable[i].SpawnGroupID },
                        { "x",            ReadTable[i].x },
                        { "y",            ReadTable[i].y },
                        { "z",            ReadTable[i].z }
                    };

                    SpawnGroupPositionTable.Add(_SpawnGroupPositionTable);

                }
            }
        }

        for (int i = 0; i < ItemSpawnGroup.transform.childCount; i++)
        {
            var _SpawnGroupPositionTable = new Dictionary<string, object>
            {
                { "GameRuleID", gameModeState },
                { "SpawnGroupID", ItemSpawnGroup.transform.GetChild(i).GetComponent<I_SpawnData>().SpawnGroupID },
                { "x", ItemSpawnGroup.transform.GetChild(i).transform.position.x},
                { "y", ItemSpawnGroup.transform.GetChild(i).transform.position.y},
                { "z", ItemSpawnGroup.transform.GetChild(i).transform.position.z}
            };

            SpawnGroupPositionTable.Add(_SpawnGroupPositionTable);
        }

        //----------------------------------------------------------------------------------------------------------------------------------StartPositionTable

        var StartPositionTable = new List<Dictionary<string, object>>();// StartPositionTable에 데이터 등록
        using (var stream = File.OpenRead(path))
        {
            var ReadTable = stream.Query<FileData.StartPositionTable>(sheetName: "StartPositionTable").ToList();

            for (int i = 0; i < ReadTable.Count; i++)
            {
                if (ReadTable[i].GameRuleID != gameModeState) // 현재 설정한 게임모드와 다른 데이터를 남겨둠
                {
                    var _StartPositionTable = new Dictionary<string, object>
                    {
                        { "GameRuleID",    ReadTable[i].GameRuleID },
                        { "PositionType",  ReadTable[i].PositionType },
                        { "positionindex", ReadTable[i].positionindex },
                        { "X",             ReadTable[i].X },
                        { "Y",             ReadTable[i].Y },
                        { "Z",             ReadTable[i].Z }
                    };

                    StartPositionTable.Add(_StartPositionTable);

                }
            }
        }

        for (int i = 0; i < PlayerSpawnGroup.transform.childCount; i++)
        {
            var _StartPositionTable = new Dictionary<string, object>
            {
                { "GameRuleID", gameModeState },
                { "PositionType", PlayerSpawnGroup.transform.GetChild(i).GetComponent<P_SpawnData>().PositionType },
                { "positionindex", PlayerSpawnGroup.transform.GetChild(i).GetComponent<P_SpawnData>().positionindex },
                { "X", PlayerSpawnGroup.transform.GetChild(i).transform.position.x},
                { "Y", PlayerSpawnGroup.transform.GetChild(i).transform.position.y},
                { "Z", PlayerSpawnGroup.transform.GetChild(i).transform.position.z}
            };

            StartPositionTable.Add(_StartPositionTable);
        }

        //----------------------------------------------------------------------------------------------------------------------------------

        var sheets = new Dictionary<string, object>// Sheet 등록
        {
            ["AbnormalTable"] = AbnormalTable,
            ["GameRuleTable"] = GameRuleTable,
            ["ItemTable"] = ItemTable,
            ["ArrowTable"] = ArrowTable,
            ["NPCTable"] = NPCTable,
            ["NPCPosTable"] = NPCPosTable,
            ["SpawnGroupTable"] = SpawnGroupTable,
            ["SpawnGroupItemTable"] = SpawnGroupItemTable,
            ["SpawnGroupPositionTable"] = SpawnGroupPositionTable,
            ["StartPositionTable"] = StartPositionTable
        };

        //----------------------------------------------------------------------------------------------------------------------------------

        if (!File.Exists(path))// xsls파일이 경로에 존재하지 않으면 새로운 파일 생성
        {
            Debug.Log("엑셀 파일 없음");
            Debug.Log("새로운 파일 생성");

            MiniExcel.SaveAs(path, sheets);
        }
        else
        {
            using (var stream = new FileStream(path, FileMode.Truncate))// xsls파일이 경로에 존재하면 저장
            {
                stream.SaveAs(sheets);
                Debug.Log("파일 저장");
            }
        }
    }

}
