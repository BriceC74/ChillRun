using System;
using UnityEngine;

/// <summary>
/// Manages the race start countdown and triggers the race start event.
/// </summary>
public class StartRace : MonoBehaviour
{
    private int countdownStep = 0; // 0: initial, 1: 3, 2: 2, 3: 1, 4: GO
    private bool raceStarted = false;

    public event Action OnRaceStart;

    public Light[] OrangeLights;
    public Light[] GreenLights;

    /// <summary>
    /// Updates the countdown and handles the race start.
    /// </summary>
    void Update()
    {
        if (!raceStarted)
        {
            HandleCountdown();
        }
    }

    /// <summary>
    /// Handles the countdown logic based on arrow key presses.
    /// </summary>
    void HandleCountdown()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (countdownStep == 0 || countdownStep == 2)
            {
                countdownStep++;
                OrangeLights[countdownStep].enabled = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (countdownStep == 1 || countdownStep == 3)
            {
                countdownStep++;
                OrangeLights[countdownStep].enabled = true;
            }
        }

        if (countdownStep == 4)
        {
            raceStarted = true;
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