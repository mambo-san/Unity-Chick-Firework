using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] GameObject mainUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] Slider spawnSlider;
    [SerializeField] TextMeshProUGUI spawnValueText;
    [SerializeField] Slider explosiveSlider;
    [SerializeField] TextMeshProUGUI explosiveValueText;
    [SerializeField] TMP_Dropdown chickTypeDropDown;



    // Start is called before the first frame update
    void Start()
    {


        spawnValueText.text = spawnSlider.value.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnSpawnSliderChange(float value)
    {
        spawnValueText.text = value.ToString();
        GameManager.Instance.spawnCount = (int) value;
    }

    public void OnExplosionSliderChange(float value)
    {
        explosiveValueText.text = value.ToString();
        GameManager.Instance.explosiveness = value;
    }

    public void OnChickTypeChange(int value)
    {
        if (Time.frameCount > 10)
        {
            GameManager.Instance.updateStartChickType(value);
        }
        
    }

    public void StartGame()
    {
        mainUI.SetActive(false);
        gameUI.SetActive(true);
        GameManager.Instance.IsGameActive = true;
    }

    public void onMoreChickButtonClicked()
    {
        GameManager.Instance.SpawnFirstChick();
    }

    public void onResetButtonClicked()
    {
        
        gameUI.SetActive(false);
        mainUI.SetActive(true);
        GameManager.Instance.ResetGame();
    }
    
}
