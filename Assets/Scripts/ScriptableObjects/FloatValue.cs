﻿using System;
using UnityEngine;

[CreateAssetMenu]
public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
{
    public float InitialValue;
    [HideInInspector]
    public float RuntimeValue;

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        RuntimeValue = InitialValue;
    }
}
