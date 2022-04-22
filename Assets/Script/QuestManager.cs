using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    private static QuestManager _instance;
    public static QuestManager instance
    {
        get
        {
            return _instance;
        }
    }

    Quest curQuests;

    private void Awake()
    {
        _instance = this;
    }

    private void Update()
    {
        if  (Input.GetKeyDown(KeyCode.Q))
        {
            
        }
    }
    public void QuestStart(Quest quest)
    {
        // 퀘스트 창에 현재 퀘스트 띄워주기
        Debug.Log("퀘스트 시작");
        Debug.Log("퀘스트 이름 : " + quest.title);
        Debug.Log("퀘스트 설명 : " + quest.description);

        curQuests = quest;
        Coin.OnGlodCollected += curQuests.Progress;
    }

    public void QuestComplete(Quest quest)
    {
        // 보상 진행
        Debug.Log("퀘스트 완료");
        Debug.Log("퀘스트 보상 골드 : " + quest.goldReward);
        Debug.Log("퀘스트 보상 경험치 : " + quest.expReward);
        
        Coin.OnGlodCollected -= curQuests.Progress;
        curQuests = null;
    }

    public void OnItemCollect(string itemName)
    {
        if (null == curQuests)
        {
            return; 
        }
        if (curQuests.type != QuestType.COLLECT)
        {
            return;
        }
        if (curQuests.requirement != itemName)
        {
            return;
        }

        curQuests.Progress();
    }
}
