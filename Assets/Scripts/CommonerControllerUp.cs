﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonerControllerUp : MonoBehaviour {

    public float moveSpeed;
    public int moveDirection;
    public float moveTimer;
    public float moveDuration;
    public bool moves;
    private Animator anim;

    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        moveSpeed = 2;
        moveDirection = 0;
        moveTimer = Random.Range(1, 6);
        moveDuration = 0.5f;
        moves = false;
    }

    // Update is called once per frame
    void Update() {

        moveTimer = moveTimer - Time.deltaTime;
        //Debug.Log("timer" + timer);
        if (moveTimer <= 0){
            if (moveDirection == 1) {
                moveDirection = -1;
            }
            else{
                moveDirection = 1;
            }

            //Debug.Log("moveDirection" + moveDirection);
            moveTimer = Random.Range(1,6);
            //Debug.Log("moveTimer" + moveTimer);
            moveDuration = 0.5f;
        }

        if (moveDirection > 0.5f || moveDirection < -0.5f){
            moveDuration = moveDuration - Time.deltaTime;
            if(moveDuration > 0){
                moves = true;
                //Debug.Log("moves1" + moves);
                transform.Translate(new Vector3(0f, moveDirection * moveSpeed * Time.deltaTime, 0f));
            }
            else{
                moves = false;
                //Debug.Log("moves2" + moves);
            }
        }

        anim.SetBool("moves", moves);

    }
}
