using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class EndGame : MonoBehaviour
{
    public Button QuitGameButton;
    public Button RestartButton;
    // Start is called before the first frame update
    void Start()
    {
        Button quitBtn = QuitGameButton.GetComponent<Button>();
        Button restartBtn = RestartButton.GetComponent<Button>();
        quitBtn.onClick.AddListener(quitBtnOnClick);
        restartBtn.onClick.AddListener(restartBtnOnClick);
        Cursor.visible = true;

    }

    void quitBtnOnClick()
    {
        Application.Quit();
    }


    void restartBtnOnClick()
    {
        SceneManager.LoadScene("FlightTest");
    }
}
