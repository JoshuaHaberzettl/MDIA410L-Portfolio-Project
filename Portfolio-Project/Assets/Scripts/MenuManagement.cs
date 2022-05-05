using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    //MenuNavigation
    public enum MenuStates { Main, Settings,Playing }
    public static MenuStates currentstate;

    public GameObject mainMenu;
    public GameObject Settings;
   

    //Settings for Volume
    [SerializeField] Slider volumeSlider;

    //Settings for Resolution
    List<int> widths = new List<int>() { 1280, 1920, 2560 };
    List<int> heights = new List<int>() { 720, 1080, 1440 };
    public Toggle MyToggle;
    public Dropdown MyDropdown;

    //Settings for Sensitivity
    public InputField SensitivityInput;
    public static float SensitiviyValue;


    // Start is called before the first frame update
    void Start()
    {
        
        if(PlayerPrefs.HasKey("fullscreen")|| PlayerPrefs.HasKey("fullscreenToggle")|| PlayerPrefs.HasKey("DropdownValue")|| PlayerPrefs.HasKey("musicVolume")|| PlayerPrefs.HasKey("PlayersSensitivity"))
        {
            Load();
        }
        else
        {
            volumeSlider.value = .5f;
            Screen.fullScreen = false;
            MyDropdown.value = 0;
            SensitiviyValue = 50f;

        }
    }
    public void Awake()
    {
        if (SceneManager.GetActiveScene().name == "Menus")
        {
            currentstate = MenuStates.Main;
        }

        if (SceneManager.GetActiveScene().name == "Test-Character")
        {
            currentstate = MenuStates.Playing;
        }


    }

    // Update is called once per frame
    void Update()
    {
        switch (currentstate)
        {

            case MenuStates.Main:
                mainMenu.SetActive(true);
                Settings.SetActive(false);
                break;

            case MenuStates.Playing:
                mainMenu.SetActive(false);
                Settings.SetActive(false);
                break;

            case MenuStates.Settings:
                mainMenu.SetActive(false);
                Settings.SetActive(true);
                break;
        }
    }

    public void GoSettings()
    {
        currentstate = MenuStates.Settings;
    }

    public void GoMain()
    {
        currentstate = MenuStates.Main;
    }

    public void GoPlay()
    {
        currentstate = MenuStates.Playing;
    }

    public void GoLevel()
    {
        SceneManager.LoadScene("Test-Character");
    }

    public void GoMenus()
    {
        
        SceneManager.LoadScene("Menus");
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = volumeSlider.value;
        
    }

    public void SetScreenSize(int index)
    {
        bool fullscreen = Screen.fullScreen;
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, fullscreen);
        MyDropdown.value = index;

    }
    public void SetFullScreen(bool _fullscreen)
    {
        Screen.fullScreen = _fullscreen;

        if (_fullscreen)
        {
            MyToggle.isOn = true;
        }
        else
        {
            MyToggle.isOn = false;
        }

    }
    public void Load()
    {
     
        bool fullscreen = intToBool(PlayerPrefs.GetInt("fullscreen"));
        SetFullScreen(fullscreen);
        MyToggle.isOn = intToBool(PlayerPrefs.GetInt("fullscreenToggle"));
        int index = PlayerPrefs.GetInt("DropdownValue");
        SetScreenSize(index);
        volumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SensitivityInput.text = PlayerPrefs.GetFloat("PlayersSensitivity").ToString();
        SensitiviyValue = PlayerPrefs.GetFloat("PlayersSensitivity");
        
    }

    public void Save()
    {
        PlayerPrefs.SetInt("fullscreen", boolToInt(Screen.fullScreen));
        PlayerPrefs.SetInt("fullscreenToggle", boolToInt(MyToggle.isOn));
        PlayerPrefs.SetInt("DropdownValue", MyDropdown.value);
        PlayerPrefs.SetFloat("musicVolume", volumeSlider.value);
        PlayerPrefs.SetFloat("PlayersSensitivity", SensitiviyValue);
    }

    int boolToInt(bool val)
    {
        if (val)
            return 1;
        else
            return 0;
    }

    bool intToBool(int val)
    {
        if (val != 0)
            return true;
        else
            return false;
    }

    public void GetNewSensitivity(string NewSense)
    {
        SensitiviyValue=float.Parse(NewSense, CultureInfo.InvariantCulture.NumberFormat);
        Debug.Log(SensitiviyValue);
    }
}
