using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temperature : MonoBehaviour
{
    private string scale;
    private int celsius, fahrenheit;
    public int temperature;

    public GameObject characterC;
    public GameObject characterF;
    private float posCelsius = 0.04f, posFah = 0.022f, posTemperature; // visual position
    private bool celsiusCharacter;

    //*****************************************************************
    void Start()
    {
        scale = "C";
        //CharacterPositionIn();
    }
 //*****************************************************************
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (scale == "C") 
            { 
                celsius = temperature;
                fahrenheit = (temperature * 9) / 5 + 32;
                temperature = fahrenheit;
                scale = "F";

                posTemperature = posFah;
                celsiusCharacter = false;
            }
            else if(scale == "F") 
            {
                fahrenheit = temperature;
                celsius = (temperature - 32) / 9 * 5;
                temperature = celsius;
                scale = "C";

                posTemperature = posCelsius;
                celsiusCharacter = true;
            }
            CharacterPositionIn(celsiusCharacter);
            Debug.Log(temperature + "°" + scale);
        }
    }
//*****************************************************************************************************************************************************
    private void CharacterPositionIn(bool isCelsius) // define a posição do character
    {
        float _width = GetComponent<SpriteRenderer>().bounds.size.x; // tamanho do termometro
        float inicialP = (transform.position.x - _width / 4.25f); // posição inicial do termometro
        GameObject characther = isCelsius ? characterC : characterF;

        float characterPositionC = inicialP + (posTemperature * temperature); // posição atual do termometro
        GameObject characterPosC = Instantiate(characther, new Vector3(characterPositionC, transform.position.y, -1.0f), Quaternion.identity);

    }
}
