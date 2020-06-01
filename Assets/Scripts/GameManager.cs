using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TouchController touchController;
    QuestionManager questionManager;

    void Start()
    {
        Screen.SetResolution(720, 1280, true);
        touchController = GetComponent<TouchController>();
        questionManager = GetComponent<QuestionManager>();
        BindEvents();
    }

    void OnDestroy()
    {
        UnBindEvents();
    }

    void BindEvents()
    {
        touchController.Touched += questionManager.ChangePanel;
    }

    void UnBindEvents()
    {
        touchController.Touched -= questionManager.ChangePanel;
    }
}
