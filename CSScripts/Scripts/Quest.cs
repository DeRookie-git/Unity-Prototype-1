using System;
using UnityEngine;

public abstract class Quest : IEquatable<Quest>
{
    public string QuestName { get; protected set; }
    public string Description { get; protected set; }
    public bool IsAccepted { get; protected set; }
    
    static Quest()
    {
    }

    public Quest()
    {
        InitializeQuest();
    }

    private void InitializeQuest()
    {
        IsAccepted = false;
        CheckpointsLogic checkpointLogic = GameObject.FindObjectOfType<CheckpointsLogic>();
        //checkpointLogic.HideChildrenCheckpoints();
    }

    ~Quest()
    {
        ResetQuest();
    }

    private void ResetQuest()
    {
        CheckpointsLogic checkpointLogic = GameObject.FindObjectOfType<CheckpointsLogic>();
        //checkpointLogic.HideChildrenCheckpoints();
    }

    public abstract void StartQuest();

    public bool Equals(Quest other)
    {
        return QuestName == other.QuestName;
    }
}
