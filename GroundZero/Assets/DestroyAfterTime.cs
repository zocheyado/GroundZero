﻿using UnityEngine;
using System.Collections;

public class DestroyAfterTime : MonoBehaviour {
    public float lifetime = 2.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, lifetime);
    }
}
