using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MainMenuUi : MonoBehaviour
{
    [SerializeField] private TMP_InputField NameInput;
    public void OnStartClick() {
        DataManager.Instance.PlayerName = NameInput.text;
        SceneManager.LoadScene(1);
    }
    public void OnExitClick()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}
