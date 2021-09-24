using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 움직일때 Character가 이동하는 방향이 Vector3.zero로 되어있는데 이걸 변경해줌.
public class CharacterMoveDirection : MonoBehaviour // 좌우이동 버튼을 작동할때 캐릭터가 이동할 방향을 정해줌 (x축 좌우 이동할 것인지 z축 좌우로 움직일 것인지)
{
    // This makes the character turn to face the current movement speed per default.
    public Vector3 inputMoveDirection = Vector3.zero;
    public float maxRotationSpeed = 360; // 

    // Update is called once per frame
    void Update()
    {
        // Get the input vector from kayboard or analog stick
        Vector3 directionVector = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
        // directionVector로 수평입력시 이동하는 방향을 가져옴

        if (directionVector != Vector3.zero) // 수평방향으로 이동할때 (방향벡터가 0이 아닐때) (Vector3.zero는 (0,0,0)을 의미)
        {
            float directionLength = directionVector.magnitude; // 벡터길이를 변환하여 directionLength로 저장
        }
        // 입력 벡터를 카메라 공간으로 회전함. 그래서 카메라의 왼쪽과 오른쪽 방향은 벡터의 왼쪽과 오른쪽방향이 됨.
        directionVector = Camera.main.transform.rotation * directionVector;
        // 입력 벡터를 문자의 위쪽 벡터에 수직으로 회전
        Quaternion camToCharacterSpace = Quaternion.FromToRotation(-Camera.main.transform.forward, transform.up);
        directionVector = (camToCharacterSpace * directionVector);

        inputMoveDirection = directionVector; // 캐릭터의 방향을 정해줌. directionVector에 캐릭터가 이동해야할 방향이 있음.
    }
}
