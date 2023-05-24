using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class GreyollLegacy : MonoBehaviour
{

    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        slider.gameObject.SetActive(true);
        slider.GetComponent<HealthBar>().SetMaxHealth(this.GetComponent<Enemy>().HP);
    }

    private void Update()
    {
        slider.GetComponent<HealthBar>().SetHealth(this.GetComponent<Enemy>().HP);

    }


}
