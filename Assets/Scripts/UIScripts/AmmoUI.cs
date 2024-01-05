using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public DaggerPlayVersion2 daggerPlayV2;
    public TextMeshProUGUI text;

    void Start()
    {
        UpdateDaggerText();
    }

    private void Update()
    {
        UpdateDaggerText();
    }

    public void UpdateDaggerText()
    {
        text.text = $"{daggerPlayV2.currentClip}";
    }
}
