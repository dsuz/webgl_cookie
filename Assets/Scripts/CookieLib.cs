using System.Runtime.InteropServices;
using UnityEngine;

public class CookieLib
{
    [DllImport("__Internal", EntryPoint = "setHiScore")]
    private static extern void SetHiScore(int score);

    [DllImport("__Internal", EntryPoint = "getHiScore")]
    private static extern int GetHiScore();

    static string ERROR_MSG_ONLY_ON_WEBGL = "WebGL にビルドしたものを実行した時のみ、この機能は有効です。Unity Editor 等からはこの機能は使えません。";

    public void SetScore(int score)
    {
        if (IsWebGL())
        {
            SetHiScore(score);
        }
        else
        {
            Debug.LogError(ERROR_MSG_ONLY_ON_WEBGL);
        }
    }

    public int GetScore()
    {
        int score = 0;

        if (IsWebGL())
        {
            score = GetHiScore();
        }
        else
        {
            Debug.LogError(ERROR_MSG_ONLY_ON_WEBGL);
        }

        return score;
    }

    bool IsWebGL()
    {
        return Application.platform == RuntimePlatform.WebGLPlayer;
    }
}