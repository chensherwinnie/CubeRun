using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerControl : MonoBehaviour{

    private Rigidbody player;

    /*
      private setting for the Forces
    */
    private float MaximumSpeed = 80f;
    private float MaximumSideSpeed = 50f;
    private float ForwardForce = 100f;
    private float SideForce = 70f;
    private float JumpForce = 40f;

    /*
     * Gravity Setting
     */
    private bool isOnGround = false;
    public char direction = 'g';
    private float GravityMultiplier = 2.5f;
    private float GravityConstant = 10;

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
    }

    void FixedUpdate(){
      SideSpeed = SideForce*Time.deltaTime;
      ForwardSpeed = ForwardForce*Time.deltaTime;
      JumpSpeed = JumpForce;
      CurrentSpeed = player.velocity;
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
          Jump = false;
        }

        if (MoveLeft){
          PlayerMoveLeftSide();
        }
        if(MoveRight){
          PlayerMoveRightSide();
        }
        if(MoveForward && CheckSpeedLimit(CurrentSpeed.z, MaximumSpeed)){
          player.AddForce(0, 0, ForwardSpeed, ForceMode.VelocityChange);
        }
        if(MoveBack && CheckSpeedLimit(CurrentSpeed.z, MaximumSpeed)){
          player.AddForce(0, 0, -1 * ForwardSpeed, ForceMode.VelocityChange);
        }
    }

    void PlayerMoveJump(){
      player.velocity = new Vector3(player.velocity.x, player.velocity.y, 0f);
      switch (direction) {
        case 'g':
          player.AddForce(0, JumpSpeed, 0, ForceMode.Impulse);
          break;
        case 'r':
          player.AddForce(-1 * JumpSpeed, 0, 0, ForceMode.Impulse);
          break;
        case 'l':
          player.AddForce(JumpSpeed, 0, 0, ForceMode.Impulse);
          break;
        case 'c':
          player.AddForce(0, -1 * JumpSpeed, 0, ForceMode.Impulse);
          break;
        }
    }

    void PlayerMoveRightSide(){
      switch (direction) {
        case 'g':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed))
          {
            player.AddForce(SideSpeed, 0, 0, ForceMode.VelocityChange);
          }
          break;
        case 'c':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed)){
            player.AddForce(-1 * SideSpeed, 0, 0, ForceMode.VelocityChange);
          }
          break;
        case 'r':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, SideSpeed, 0, ForceMode.VelocityChange);
          }
          break;
        case 'l':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, -1 * SideSpeed, 0, ForceMode.VelocityChange);
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
          }
          break;
        case 'c':
          if(CheckSpeedLimit(CurrentSpeed.x, MaximumSideSpeed))
          {
            player.AddForce(SideSpeed, 0, 0, ForceMode.VelocityChange);
          }
          break;
        case 'r':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, -1 * SideSpeed, 0, ForceMode.VelocityChange);
          }
          break;
        case 'l':
          if(CheckSpeedLimit(CurrentSpeed.y, MaximumSideSpeed)){
            player.AddForce(0, SideSpeed, 0, ForceMode.VelocityChange);
          }
          break;
      }
    }

    void OnCollisionEnter(Collision collision){
        float GravityForce = GravityConstant * GravityMultiplier;

      if(collision.collider.tag == "g" || collision.collider.tag == "r" || collision.collider.tag == "l" || collision.collider.tag == "c"){
        isOnGround = true;
        direction = collision.collider.tag[0];
      }

      if(collision.collider.tag == "g"){
        Physics.gravity = new Vector3(0, -1*GravityForce, 0);
      }
      else if(collision.collider.tag == "r"){
        Physics.gravity = new Vector3(GravityForce, 0, 0);
      }
      else if(collision.collider.tag == "l"){
        Physics.gravity = new Vector3(-1*GravityForce, 0, 0);
      }
      else if(collision.collider.tag == "c"){
        Physics.gravity = new Vector3(0, GravityForce, 0);
      }
    }

    void OnCollisionExit(Collision collision){
      if(collision.collider.tag == "l" || collision.collider.tag == "g" || collision.collider.tag == "c" || collision.collider.tag == "r"){
        isOnGround = false;
      }
    }

    void OnCollisionStay(Collision collision){
      if(collision.collider.tag == "g" || collision.collider.tag == "r" || collision.collider.tag == "l" || collision.collider.tag == "c"){
        isOnGround = true;
      }
    }
}
