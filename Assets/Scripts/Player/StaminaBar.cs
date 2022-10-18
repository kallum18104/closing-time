using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StaminaBar : MonoBehaviour
{

    public Slider staminaBar;

    public float maxStamina = 100;
    public float currentStamina;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);

    public static StaminaBar instance;

    public bool canRun;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        canRun = true;
    }


    private void Update()
    {
        if (currentStamina <= 1)
        {
            canRun = false;
            StartCoroutine(runCool());
        }
        

        staminaBar.value = currentStamina;
    }

    public IEnumerator runCool()
    {
        canRun = false;
        yield return new WaitForSeconds(1.5f);
        canRun = true;
    }
   


}
