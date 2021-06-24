using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUILabels : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {

        GUIStyle style = new GUIStyle();
        style.richText = true;

        GUILayout.Label("<size=30>hola <color=yellow>HOLA</color> chau</size>", style);
    }
}
