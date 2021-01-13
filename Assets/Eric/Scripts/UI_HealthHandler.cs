using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_HealthHandler : MonoBehaviour
{
    public int Health = 6;

    // Start is called before the first frame update
    void Start()
    {
        DisplayHealth(6);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisplayHealth(int v)
    {
        switch (v)
        {
            case 6:
                break;
            case 5:
                break;
            case 4:
                break;
            case 3:
                break;
            case 2;
                break;
            case 1:
                break;
        }
    }
}
