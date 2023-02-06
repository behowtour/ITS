using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Currency<T>
{
    public abstract event Action<T> OnValueChangedEvent; 
    public T value;

    public abstract void Add(T amount);
    public abstract void Spent(T amount);
}
