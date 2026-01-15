using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ButtonVR : MonoBehaviour
{
    public GameObject button;
    public UnityEvent onPress;
    public UnityEvent onRelease;
    public GameObject menu;
    GameObject presser;
    AudioSource sound;
    bool isPressed;
    bool isMenuOn;
    

    void Start()
    {
        sound = GetComponent<AudioSource>();
        isPressed = false;
        isMenuOn = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isPressed)
        {
            button.transform.localPosition = new Vector3(0, 0.003f, 0);
            presser = other.gameObject;
            onPress.Invoke();
            sound.Play();
            isPressed = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == presser)
        {
            button.transform.localPosition = new Vector3(0, 0.01f, 0);
            onRelease.Invoke();
            isPressed = false;
        }
    }

    public void ToggleMenu()
    {
        if (isMenuOn == false)
        {
            isMenuOn = true;
            ShowMenu();
        } else
        {
            isMenuOn = false;
            HideMenu();
        }
    }

    private void ShowMenu()
    {
        menu.SetActive(true);
    }

    private void HideMenu()
    {
        menu.SetActive(false);
    }
}
