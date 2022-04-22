using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DropData", menuName = "Data/DropData")]
public class DropItemData : ItemData
{
    public override void Use()
    {
        Debug.Log(name + "을 떨어뜨립니다.");
    }
}
