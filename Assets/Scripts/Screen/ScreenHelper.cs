using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ScreenSetup
{
    public class ScreenHelper : MonoBehaviour
    {
        public ScreenType screenType;

        public void OnClick()
        {
            ScreenManager.instance.ShowByType(screenType);
        }
    }
}
