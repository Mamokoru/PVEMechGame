using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private bool IsMovementEnabled;
    [SerializeField] private float MovementSpeed = 5f;

    [SerializeField] private CharacterController m_CharacterController;

    [SerializeField] private PlayerInput m_Input;

    InputData m_inputData;

    Vector3 moveInputVector, rotateInputVector;
    private void Update()
    {
        if (!IsMovementEnabled) return;
        // implement movement logic here
        m_inputData = m_Input.GetInputData();

        ChangePlayerRoataion();
        MovePlayer();
    }

    private void ChangePlayerRoataion()
    {
        rotateInputVector.x = m_inputData.LookRotation.x;
        rotateInputVector.y = m_inputData.LookRotation.y;

        transform.Rotate(0, rotateInputVector.x, 0);
    }

    private void MovePlayer()
    {
        moveInputVector.x = m_inputData.MoveVector.x;
        moveInputVector.z = m_inputData.MoveVector.y;

        m_CharacterController.Move(moveInputVector * MovementSpeed * Time.deltaTime);
    }
}
