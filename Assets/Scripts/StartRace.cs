using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class StartRace : MonoBehaviour
{
    private int countdownStep = 0; // 0: initial, 1: 3, 2: 2, 3: 1, 4: GO
    private bool raceStarted = false;

    public event Action OnRaceStart;

    public Light[] OrangeLights;
    public Light[] GreenLights;

    void Start()
    {
        Debug.Log(OrangeLights);
        Debug.Log(GreenLights);
    }

    void Update()
    {
        if (!raceStarted)
        {
            HandleCountdown();
        }
    }

    void HandleCountdown()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (countdownStep == 0 || countdownStep == 2)
            {
                countdownStep++;
                OrangeLights[countdownStep].enabled = true;
                Debug.Log(countdownStep == 0 ? "1" : "3");
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (countdownStep == 1 || countdownStep == 3)
            {
                countdownStep++;
                OrangeLights[countdownStep].enabled = true;
                Debug.Log(countdownStep == 2 ? "2" : "GO");
            }
        }

        if (countdownStep == 4)
        {
            raceStarted = true;
            Debug.Log("Race Started!");
            OnRaceStart?.Invoke();

            foreach (var light in OrangeLights)
            {
                light.enabled = false;
            }
            foreach (var light in GreenLights)
            {
                light.enabled = true;
            }
        }
    }
}
