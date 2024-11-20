using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckpointsLogic : MonoBehaviour
{
    public List<Checkpoints> checkpoints;
    public Transform vehicle;
    private int currentCheckpoint = 0;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    void Start()
    {
        InitializeCheckpoints();
        UpdateScoreDisplay();
    }

    private void InitializeCheckpoints()
    {
        foreach (Checkpoints wp in checkpoints)
        {
            wp.vehicle = vehicle;
            wp.isCollected = false;
            wp.gameObject.SetActive(false);
        }
    }

    public void SpawnCheckpoints()
    {
        foreach (var wp in checkpoints)
        {
            wp.gameObject.SetActive(true);
        }
        UpdateCheckpointsColors();
    }

    void Update()
    {
        if (currentCheckpoint < checkpoints.Count)
        {
            foreach (Checkpoints wp in checkpoints)
            {
                wp.UpdateDistance();
            }

            if (Vector3.Distance(vehicle.position, checkpoints[currentCheckpoint].transform.position) < 3f)
            {
                if (!checkpoints[currentCheckpoint].isCollected && 
                    (currentCheckpoint == checkpoints.Count - 1 || 
                    checkpoints[currentCheckpoint].activeColor == Color.green))
                {
                    checkpoints[currentCheckpoint].Collect();
                    score++;
                    UpdateScoreDisplay();
                }

                if (currentCheckpoint < checkpoints.Count - 1)
                {
                    currentCheckpoint++;
                }
                UpdateCheckpointsColors();
            }
        }
    }

    void UpdateCheckpointsColors()
    {
        for (int i = 0; i < checkpoints.Count; i++)
        {
            if (checkpoints[i].isCollected)
            {
                checkpoints[i].SetColor(checkpoints[i].completedColor);
                checkpoints[i].gameObject.SetActive(false);
            }
            else if (i < currentCheckpoint)
            {
                checkpoints[i].SetColor(checkpoints[i].completedColor);
                checkpoints[i].gameObject.SetActive(false);
            }
            else if (i == currentCheckpoint)
            {
                checkpoints[i].SetColor(checkpoints[i].activeColor);
                checkpoints[i].gameObject.SetActive(true);
            }
            else
            {
                checkpoints[i].SetColor(checkpoints[i].nextColor);
                checkpoints[i].gameObject.SetActive(false);
            }
        }
    }

    void UpdateScoreDisplay()
    {
        if (scoreText != null)
        {
            scoreText.text = " " + score;
        }
    }
}
