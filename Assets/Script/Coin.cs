using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public static UnityAction OnGlodCollected;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        OnGlodCollected?.Invoke();
        QuestManager.instance.OnItemCollect("Coin");
        Destroy(gameObject);
    }
}
