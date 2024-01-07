using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class AmmoUI : MonoBehaviour
{
    public DaggerPlayVersion2 daggerPlayV2;
 // public SnowGun snowGun;
    public TextMeshProUGUI text;
    //public TextMeshProUGUI snowText;

    void Start()
    {
        UpdateDaggerText();
       // UpdateBulletText();
    }

    private void Update()
    {
        UpdateDaggerText();
       // UpdateBulletText();
    }

    public void UpdateDaggerText()
    {
        text.text = $"{daggerPlayV2.currentClip}";
    }

   // public void UpdateBulletText()
   // {
    //    snowText.text = $"{snowGun.currentClip}";
   // }
}
