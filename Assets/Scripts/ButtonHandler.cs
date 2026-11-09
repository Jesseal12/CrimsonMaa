using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonHandler : MonoBehaviour
{

    [SerializeField] private ScenePathSo gameplayScene;
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
