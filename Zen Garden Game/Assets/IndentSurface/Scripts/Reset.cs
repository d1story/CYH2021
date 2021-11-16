using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public void reset()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
