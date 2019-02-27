﻿using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUse : MonoBehaviour {

    public GameObject fireballPrefab;
    private FireBall fireball;
    private Stopwatch cooldownTimer;
    public float forceMultiplier;
    private Button button;
    private Image fillImage;

    public void OnAbilityUse(GameObject btn)
    {
        fillImage = btn.transform.GetChild(0).gameObject.GetComponent<Image>();
        UnityEngine.Debug.Log(btn.transform.GetChild(0).gameObject.name);
        button = btn.GetComponent<Button>();
        button.interactable = false;
        fillImage.fillAmount = 1;
        cooldownTimer = new Stopwatch();
        cooldownTimer.Start();

        GameObject go = Instantiate<GameObject>(fireballPrefab);
        go.transform.position = this.transform.position;
        fireball = new FireBall();
        fireball.AbilityPrefab = go;
        //fireball.Activate;

        

        StartCoroutine(SpinImage());
    }

    private IEnumerator SpinImage()
    {
        UnityEngine.Debug.Log(fireball.Cooldown);
        while (cooldownTimer.IsRunning && cooldownTimer.Elapsed.TotalSeconds < fireball.Cooldown)
        {
            UnityEngine.Debug.Log(fillImage.fillAmount);
            fillImage.fillAmount = ((float)cooldownTimer.Elapsed.TotalSeconds / fireball.Cooldown);
            yield return null;
        }
        fillImage.fillAmount = 0;
        button.interactable = true;
        cooldownTimer.Stop();
        cooldownTimer.Reset();

        yield return null;
    }
}
