using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CheckpointUI : MonoBehaviour
{
    [Header("UI")]
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private Image tickImage;

    private CheckPoint checkPoint;

    public void UpdateUI(CheckPoint checkPoint)
    {
        this.checkPoint = checkPoint;
        this.checkPoint.OnCheckpointCompleted += OnCheckpointCompleted;

        titleText.text = "* " + checkPoint.title;
    }
    private void OnDestroy()
    {
        this.checkPoint.OnCheckpointCompleted -= OnCheckpointCompleted;
    }
    private void OnCheckpointCompleted()
    {
        print("Checkpoint completed!: " + this.checkPoint.title);
        tickImage.gameObject.SetActive(true);
        this.checkPoint.isCompleted = true;
    }
}
