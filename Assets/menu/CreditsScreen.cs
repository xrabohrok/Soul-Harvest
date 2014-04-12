using UnityEngine;
using System.Collections.Generic;


public class CreditsScreen : MonoBehaviour 
{
    bool FirstLaunch = true;
    bool pushedGoBack;

    public Texture2D fadeTexture;
    public Texture2D Credits;
    public float buttonWidthPercent = .20f;
    public float buttonHeightPercent = .05f;
    public float fadeSpeed = .4f;
    public float CreditsHeight = .03f;
    public float CreditsScale = 1f;

    private Rect TitlePos;
    private float alpha = 1f;

    public void OnGUI()
    {
        //Credtis
        TitlePos.width = Credits.width * CreditsScale;
        TitlePos.height = Credits.height * CreditsScale;
        TitlePos.x = Screen.width / 2 - TitlePos.width / 2;
        TitlePos.y = CreditsHeight;
        GUI.DrawTexture(TitlePos, Credits);

        float buttonWidth = Screen.width * buttonWidthPercent;
        float buttonHeight = Screen.height * buttonHeightPercent;

        if (FirstLaunch)
        {
            alpha = MenuFade.FadeIn(fadeSpeed, fadeTexture, alpha);
            if (alpha <= 0)
            {
                FirstLaunch = false;
            }
        }

        if(!FirstLaunch)
        if (GUI.Button(new Rect(Screen.width / 2 - buttonWidth/2, buttonHeight * 3, buttonWidth , buttonHeight), "Go Back"))
        {
            pushedGoBack = true;
        }

        if (pushedGoBack)
        {
            alpha = MenuFade.FadeOut(fadeSpeed, fadeTexture, alpha);
            if(alpha >= 1)
            {
                Application.LoadLevel(0);
            }
        }
    }
}

