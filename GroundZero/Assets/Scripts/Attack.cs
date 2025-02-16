﻿using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

    public float damage = 10;
    public bool attacking = false;
	// Use this for initialization
    private Stats statScript;
	void Start () {
	    statScript = GameObject.FindWithTag("GameController").gameObject.GetComponent<Stats>();
    }
    void OnCollisionEnter(Collision collision)
    {
        //get the direction of impact, then get the position of the target, then make the decal spawn at the location of target + 2x offset. (so it looks like blood is coming out the back of them based on where you hit them)
        if (collision.gameObject.tag == "Enemy") {
            if (attacking == true) {
                statScript.onHit();
                Vector3 Impact = collision.transform.InverseTransformPoint(transform.position);
                Vector3 floorDecal = collision.transform.position - Impact;
                floorDecal.y = 0.01f;
                Instantiate(Resources.Load("BloodSplatter"), floorDecal, Quaternion.Euler(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                collision.gameObject.GetComponent<EnemyStats>().hitlocation = collision.contacts[0].normal;
                collision.gameObject.GetComponent<EnemyStats>().Hit(damage);
            }
        }

    }
    // Update is called once per frame
    void Update () {
	
	}
}
