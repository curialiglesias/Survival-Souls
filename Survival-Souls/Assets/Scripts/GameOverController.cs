using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;
using System.Text.RegularExpressions;
using TMPro;

public class GameOverController : MonoBehaviour
{
    public TextMeshProUGUI TimeSurvivedText;
    public TextMeshProUGUI SoulPointsText;

    private void Start()
    {
        TimeSurvivedText.text = "Time Survived: " + (int)Clock.SharedInstance.time + "s";
        SoulPointsText.text = "SoulPoints: " + (int)(Clock.SharedInstance.time * (1 + (JSONSaving.SharedInstance.playerData.bonusPoints * 0.25f)));
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");

    }
}
