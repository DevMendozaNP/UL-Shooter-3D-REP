using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using TMPro;

public class Timer : MonoBehaviour
{
    public GameObject GO;
    private float Cooldown = 15;
    private float NewCooldown = 15;
    private int tiempo = 15;
    private TextMeshProUGUI texto;

    void Start()
    {
        texto = GO.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        //texto.text = "Siguiente Horda " + Cooldown.ToString;
        texto.text = "Siguiente Horda " + tiempo;
        Cooldown -=  Time.deltaTime;
        tiempo = Mathf.RoundToInt(Cooldown);
        
        if (Cooldown <= 0)
        {
            NewCooldown -= 5;
            Cooldown = Mathf.Clamp(NewCooldown,10,100);
        }
    }
}
