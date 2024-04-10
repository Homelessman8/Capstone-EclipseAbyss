using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class KillCounter : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    int Kills;

    void Update()
    {
        ShowKills();
    }
    private void ShowKills()
    {
        counterText.text = Kills.ToString();
    }
    public void AddKill()
    {
        Kills++;
    }
}
