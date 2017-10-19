using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonInteraction : MonoBehaviour {

    public float gazeTime = 2f;

    private float timer = 0;

    private bool gazedAt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (gazedAt)
        {
            //Debug.Log("Gazed at " + this);
            timer += Time.deltaTime;
            //Debug.Log(timer);

            if (timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject, new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0f;

            }
        }
	}

    public void PointerEnter()
    {
        //Debug.Log("Pointer enter");
        gazedAt = true;
    }

    public void PointerExit()
    {
        ///Debug.Log("Pointer exit");
        gazedAt = false;
    }

    public void PointerDown()
    {
        //Debug.Log("this");
    }
}
