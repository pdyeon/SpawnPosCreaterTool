using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_SpawnData : MonoBehaviour
{
    public int PositionType;

    public int positionindex;

    public void GetPositionType(int _PositionType)
    {
        PositionType = _PositionType;
    }

    public void Getpositionindex(int _positionindex)
    {
        positionindex = _positionindex;
    }
}
