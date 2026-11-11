using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class ButtonHandler : MonoBehaviour
{

    [SerializeField] private ScenePathSo gameplayScene;
     [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private Slider volumeSlider;
    [SerializeField] private Toggle soundToggle;
    [SerializeField] private TMP_Text text;



    private void Start()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        volumeSlider.onValueChanged.AddListener(OnVolumeChange);
    }



    public void OnVolumeChange(float value)
    {
        text.text = $"Volume:{value}";
    }
    public void Play()
    {

        SceneManager.LoadScene(gameplayScene.Path);
    }

  public void Settings()
    {



    }


 public void Quit()
    { 
#if UNITY_EDITOR
      // EditorApplication.


#endif
        Application.Quit();
    }



}
