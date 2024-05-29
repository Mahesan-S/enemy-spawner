using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour{

    GameObject MenuCanvas;
    [SerializeField] GameObject PausePanel;
    [SerializeField] GameObject OptionCanva;
    [SerializeField] GameObject GameOverPanel;

    [SerializeField] Slider Sliders;

    Slider HealthBarSlider;
    Animator CameraAnimation;
    


    bool GameIsPause;
    void Start(){
        MenuCanvas = GameObject.Find("MenuCanvas");
        CameraAnimation = GameObject.Find("Main Camera").GetComponent<Animator>();
        HealthBarSlider = GameObject.Find("healthBar").GetComponent<Slider>();
        
        GameStartMenu();
        
        GameIsPause = false;

        if(PlayerPrefs.HasKey("Mouse Speed")) {
            Sliders.value = PlayerPrefs.GetFloat("Mouse Speed");
        }
        else {
            PlayerPrefs.SetFloat("Mouse Speed", Sliders.value);
        }

        //print(GameOverPanel.activeSelf);
    }


    void FixedUpdate()
    {
        //FindPause();
        if (Input.GetKeyDown(KeyCode.Escape)){
            pause();
        }
    }

    public void FindPause() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (GameIsPause) {
                resume();
            }
            else {
                pause();
            }
        }
    }

    public void GameStartMenu() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PausePanel.SetActive(false);
        Time.timeScale = 0f;
    }
    public void StartBtn() { 

        Cursor.lockState = CursorLockMode.Locked; 
        Cursor.visible = false;
        Time.timeScale = 1f;

        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().ScoreUpdate(0f);
        CameraAnimation.enabled = true;
        MenuCanvas.SetActive(false);
        Destroy(MenuCanvas);   
        
    }

    public void resume() {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        GameIsPause = false;
    }
    public void pause() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        GameIsPause = true;
    }

    public void Options() {
       // Cursor.lockState = CursorLockMode.Confined;
        //Cursor.visible = true;
        MenuCanvas.SetActive(false);
        OptionCanva.SetActive(true);
        
    }
    public void BackBtn() {
        OptionCanva.SetActive(false);
        MenuCanvas.SetActive(true);
    }

    public void SetSpeed(){
        GameObject.FindWithTag("Player").GetComponent<PlayerMovement>().SetLookSpeed(Sliders.value);
        PlayerPrefs.SetFloat("Mouse Speed", Sliders.value);
    }

    public void HealthReduceAndIncreace(float HealthValue = 1f) {
        HealthBarSlider.value += HealthValue;
        
        if (HealthBarSlider.value <= 5) {
            GameObject.Find("Fill").GetComponent<Image>().color = Color.red;
        }
        else if(HealthBarSlider.value <= 10) {
            GameObject.Find("Fill").GetComponent<Image>().color = new Color(225f / 225f, 225f / 225f, 0f);
        }
        else{
            GameObject.Find("Fill").GetComponent<Image>().color = new Color(0f, 225f, 0f);
        }
    }

    public void ActiveGameOverPanel() {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        GameOverPanel.SetActive(true);
    }

    public void RestartLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitBtn() {
        Application.Quit();
    }
}

