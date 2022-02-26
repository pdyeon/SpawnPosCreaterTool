using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGroupData : MonoBehaviour
{
    public Color GroupColor = Color.yellow;

    public int SpawnGroupID;
    public string Name;

    public int SpawnType;
    public int SpawnCount;

    public List<ItemComponents> _ItemComponents;

    [System.Serializable]
    public class ItemComponents
    {
        public int ItemID;
        public int Count;
    }
}
