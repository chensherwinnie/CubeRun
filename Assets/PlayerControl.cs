using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour{

    private Rigidbody player;

    /*
      private setting for the Forces
    */
    private float MaximumSpeed = 30f;
    private float MaximumSideSpeed = 15f;
    private float ForwardForce = 70f;
    private float SideForce = 50f;
    private float JumpForce = 8f;

    private bool isOnGround = false;
    public char direction = 'g';

    private float SideSpeed;
    private float ForwardSpeed;
    private float JumpSpeed;
    private Vector3 CurrentSpeed;

    private bool Jump;
    private bool MoveLeft;
    private bool MoveRight;
    private bool MoveForward;
    private bool MoveBack;

    void Start(){
      player = GetComponent<Rigidbody>();
      Physics.gravity = new Vector3(0, -15f, 0);
    }

    // Update is called once per frame
    void Update(){
      Jump = Input.GetKeyDown(KeyCode.Space) && isOnGround;
      MoveLeft = Input.GetKey(KeyCode.A);
      MoveRight = Input.GetKey(KeyCode.D);
      MoveForward = Input.GetKey(KeyCode.W);
      MoveBack = Input.GetKey(KeyCode.S);

      SideSpeed = SideForce*Time.deltaTime;
      ForwardSpeed = ForwardForce*Time.deltaTime;
      JumpSpeed = JumpForce;
      CurrentSpeed = player.velocity;
    }

    void FixedUpdate(){
      PlayerMove();
    }

    bool CheckSpeedLimit(float speed, float limit){
      if(speed < 0)
        return speed > -1 * limit;
      else
        return speed < limit;
    }

    void PlayerMove(){
        if(Jump){
          PlayerMoveJump();
          Debug.Log("Space");
        }

        if(MoveLeft){
          PlayerMoveLeftSide();
        }
        if(MoveRight){
          PlayerMoveRightSide();
          Debug.Log("D");
        }
        if(MoveForward && CheckSpeedLimit(CurrentSpeed.z, MaximumSpeed)){
          player.AddForce(0, 0, ForwardSpeed, ForceMode.VelocityChange);
          Debug.Log("W");
        }
        if(MoveBack && CheckSpeedLimit(CurrentSpeed.z, MaximumSpeed)){
          player.AddForce(0, 0, -1 * ForwardSpeed, ForceMode.VelocityChange);
          Debug.Log("S");
        }
    }

    void PlayerMoveJump(){
      switch (direction) {
        case 'g':
          player.AddForce(0, JumpSpeed, 0, ForceMode.VelocityChange);
          break;
        case 'r':
          player.AddForce(-1 * JumpSpeed, 0, 0, ForceMode.VelocityChange);
          break;
        case 'l':
          player.AddForce(JumpSpeed, 0, 0, ForceMode.VelocityChange);
          break;
        case 'c':
          player.AddForce(0, -1 * JumpSpeed, 0, ForceMode.VelocityChange);
          break;
        }
    }

    void PlayerMoveRightSide(){
      switch (direction) {
        case 'g':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed))
          {
            player.AddForce(SideSpeed, 0, 0, ForceMode.VelocityChange);
            Debug.Log("D");
          }
          break;
        case 'c':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed)){
            player.AddForce(-1 * SideSpeed, 0, 0, ForceMode.VelocityChange);
            Debug.Log("D");
          }
          break;
        case 'r':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, SideSpeed, 0, ForceMode.VelocityChange);
            Debug.Log("D");
          }
          break;
        case 'l':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, -1 * SideSpeed, 0, ForceMode.VelocityChange);
            Debug.Log("D");
          }
          break;
        }
    }

    void PlayerMoveLeftSide(){
      switch (direction) {
        case 'g':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed))
          {
            player.AddForce(-1 * SideSpeed, 0, 0, ForceMode.VelocityChange);
            Debug.Log("A");
          }
          break;
        case 'c':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed))
          {
            player.AddForce(SideSpeed, 0, 0, ForceMode.VelocityChange);
            Debug.Log("A");
          }
          break;
        case 'r':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, -1 * SideSpeed, 0, ForceMode.VelocityChange);
            Debug.Log("A");
          }
          break;
        case 'l':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, SideSpeed, 0, ForceMode.VelocityChange);
            Debug.Log("A");
          }
          break;
      }
    }

    void OnCollisionEnter(Collision collision){
      if(collision.collider.tag == "g"){
        Physics.gravity = new Vector3(0, -15f, 0);
        direction = 'g';
        isOnGround = true;
      }
      else if(collision.collider.tag == "r"){
        Physics.gravity = new Vector3(15f, 0, 0);
        direction = 'r';
        isOnGround = true;
      }
      else if(collision.collider.tag == "l"){
        Physics.gravity = new Vector3(-15f, 0, 0);
        direction = 'l';
        isOnGround = true;
      }
      else if(collision.collider.tag == "c"){
        Physics.gravity = new Vector3(0, 15f, 0);
        direction = 'c';
        isOnGround = true;
      }
    }

    void OnCollisionExit(Collision collision){
      if(collision.collider.tag == "l" || collision.collider.tag == "g" || collision.collider.tag == "c" || collision.collider.tag == "r"){
        isOnGround = false;
      }
    }
}
