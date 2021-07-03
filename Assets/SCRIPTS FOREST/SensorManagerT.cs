using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class SensorManagerT : MonoBehaviour
{
    SerialPort serialPort = new SerialPort("COM14", 115200);//("COM5", 9600);

    public PulseSphere PulseSphere;
    public BellyCube BellyCube;
    public LigtPoint IntensityLight;
    public ChestCapsule ChestCapsule;
    public PDSensor2 cylinder;
    //public MyWinds MyWinds;

    public const int CHEST_INHALE = 2;
    public const int CHEST_EXHALE = 1;
    public const int BELLY_INHALE = 2;
    public const int BELLY_EXHALE = 1;
    public const int PULSE_INHALE = 2;
    public const int PULSE_EXHALE = 1;

    private int datoP = 0;
    private int datoL = 0;
    private int datoL2 = 0;
    private int datoPant = 0;
    private int stepsL = 0;
    private int stepsL2 = 0;
    private int stepsL2Ant = 0;
    private int stepsLAnt = 0;

    public event Action<int> OnChestValueReceived;
    public event Action<int> OnBellyValueChanged;
    public event Action<int> OnPulseValueChanged;

    string[] vec1;
    void Start()
    {
        serialPort.ReadTimeout = 1;
        serialPort.Open();
    }

    void Update()
    {
        if (serialPort.IsOpen)
        {
            try
            {
                string value = serialPort.ReadLine(); //leemos una linea del puerto serie y la almacenamos en un string
                //print(value);// printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino               
                vec1 = value.Split(',');
                //datoL = (Convert.ToInt32(vec1[1]));
                //datoL2 = (Convert.ToInt32(vec1[0]));

                //Debug.Log("dato : " + vec1[1]);
                //Debug.Log("value : " + vec1[0]);

                string c1 = "chest";
                string c2 = (vec1[0]);
                string b1 = "belly";

                if ((String.Compare(c1, c2)) == 0)
                {
                    datoL2 = (Convert.ToInt32(vec1[1]));//CHEST
                    Debug.Log("chest:" + datoL2);
                }
                else if ((String.Compare(b1, c2)) == 0)
                {
                    datoL = (Convert.ToInt32(vec1[1]));//belly  
                    Debug.Log("belly:" + datoL);

                }

                //SENSOR PULSE -------------------cambio estado-------------------------------------------
                if (datoP == 2 && datoP != datoPant)// cuando recibe 2 y cuando el dato  SEA DIFERENTE DE SU ANTERIOR 1
                {
                    PulseSphere.agrandarS();
                    ///////////////////////print(datoPant);
                }
                else
                {
                    PulseSphere.achicarS();
                }
                datoPant = datoP;//actualizo estados

                //BELLY----CUBE----------------------------------------------------------
                if (datoL == 2)//cuando 1  NO SEA IGUAL a 0 //cuando es 2 y NO ES el anterior (1). 
                {
                    IntensityLight.LightOn();//inhalo: 222 y ilumina
                    //MyWinds.TurbulenceUp();
                    //MyWinds.soundWind();
                    ChestCapsule.PlayFirstBreathAnimation();////////////// CHEST CORRUTINE vol amb forest 
                    
                    stepsL++;//empieza sumando con 1(al prender)- suma solo cuando cambia!!!

                    if (stepsL > 3)//margen error
                    {
                        BellyCube.agrandarC();                                           
                    }
                    ///////print(stepsL);
                }
                else
                {
                    BellyCube.achicarC();
                    IntensityLight.LightOff();
                    //MyWinds.TurbulenceDown();
                                      
                    stepsL = stepsLAnt;//reseteo conteo OK
                }

                //SENSOR L2 --------------CHEST-----------PECHO-----------------
                if (datoL2 == CHEST_INHALE) //cuando respiro 2 Y es diferente dl anterior 1
                {
                    //OnChestValueReceived?.Invoke(datoL2);/////////////////////////

                    stepsL2++;  //cuenta 
                    if (stepsL2 == 3) //margen error
                    {
                        ChestCapsule.agrandarCa();
                        stepsL2 = stepsL2Ant;
                    }
                    //////////print(stepsL2);
                }
                else
                {
                    ChestCapsule.achicarCa();
                    stepsL2 = stepsL2Ant;//reseteo conteo
                }

                ///////////////////PD//////////////////////////////////////////
                if (datoL2 == 2)
                {
                    /////////Debug.Log("datoStrech");
                    cylinder.SoundUp();
                }
                else
                {
                    cylinder.SoundDown();
                }

            }
            catch (System.Exception ex)
            {
                ex = new System.Exception();
            }
        }

    }

    private void OnGUI()
    {
        //GUIStyle style = new GUIStyle();
        //style.richText = true;

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(5, 5, 80, 200), "CHEST " + datoL2);
        GUI.Label(new Rect(5, 20, 80, 200), "BELLY " + datoL);

        //GUILayout.Label("<size=30> <color=yellow>CHEST</color> + datoL2</size>", style);
    }

}
