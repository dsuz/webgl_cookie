using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] InputField m_scoreField;
    [SerializeField] Text m_console;

    CookieLib m_cookie;

    private void Start()
    {
        m_cookie = new CookieLib();
    }

    public void SetScore()
    {
        string scoreString = m_scoreField.text;
        int score;
        if (int.TryParse(scoreString, out score))
        {
            m_cookie.SetScore(score);
        }
        else
        {
            Debug.LogError("不正な入力です。数値を入力してください。");
        }
    }

    public void GetScore()
    {
        int score = m_cookie.GetScore();
        string messageText = "Score: " + score;

        if (m_console)
        {
            m_console.text = messageText + "\r\n" + m_console.text;
        }
    }

    public void ClearConsole()
    {
        if (m_console)
        {
            m_console.text = "";
        }
    }
}
