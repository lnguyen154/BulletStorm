using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TMP_Text killText;

    private int killCount = 0;

    void Start()
    {
        // Ensure you've assigned the TextMeshPro and UI Text components in the Inspector
        if (killText == null)
        {
            Debug.LogError("TextMeshPro component is not assigned!");
        }
        UpdateKillText();
    }

    void UpdateKillText()
    {
        killText.text = "KILLS: " + killCount.ToString();
    }

    public void EnemyKilled()
    {
        killCount++;
        Debug.Log(killCount.ToString());
        UpdateKillText();
    }
}
