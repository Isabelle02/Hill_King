using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Frame.UI
{
    public class FButton : UnityEngine.UI.Button
    {
        public event UnityAction OnClick
        {
            add => onClick.AddListener(value);
            remove => onClick.RemoveListener(value);
        }
    }   
}
