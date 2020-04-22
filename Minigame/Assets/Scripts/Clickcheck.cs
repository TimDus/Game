using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Clickcheck : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public int machine;

    private TimerHub timer;
    // Start is called before the first frame update
    void Start()
    {
        timer = FindObjectOfType<TimerHub>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerUp(PointerEventData pointerEventData)
    {
        timer.MachinePressed(machine);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        
    }
}
