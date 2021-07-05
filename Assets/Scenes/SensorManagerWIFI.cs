using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO.Ports;
using System;

public class SensorManagerWIFI : MonoBehaviour
{
    public string port;
    public int baudrate;
    private SerialPort sp;
    bool isStreaming = false;
    public GameObject sphere;

    public Text txtBelly;
    public Text txtChest;

    private int datoP = 0;
    private int datoL = 0;
    private int datoL2 = 0;
    private int datoL2ant = 0;

    string[] vec1;

    void Start()
    {
        Open();
    }

    
    void Update()
    {
        if (isStreaming) //(serialPort.IsOpen)
        {
            string value = ReadSerialPort();
            //print(value);
            vec1 = value.Split(',');

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

            txtBelly.text = "belly: " + datoL;
            txtChest.text = "chest: " + datoL2;

            /////////////////////////CHEST 
            if (datoL2 == 2)
            {
                Debug.Log("+CHEST+");
            }


            ////////////////////////BELLY 
            if (datoL == 2)
            {
                sphere.transform.localScale = new Vector3(10, 10, 10);

            }
            else 
            {
                sphere.transform.localScale = new Vector3(5, 5, 5);
            }

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







