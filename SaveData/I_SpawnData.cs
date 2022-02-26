using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class I_SpawnData : MonoBehaviour
{
    public int SpawnGroupID;

    public void GetItemGroup(int _SpawnGroupID)
    {
        SpawnGroupID = _SpawnGroupID;
    }
}
