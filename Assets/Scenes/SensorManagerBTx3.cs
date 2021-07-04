using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class SensorManagerBTx3 : MonoBehaviour
{
    public string port;
    public int baudrate;
    private SerialPort sp;
    bool isStreaming = false;
    public GameObject sphere;

    public Text txt1;
    public Text txt2;
    public Text txt3;

    private int datoP = 0;
    private int datoL = 0;
    private int datoL2 = 0;
    private int datoL2ant = 0;

    void Start()
    {
        Open();
    }

    
    void Update()
    {
        if (isStreaming) //(serialPort.IsOpen)
        {
           string value = ReadSerialPort(); //leemos una linea del puerto serie y la almacenamos en un string
            if (value != null & float.Parse(value) >= 1.0f)
            {
                //Debug.Log(value);

                //print(value);// printeamos la linea leida para verificar que leemos el dato que manda nuestro Arduino
                string[] vec3 = value.Split(','); //Separamos el String leido valiendonos de las comas y almacenamos los valores en un array.

                datoP = (Convert.ToInt32(vec3[2]));//chest
                datoL = (Convert.ToInt32(vec3[1]));//belly
                datoL2 = (Convert.ToInt32(vec3[0]));//pulse

                txt1.text = "chest: " + datoP;

                txt3.text = "pulse: " + datoL2;
            }




            ////////////////CHEST 
            if (datoP >= 20)
                {
                    Debug.Log("+CHEST+");
                }

                if (datoP < 20)
                {
                    //Debug.Log("-CHEST-");
                }

                //////////////BELLY 
                if (datoL >= 3)
                {

                sphere.transform.localScale = new Vector3(datoL, datoL, datoL);
                txt2.text = "belly: " + datoL;
                Debug.Log("BELLY:" + datoL);

                }

                if (datoL < 3)
                {
                    //Debug.Log("-BELLY-");
                }

                //SENSOR PULSE -------------------cambio estado-------------------------------------------
                if (datoL2 == 2 && datoL2 != datoL2ant)// cuando recibe 2 y cuando el dato  SEA DIFERENTE DE SU ANTERIOR 1
                {
                    //PulseSphere.agrandarS();
                    print(datoL2ant);
                }
                else
                {
                    //PulseSphere.achicarS();
                }
                datoL2ant = datoL2;//actualizo estados
        }

    }

    public void Open()
    {
        isStreaming = true;
        sp = new SerialPort(port, baudrate);
        sp.ReadTimeout = 1;
        sp.Open();//this open the serial port
        Debug.Log("Port open OK");
    }

    public string ReadSerialPort(int timeout = 1)
    {
        string message;
        sp.ReadTimeout = timeout;

        try
        {
            message = sp.ReadLine();
            return message;
        }
        catch (TimeoutException)
        {
            return null;
        }
    }

    public void Close()
    {
        sp.Close();
    }



}







