using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "Helper", menuName = "ScriptableObjects/Helper")]
public class HelpSO : ScriptableObject
{
    public void PlaySound(AudioClip clip)
    {
        AudioManager.inst.Play(clip);
    }
    public void StartMusic(AudioClip clip)
    {
        AudioManager.inst.PlayMusic(clip);
    }
    public void RemoveMusic(bool a)
    {
        if(a)
        {
            AudioManager.inst.SetMusicVolume(0);
        }
        else
        {
            AudioManager.inst.SetMusicVolume(1f);
        }
    }
    public void printStuff(string v)
    {
        Debug.Log(v);
    }
    public void LoadScene(string n)
    {
        SceneLoader.inst.LoadScene(n);
    }
    public void ExitGame()
    {
        SceneLoader.inst.ExitGame();
    }
}
