using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    class FloatCompare : IEqualityComparer<float> {
        public bool Equals(float x, float y) {
            return x == y;
        }

        public int GetHashCode(float obj) {
            return obj.GetHashCode();
        }
    }

    private static readonly Dictionary<float, WaitForSeconds> timeInerval = new Dictionary<float, WaitForSeconds>(new FloatCompare());

    public static WaitForSeconds waitForSeconds(float time) {
        WaitForSeconds waitForSeconds; //WaitForSeconds 클래스 선언
        
        if (!timeInerval.TryGetValue(time, out waitForSeconds)) { //timeInerval에 유무 확인
            timeInerval.Add(time, waitForSeconds = new WaitForSeconds(time)); //timeInerval에 없으면 add 한다.
        }
        return waitForSeconds;
    }
}
