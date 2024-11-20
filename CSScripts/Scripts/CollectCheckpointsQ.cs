using System.Collections.Generic;

public sealed class CollectCheckpointsQ : Quest
{
    public int RequiredCheckpoints { get; private set; }
    public List<Checkpoints> CollectedCheckpoints { get; private set; }

    public CollectCheckpointsQ(string questName, string description, int requiredCheckpoints)
    {
        QuestName = questName;
        Description = description;
        RequiredCheckpoints = requiredCheckpoints;
        CollectedCheckpoints = new List<Checkpoints>();
    }

    public override void StartQuest()
    {
        IsAccepted = true;

    }
}
