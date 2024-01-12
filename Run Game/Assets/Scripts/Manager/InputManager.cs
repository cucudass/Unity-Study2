using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action keyAction;

    void Update()
    {
        //Input.anyKey -> Key 입력 상태를 반환
        if (!Input.anyKey) return;
        if (keyAction != null) keyAction.Invoke(); //-> 설정된 액션이 있다면 해당 액션을 실행한다.
    }
}
