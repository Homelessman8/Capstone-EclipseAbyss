using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static StatusConditions;

public class PlayerConditionDisplayer : MonoBehaviour
{
    UnitScript player = null;
    List<int> bundles = new();
    int memory = 42;

    GameObject Condition1 = null;
    Image Condition1Image = null;
    Image Condition1Color = null;
    TextMeshProUGUI Condition1Text = null;
    GameObject Condition2 = null;
    Image Condition2Image = null;
    Image Condition2Color = null;
    TextMeshProUGUI Condition2Text = null;
    GameObject Condition3 = null;
    Image Condition3Image = null;
    Image Condition3Color = null;
    TextMeshProUGUI Condition3Text = null;
    GameObject Condition4 = null;
    Image Condition4Image = null;
    Image Condition4Color = null;
    TextMeshProUGUI Condition4Text = null;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<UnitScript>();
        Condition1 = transform.Find("Condition1").gameObject;
        Condition2 = transform.Find("Condition2").gameObject;
        Condition3 = transform.Find("Condition3").gameObject;
        Condition4 = transform.Find("Condition4").gameObject;
        Condition1Color = Condition1.transform.Find("Color").GetComponent<Image>();
        Condition2Color = Condition2.transform.Find("Color").GetComponent<Image>();
        Condition3Color = Condition3.transform.Find("Color").GetComponent<Image>();
        Condition4Color = Condition4.transform.Find("Color").GetComponent<Image>();
        Condition1Image = Condition1Color.transform.GetChild(0).GetComponent<Image>();
        Condition2Image = Condition2Color.transform.GetChild(0).GetComponent<Image>();
        Condition3Image = Condition3Color.transform.GetChild(0).GetComponent<Image>();
        Condition4Image = Condition4Color.transform.GetChild(0).GetComponent<Image>();
        Condition1Text = Condition1.GetComponentInChildren<TextMeshProUGUI>();
        Condition2Text = Condition2.GetComponentInChildren<TextMeshProUGUI>();
        Condition3Text = Condition3.GetComponentInChildren<TextMeshProUGUI>();
        Condition4Text = Condition4.GetComponentInChildren<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.Conditions.Count != memory)
        {
            memory = player.Conditions.Count;
            bundles.Clear();
            foreach (Status condition in player.Conditions)
            {
                if (condition.IsDisplayedOnStatBar)
                {
                    bundles.Add(player.Conditions.IndexOf(condition));
                }
            }
        }
        if (bundles.Count > 0) // Condition 1
        {
            Condition1.SetActive(true);
            Condition1Color.color = player.Conditions[bundles[0]].StatusColor;
            Condition1Text.text = player.Conditions[bundles[0]].DisplayText;
            Condition1Text.color = player.Conditions[bundles[0]].StatusColor;
            Condition1Image.sprite = player.Conditions[bundles[0]].StatBarSprite;
        } else
        {
            Condition1.SetActive(false);
        }
        if (bundles.Count > 1) // Condition 2
        {
            Condition2.SetActive(true);
            Condition2Color.color = player.Conditions[bundles[1]].StatusColor;
            Condition2Text.text = player.Conditions[bundles[1]].DisplayText;
            Condition2Text.color = player.Conditions[bundles[1]].StatusColor;
            Condition2Image.sprite = player.Conditions[bundles[1]].StatBarSprite;
        } else
        {
            Condition2.SetActive(false);
        }
        if (bundles.Count > 2) // Condition 3
        {
            Condition3.SetActive(true);
            Condition3Color.color = player.Conditions[bundles[2]].StatusColor;
            Condition3Text.text = player.Conditions[bundles[2]].DisplayText;
            Condition3Text.color = player.Conditions[bundles[2]].StatusColor;
            Condition3Image.sprite = player.Conditions[bundles[2]].StatBarSprite;
        } else
        {
            Condition3.SetActive(false);
        }
        if (bundles.Count > 3) // Condition 4
        {
            Condition4.SetActive(true);
            Condition4Color.color = player.Conditions[bundles[3]].StatusColor;
            Condition4Text.text = player.Conditions[bundles[3]].DisplayText;
            Condition4Text.color = player.Conditions[bundles[3]].StatusColor;
            Condition4Image.sprite = player.Conditions[bundles[3]].StatBarSprite;
        } else
        {
            Condition4.SetActive(false);
        }
        // If there are any more conditions, they are ignored, as we can only hold 4
    }
}
