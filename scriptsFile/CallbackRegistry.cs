using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace General
{
    public class Callback
    {
        public string name;
        public Action action;

        public Callback (string name, Action action)
        {
            this.action = action;
            this.name = name;
        }
    }

    public class CallbackRegistry : MonoBehaviour
    {
        public List<Callback> callbacks = new List<Callback>();

        public void AddCallback (Callback callback)
        {
            callbacks.Add(callback);
        }

        public void RemoveCallback (Callback callback)
        {
            callbacks.Remove(callback);
        }

        public Callback GetCallbackWithName (string name)
        {
            return callbacks.Find(callback => callback.name == name);
        }
    }
}
