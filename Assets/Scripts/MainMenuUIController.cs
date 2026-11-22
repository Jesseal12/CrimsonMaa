using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MainMenuUIController : MonoBehaviour
{
    [SerializeField] private ScenePathSo _gameplaySceneSo;
    [SerializeField] private PanelRenderer _panelRenderer;


    private VisualElement _mainMenu, settingsMenu;
    private Button _play, _settings, _quit, _back;
    private Slider _volumeSlider;
    private Toggle _soundToggle;
    private Label _volumeValue;


    private void OnEnable()
    {
        _panelRenderer.RegisterUIReloadCallback(OnUIReload);
    }

    private void OnDisable()
    {
        if(_panelRenderer!=null) _panelRenderer.UnregisterUIReloadCallback(OnUIReload);
    }

    private void OnUIReload(PanelRenderer renderer, VisualElement root, int version)
    {
        UnSubscribe();

        _mainMenu = root.Q<VisualElement>("MenuContent");
        settingsMenu = root.Q<VisualElement>("SettingsContent");
        _play = root.Q<Button>("PlayButton");
        _settings = root.Q<Button>("SettingsButton");
        _quit = root.Q<Button>("quit");
        _back = root.Q<Button>("back");
        _volumeSlider = root.Q<Slider>("VolumeSlider");
        _soundToggle = root.Q<Toggle>("SoundToggle");
        _volumeValue = root.Q<Label>("Value");

        _play.clicked += Play;
        _settings.clicked += Settings;
        _quit.clicked += Quit;
        _back.clicked += Back;
        _mainMenu.style.display = DisplayStyle.Flex;
        settingsMenu.style.display = DisplayStyle.None;
    }



    private void UnSubscribe()
    {
        if(_play!=null) _play.clicked -= Play;
        if (_settings!=null) _settings.clicked -= Settings;
        if(_quit!=null) _quit.clicked -= Quit;
        if(_back!=null) _back.clicked -= Back;
        if (_volumeSlider != null)  _volumeSlider.UnregisterValueChangedCallback(OnVolumeChanged);
        if (_soundToggle != null) _soundToggle.UnregisterValueChangedCallback(OnSoundChanged);

    }
    private void OnVolumeChanged(ChangeEvent<float>evt)
    {

    }
    private void OnSoundChanged(ChangeEvent<bool> evt)
    {

    }
   


    private void Play()
    {
        //SceneManager.LoadScene(_gameplaySceneSo);
    }

    private void Quit() => Application.Quit();


    private void Settings()
    {

        _mainMenu.style.display = DisplayStyle.None;
        settingsMenu.style.display = DisplayStyle.Flex;


    }

    private void Back()
    {

    }

    public static class AppCOnstants
    {

        public static class Class1
        {

            public const string MenuContent = "MenuContent";
        }

        public static class CLass2
        {

        }
    }
  


}
