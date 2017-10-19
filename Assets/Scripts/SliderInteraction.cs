using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderInteraction : MonoBehaviour
{
    public float fillTime = 2f;
    private float timer = 0f;
    private bool gazedAt;

    private Slider mySlider;
    private Coroutine fillBarRoutine;

    const string BUTTON_VR = "ButtonVR";
    const string BUTTON_NEW_GAME = "ButtonNewGame";
    const string BUTTON_INSTRUCTIONS = "ButtonInstructions";
    const string BUTTON_EXIT = "ButtonExit";


    // Use this for initialization
    void Start()
    {
        mySlider = GetComponentInChildren<Slider>();

        if (!mySlider)
        {
            Debug.Log("Slider not defined");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PointerEnter()
    {
        Debug.Log("Slider Pointer enter");
        gazedAt = true;
        fillBarRoutine = StartCoroutine(FillBar());
    }

    private IEnumerator FillBar()
    {
        timer = 0f;

        while (timer < fillTime)
        {
            timer += Time.deltaTime;
            mySlider.value = timer / fillTime;

            yield return null;

            if (gazedAt)
            {
                continue;
            }

            timer = 0f;
            mySlider.value = 0f;
            yield break;
        }

        OnBarFilled();
    }


    private void OnBarFilled()
    {
        Debug.Log("Bar filled");

        string tag = this.transform.tag;

            switch (tag)
            {
                case BUTTON_NEW_GAME:
                    ApplicationManager.StartGame();
                    break;
                case BUTTON_EXIT:
                    ApplicationManager.ExitApplication();
                    break;
                case BUTTON_INSTRUCTIONS:
                    ApplicationManager.ShowInstructions();
                    break;
            }

    }


    public void PointerExit()
    {
        Debug.Log("Slider Pointer exit");
        gazedAt = false;
        if (fillBarRoutine != null)
        {
            StopCoroutine(fillBarRoutine);
        }
    }

    public void PointerDown()
    {
        //Debug.Log("Pointer down");

    }
}
