using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCursor : MonoBehaviour
{
  
    void Update()
    {
        Cursor.lockState = CursorLockMode.None;
    }
}
