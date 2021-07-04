using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;
using UnityEngine.UI;
using System;

public class PuertoSerie : MonoBehaviour
{
    public string port = "COM14";
    public int baudrate = 115200;
    private SerialPort sp;
    bool isStreaming = false;

    public Text txt;

    void Start()
    {
        Open();
    }


    void Update()
    {
        if (isStreaming)
        {
            string value = ReadSerialPort();

            if (value != null & float.Parse(value) >= 1.0f)
            {
                Debug.Log(value);
                txt.text = "belly: " + value;
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

    public void Close ()
    {
        sp.Close();
    }
        
}
