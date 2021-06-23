using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Secuence1 : MonoBehaviour
{
    [Header("Dependencies")]
    public ChestCapsule ChestCapsule;
    public SoundManagerT SoundManagerT;

    public int lastBreathValue = SensorManagerT.CHEST_EXHALE;

    private bool isWaitingForFirstInhale = true;

    [Header("State")]
    public int steps;

    private void OnEnable()
    {
        FindObjectOfType<SensorManagerT>().OnChestValueReceived += UpdateValue;
    }

    private void OnDisable()
    {
        FindObjectOfType<SensorManagerT>().OnChestValueReceived -= UpdateValue;
    }

    private void UpdateValue(int newValue)
    {
        if (isWaitingForFirstInhale && newValue == SensorManagerT.CHEST_INHALE)//2
        {
            isWaitingForFirstInhale = false;
        }

        //PECHO/////////////////////////////////////////////////////////////////PECHO
        if (newValue == SensorManagerT.CHEST_INHALE)//(L2 == 2 && L2 != L2)
        {
            Debug.Log("inhale");
            steps++;

            if (steps == 20)
            {
                SoundManagerT.PlayInstruccion02();
            } 
            else if (steps == 30)
            {
                SoundManagerT.PlayInstruccion03();
            }
            else if (steps == 40)
            {
                SoundManagerT.PlayInstruccion04();
            }
            print(steps);

        }
        else if (newValue == SensorManagerT.CHEST_EXHALE)
        {

            Debug.Log("exhale");
        }


    }

    
}
