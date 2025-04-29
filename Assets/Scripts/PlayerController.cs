using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1; // 0=left 1=middle 2=right
    public float laneDistance = 4; // distance between two lanes
    
    public float jumpForce;
    public float gravity = -20;

    // start is called once before the first execution of Update after the MonoBehaviour is created
    void Start(){
        controller = GetComponent<CharacterController>();
    }

    // update is called once per frame
    void Update(){
        direction.z = forwardSpeed;

        if(controller.isGrounded){
            if(Input.GetKeyDown(KeyCode.UpArrow)){
            Jump();
            }
        }
        else{
            direction.y += gravity*Time.deltaTime;
        }

        // gather the inputs the lane they should be

        if(Input.GetKeyDown(KeyCode.RightArrow)){
            desiredLane++;
            if(desiredLane > 2) {
                desiredLane = 2;
            }
        }

        if(Input.GetKeyDown(KeyCode.LeftArrow)){
            desiredLane--;
            if(desiredLane < 0) {
                desiredLane = 0;
            }
        }

        // calculate where we should be in the future

        Vector3 targetPosition = transform.position.z*transform.forward+transform.position.y*transform.up;

        if(desiredLane == 0){
            targetPosition += Vector3.left*laneDistance;
        }
        else if(desiredLane == 2){
            targetPosition += Vector3.right*laneDistance;
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, 80*Time.fixedDeltaTime);
        controller.center = controller.center;
    }

    private void FixedUpdate(){
        controller.Move(direction*Time.fixedDeltaTime);
    }

    private void Jump(){
        direction.y = jumpForce;
    }
}
