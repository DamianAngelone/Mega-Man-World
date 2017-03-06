using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Energy : MonoBehaviour
{

    public Slider energyBarSlider;  //reference for slider
    public Slider healthBarSlider;  //reference for slider

    // Update is called once per frame
    void Update()
    {

        energyBarSlider.value = GetComponent<TimerForPerspective>().timer/10;  //reduce health
        healthBarSlider.value = GetComponent<TimerForPerspective>().health/10;  //reduce health
    }
}
