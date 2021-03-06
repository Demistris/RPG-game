﻿using UnityEngine;

[CreateAssetMenu]
public class VectorValue : ScriptableObject, ISerializationCallbackReceiver
{
    public Vector2 InitialValue;
    public Vector2 DefaultValue;

    public void OnBeforeSerialize()
    {

    }

    public void OnAfterDeserialize()
    {
        InitialValue = DefaultValue;
    }
}
