﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemStatus : MonoBehaviour {
    private Color baseColor;
    private Color endColor;
    private Color resultColor;

    public Material mat;

    public Quaternion color1;
    public Quaternion color2;
    public Quaternion colorEnd;

    public float lerpTime;
    public int auxLerp;
    
	// Use this for initialization
	void Start () {
        baseColor = Color.white;
        endColor = Color.blue;
	}
	
	// Update is called once per frame
	void Update () {
        lerpTime += Time.deltaTime * 1.5f;

        if (auxLerp == 0)
        {
            mat.color = ColorLerp(baseColor, endColor, lerpTime);
            StartCoroutine(timerColorChange(1));
        }
        else
        {
            mat.color = ColorLerp(endColor, baseColor, lerpTime);
            StartCoroutine(timerColorChange(0));
        }


    }

    // (0f , 0f, 0f, 0f)
    private Color ColorLerp(Color start, Color end, float speed)
    {
        color1 = new Quaternion(start.r, start.g, start.b, start.a);
        color2 = new Quaternion(end.r, end.g, end.b, end.a);

        colorEnd = Quaternion.Slerp(color1, color2, speed);

        return new Color(colorEnd.x, colorEnd.y, colorEnd.z, colorEnd.w);
    }

    IEnumerator timerColorChange(int a)
    {
        yield return new WaitUntil(() => lerpTime >= 1);
        lerpTime = 0;
        auxLerp = a;
    }
}
