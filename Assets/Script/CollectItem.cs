using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class CollectItem : MonoBehaviour
{
    public ItemData data;
    new public string name;

    protected void Collect()
    {
        QuestManager.instance.OnItemCollect(name);
        // 아이템 변환 작업
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Collect();
        Destroy(gameObject);
    }
}
