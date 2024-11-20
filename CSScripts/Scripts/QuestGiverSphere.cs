using UnityEngine;
using UnityEngine.UI; 
using TMPro;

public class QuestGiverSphere : MonoBehaviour
{
    public GameObject questWindow; 
    public Button acceptButton;
    public Button declineButton;
    public TextMeshProUGUI questObjectiveText; 
    public Transform vehicle; 
    public CheckpointsLogic checkpointsLogic;

    private CollectCheckpointsQ currentQuest;
    public bool onCooldown = false; 
    private float cooldownTime = 2f; 

    void Start()
    {
        questWindow.SetActive(false);
        acceptButton.onClick.AddListener(AcceptQuest);
        declineButton.onClick.AddListener(DeclineQuest);
    }

    void Update()
    {
        if (Vector3.Distance(vehicle.position, transform.position) < 3f)
        {
            if (!questWindow.activeSelf && !onCooldown)
            {
                questWindow.SetActive(true);
                DisplayQuestInfo();
                Time.timeScale = 0; 
            }
        }
        else
        {
            if (questWindow.activeSelf)
            {
                questWindow.SetActive(false);
                Time.timeScale = 1; 
            }
        }
    }

    private void DisplayQuestInfo()
    {
        currentQuest = new CollectCheckpointsQ("Checkpoint Collector", "Collect 5 checkpoints to complete the quest", 5);
        questObjectiveText.text = currentQuest.Description;
    }

    private void AcceptQuest()
    {
        currentQuest.StartQuest();
        questWindow.SetActive(false);
        gameObject.SetActive(false); 
        checkpointsLogic.SpawnCheckpoints();
        Time.timeScale = 1; 
    }

    private void DeclineQuest()
    {
        questWindow.SetActive(false);
        onCooldown = true; 
        Time.timeScale = 1; 
        Invoke(nameof(ResetCooldown), cooldownTime); 
    }

    private void ResetCooldown()
    {
        onCooldown = false;
    }

    public void CompleteQuest()
    {
        onCooldown = true;
        Invoke(nameof(ResetCooldown), 3f);
    }
}
