using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>
{
    public Action keyAction;

    void Update()
    {
        //Input.anyKey -> Key �Է� ���¸� ��ȯ
        if (!Input.anyKey) return;
        if (keyAction != null) keyAction.Invoke(); //-> ������ �׼��� �ִٸ� �ش� �׼��� �����Ѵ�.
    }
}
