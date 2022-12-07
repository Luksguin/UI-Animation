using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NaughtyAttributes;
using DG.Tweening;

namespace ScreenSetup
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Shop
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public bool startHide = false;

        [Header("Animations")]
        public float animationDuration;
        public float delayBetweenObjects;

        private void Start()
        {
            if (startHide)
            {
                Hide();
            }
        }

        [Button]
        protected void Show()
        {
            ShowObjects();
        }

        [Button]
        protected void Hide()
        {
            HideObjects();
        }

        public void ShowObjects()
        {
            for(int i = 0; i < listOfObjects.Count; i++)
            {
                var obj = listOfObjects[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }
        }

        public void HideObjects()
        {
            listOfObjects.ForEach(i => i.gameObject.SetActive(false)); 
        }
    }
}
