using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  private CharacterController characterController;
  public float jumpForce = 10.0f; 
  public float gravity = 20.0f; 
  private float verticalVelocity = 0.0f;
  public int speed = 5;
  public float rotationSpeed = 2.0f;
  public Vector2 movement;
  private Transform myCamera;
  private InputAction jumpAction;
  private InputAction cursorAction;
  public bool cursorCheck = false;

  public GameObject cam;

  public void Awake()
  {
        Cursor.visible = false; // Para tornar o cursor invisivel
        Cursor.lockState = CursorLockMode.Locked;

        characterController = GetComponent<CharacterController>();
        myCamera = Camera.main.transform;

     // Configura a ação de salto usando o New Input System
        jumpAction = new InputAction(type: InputActionType.Button, binding: "<Jump>");
        jumpAction.Enable();
        jumpAction.performed += OnJumpPerformed;

  }

    public void OnJumpPerformed(InputAction.CallbackContext context)
    {
        // Verifica se o Character Controller está no chão
        if (characterController.isGrounded)
        {
            // Aplicar a força de salto vertical
            verticalVelocity = jumpForce;
        }
    }

  public void SetMove(InputAction.CallbackContext value)
  {
    if(characterController.isGrounded && cursorCheck == false)
    {
    movement = value.ReadValue<Vector2>();
    }

  }

  public void CursorAlt(InputAction.CallbackContext context)
  {
     //cursorAction = new InputAction(type: InputActionType.Button, binding: "<Left Alt>");
     //cursorAction.Enable();
     if(cursorCheck == true){
      cursorCheck = false;
     }
     else{
      cursorCheck = true;
     }
  }


  public void FixedUpdate()
    {
        // Rotação do jogador para coincidir com a rotação da câmera no eixo Y
        float targetRotation = myCamera.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, targetRotation, 0), rotationSpeed * Time.fixedDeltaTime);


        Vector3 moveDirection = new Vector3(movement.x, 0, movement.y);
        moveDirection = Quaternion.Euler(0, targetRotation, 0) * moveDirection; // Transforma a direção de movimento com base na rotação da câmera
        characterController.Move(moveDirection * speed * Time.fixedDeltaTime);
           // Aplicar a gravidade para evitar que o personagem flutue no ar
        verticalVelocity -= gravity * Time.deltaTime;

        // Cria um vetor de movimento que inclui a gravidade
        Vector3 jumpDirection = new Vector3(0, verticalVelocity, 0);

        // Move o Character Controller
        characterController.Move(jumpDirection * Time.deltaTime);

        if(cursorCheck == true)
        {
        Cursor.visible = true; // Para tornar o cursor visível
        Cursor.lockState = CursorLockMode.None; // Para desbloquear o cursor
        cam.SetActive(false);
        }
        else{
          Cursor.visible = false;
          Cursor.lockState = CursorLockMode.Locked;
          cam.SetActive(true);
        }
    }

}
