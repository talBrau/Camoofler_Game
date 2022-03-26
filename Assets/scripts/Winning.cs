using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Winning : MonoBehaviour
{
    private RectTransform rTransform;
    [SerializeField] private Image rImage;
    private Animator animator;
    public float reloadTime = 0.7f;
    
    private void Awake()
    {
        rTransform = GetComponent<RectTransform>();
        rImage = GetComponent<Image>();
        animator = GetComponent<Animator>();
    }

    /// param whoWon : true = red player. false = blue player
    public void WinningMethode(string whoWon, Color winColor)
    {
        // color of wave
        rImage.color = winColor;
        // direction of wave
        if (whoWon == "blue")
        { rTransform.eulerAngles = new Vector3(0, 0, 0); }
        // play animation
        animator.SetTrigger("winning");
        // reload game
        Invoke("Load", reloadTime);
    }

    private void Load()
    {
        SceneManager.LoadScene(0);
    }
}
