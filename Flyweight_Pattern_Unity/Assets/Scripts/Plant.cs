using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Plant : MonoBehaviour
{
    [SerializeField] private PlantData info;
    private SetPlantInfo spi;

    void Start()
    {
        spi = GameObject.FindGameObjectWithTag("PlantInfo").GetComponent<SetPlantInfo>();
    }

    void OnMouseDown()
    {
        spi.OpenPlantPanel();
        spi.plantName.text = info.PlantName;
        spi.threatLevel.text = info.PlantThreat.ToString();
        spi.plantIcon.GetComponent<RawImage>().texture = info.Icon;
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player" && info.PlantThreat == PlantData.THREAT.High)
        {
            PlayerController.dead = true;
        }
    }
}
