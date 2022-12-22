using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckpointsManager : MonoBehaviour
{
    [SerializeField] private List<CheckPoint> checkpoints;
    [SerializeField] private List<CheckpointUI> checkPointsContainer;

    private void OnEnable()
    {
        ResetGameState();
        InitializeCheckpoints();
        EventsManager.onResetState += ResetGameState;
        EventsManager.onCheckpointReached += OnCheckpointReached;   
    }
    private void OnDestroy()
    {
        EventsManager.onCheckpointReached -= OnCheckpointReached;
        EventsManager.onResetState -= ResetGameState;
    }
    private void InitializeCheckpoints()
    {
        for(int i = 0; i < checkPointsContainer.Count; i++)
        {
            checkPointsContainer[i].UpdateUI(checkpoints[i]);
        }
    }
    private void OnCheckpointReached(int id)
    {
        print("Checkpoint Reached");
        CheckPoint checkpoint =  checkpoints.Where(item => item.id == id).FirstOrDefault();
        if (checkpoint)
            checkpoint.OnCheckpointCompleted?.Invoke();
    }
    private void ResetGameState()
    {
        foreach (var item in checkpoints)
        {
            item.isCompleted = false;
        }
    }
}
