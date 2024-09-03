using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SceneOrganizer : MonoBehaviour {
    [Header("Holders")]
    [SerializeField] private Transform managerHolder;
    [SerializeField] private Transform uiHolder;
    [Header("AudioManager")]
    [SerializeField] private GameObject audioManagerPrefab;

    [Header("SceneTransition")]
    [SerializeField] private GameObject transitionPrefab;
    [SerializeField] private AudioClip startMusic;

    private void Start() {
        SetupSceneTransition();
        Instantiate(audioManagerPrefab);
        if(startMusic != null) AudioManager.inst.PlayMusic(startMusic);
    }


    private void SetupSceneTransition()
    {
        Canvas c = Instantiate(transitionPrefab, uiHolder).GetComponent<Canvas>();
        c.worldCamera = Camera.main;       
    }

    private Canvas CreateCanvas(string name, GameObject canvasPrefab) {
        Canvas canvas = Instantiate(canvasPrefab, uiHolder).GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        canvas.gameObject.name = name;
        return canvas;
    }

    private GameObject InstantiateManager(string name, Type componentType, bool doParent = true) {
        GameObject newObject = new GameObject(name);
        if (doParent) newObject.transform.parent = managerHolder;
        newObject.AddComponent(componentType);
        return newObject;
    }
}
