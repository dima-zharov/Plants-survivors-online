using System;
using UnityEngine;

public class AnimationEventManager : MonoBehaviour
{ 
    public static Action<bool, string> BoolParametChanged;

    public static void SendBoolParametrChanged(bool animState, string parameterName)
    {
        if (BoolParametChanged != null)
            BoolParametChanged.Invoke(animState, parameterName);
    }
}
