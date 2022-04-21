using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum QuestType
{
    COLLECT,
    KILL,
    ESCORT,
    DEVIVERY,

    SIZE,
}

public class Quest : MonoBehaviour
{
    public UnityAction<Quest> OnStart;
    public UnityAction<Quest> OnComplete;

    public bool bActive;  // 퀘스트가 가능한 상황
    public bool bStart = false;  // 퀘스트가 수락됐을 때
    public bool bFinish = false;  // 퀘스트가 완료됐을 때
    public QuestType type;
    public string title;
    [TextArea]
    public string description;
    public string requirement;
    public int curAmount;
    public int requireAmount;
    public int expReward;
    public int goldReward;

    public Conversation accept, progress, complete;

    private void Start()
    {
        OnStart += QuestMana ger.instance.QuestStart;
        OnComplete += QuestManager.instance.QuestComplete;
    }


    public void Accept()
    {
        OnStart?.Invoke(this);
        bStart = true;
        Debug.Log(title + " 가 수락되었습니다.");
    }

    public void Progress()
    {
        curAmount++;
        Debug.Log(title + " 가 진행되었습니다. - " + curAmount + "/" + requireAmount);
    }

    public void Complete()
    {
        OnComplete?.Invoke(this);
        bActive = true;
        Debug.Log(title + " 가 완료되었습니다.");
    }

    public bool ReAction()
    {
        if (!bStart) // 수락 전
        {
            bool reAction = accept.ReAction();
            if (reAction)
            {
                return true;
            }
            else
            {
                Accept();
                return false;
            }
        }
        else if (!bFinish) // 진행 중
        {
            if (curAmount < requireAmount)
            {
                return progress.ReAction();
            }
            else
            {
                bFinish = true;
                return ReAction();
            }
        }
        else  // 완료 시 
        {
            bool reAction = complete.ReAction();
            if (reAction)
            {
                return true;
            }
            else
            {
                Complete();
                return false;
            }
        }
    }
}
