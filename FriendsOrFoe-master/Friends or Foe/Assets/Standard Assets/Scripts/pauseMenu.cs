using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {
    public GUISkin skin;
    public Texture[] creditIcons;
    public string[] credits = new string[] { "A product of Team YUME" };
    public string loadMainMenu;
    public Color buttonOutlineAndTextColor = Color.white;

    private float savedTimeScale;
    private bool pauseFilter;
    private int toolBarInt = 0;
    private string[] toolBarStrings = new string[] { "Audio", "Graphics" };
    private bool firstPersonControllerCamera;
    private bool mainCamera;
    private bool toggledPause = false;
    private page currentPage;

    Rect rect;

    public enum page
    {
        None, Main, Options, Credits
    }

    private void LateUpdate()
    {
        if (Input.GetKeyDown("escape") || Input.GetKey(KeyCode.P))
        {
            if (currentPage.Equals(page.None))
            {
                PauseGame();
            }

              else if(currentPage.Equals(page.Main)) { 
                    UnPauseGame();
            }

            else {
                    currentPage = page.Main;
            }
        }
    }

    void PauseGame()
    {
        savedTimeScale = Time.timeScale;
        Time.timeScale = 0;
        AudioListener.pause = true;
        firstPersonControllerCamera = GameObject.Find("First Person Controller").GetComponent("MouseLook");
        mainCamera = GameObject.Find("Main Camera").GetComponent("MouseLook");
        firstPersonControllerCamera = false;
        mainCamera = false;

        if (pauseFilter)
        {
            pauseFilter = true;
        }

        currentPage = page.Main;
    }


    private void OnGUI()
    {
        if (skin != null)
        {
            GUI.skin = skin;
        }

        if (isGamePaused())
        {
            GUI.color = buttonOutlineAndTextColor;

            switch (currentPage)
            {
                case page.Main: PauseMenu();
                    break;

                case page.Options: showToolBar();
                    break;

                case page.Credits: showCredits();
                    break;
            }
        }
    }

    bool isGamePaused()
    {
        return Time.timeScale == 0;
    }

    void PauseMenu()
    {
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");

        BeginPage(400, 200);

        if (GUILayout.Button("Continue"))
        {
            UnPauseGame();
        }

        if (GUILayout.Button("Settings"))
        {
            currentPage = page.Options;
        }

        if (GUILayout.Button("Credits"))
        {
            currentPage = page.Credits;
        }

        if (GUILayout.Button("Quit to Main Menu"))
        {
            Application.LoadLevel(2);
        }

        EndPage();
    }

    void BeginPage(int width, int height)
    {
        GUILayout.BeginArea(rect = new Rect((Screen.width - width) / 2, (Screen.height - height) / 2, width, height));
    }

    void EndPage()
    {
        GUILayout.EndArea();
    }

    void VolumeControl()
    {
        GUILayout.Label("Use the slider to adjust the volume. Note that the volume is defaulted at 100%.");
        AudioListener.volume = GUILayout.HorizontalSlider(AudioListener.volume, 0.0f, 1.0f);
    }

    void QualityControl()
    {
        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Decrease"))
        {
            QualitySettings.DecreaseLevel();
        }

        if (GUILayout.Button("Increase"))
        {
            QualitySettings.IncreaseLevel();
        }

        GUILayout.EndHorizontal();
    }

    void Qualities()
    {
        switch (QualitySettings.currentLevel)
        {
            case QualityLevel.Fastest:
                GUILayout.Label("Fastest");
                break;

            case QualityLevel.Fast:
                GUILayout.Label("Fast");
                break;

            case QualityLevel.Simple:
                GUILayout.Label("Simple");
                break;

            case QualityLevel.Good:
                GUILayout.Label("Good");
                break;

            case QualityLevel.Beautiful:
                GUILayout.Label("Beautiful");
                break;

            case QualityLevel.Fantastic:
                GUILayout.Label("Fantastic");
                break;
        }
    }

    void ShowToolbar()
    {
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");

        BeginPage(400, 200);

        toolBarInt = GUILayout.Toolbar(toolBarInt, toolBarStrings);

        switch (toolBarInt)
        {
            case 0:
                VolumeControl();
                break;

            case 1:
                Qualities();
                QualityControl();
                break;
        }

        if (GUILayout.Button("Back"))
        {
            currentPage = page.Main;
        }

        EndPage();
    }

    void showCredits()
    {
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");

        BeginPage(400, 200);
	
	foreach (string credit in credits)
        {
            GUILayout.Label(credit);
        }
	
    foreach (Texture credit in creditIcons)
        {
            GUILayout.Label(credit);
        }

        if (GUILayout.Button("Back"))
        {
            currentPage = page.Main;
        }

        EndPage();
    }

    void UnPauseGame()
    {
        Time.timeScale = savedTimeScale;
        AudioListener.pause = false;
        firstPersonControllerCamera = true;
        mainCamera = true;

        if (pauseFilter)
        {
            pauseFilter = false;
        }

        currentPage = page.None;
    }

    void showToolBar()
    {
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");

        BeginPage(400, 200);

        toolBarInt = GUILayout.Toolbar(toolBarInt, toolBarStrings);

        switch (toolBarInt)
        {
            case 0:
                VolumeControl();
                break;

            case 1:
                Qualities();
                QualityControl();
                break;
        }

        if (GUILayout.Button("Back"))
        {
            currentPage = page.Main;
        }

        EndPage();
    }

    void sShowCredits()
    {
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");
        GUI.Box(rect = new Rect(0, 0, Screen.width, Screen.height), "");

        BeginPage(400, 200);
	
	foreach (string credit in credits)
        {
            GUILayout.Label(credit);
        }
	
    foreach (Texture credit in creditIcons)
        {
            GUILayout.Label(credit);
        }

        if (GUILayout.Button("Back"))
        {
            currentPage = page.Main;
        }

        EndPage();
    }
}
