using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabels : MonoBehaviour
{
    public SensorManagerT datos;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnGUI()
    {
        //GUIStyle style = new GUIStyle();
        //style.richText = true;

        GUI.contentColor = Color.black;
        GUI.Label(new Rect(5, 5, 80, 200), "CHEST " + datos.datoL2);
        GUI.Label(new Rect(5, 20, 80, 200), "BELLY " + datos.datoL);

        //GUILayout.Label("<size=30> <color=yellow>CHEST</color> + datoL2</size>", style);

        //GUIStyle style = new GUIStyle();
        //style.richText = true;

        //GUILayout.Label("<size=30>hola <color=yellow>HOLA</color> chau</size>", style);
    }
}
