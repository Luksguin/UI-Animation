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
        public List<Transform> listOfButtons;
        public List<Typper> listOfPhrases;
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
            for(int i = 0; i < listOfButtons.Count; i++)
            {
                var obj = listOfButtons[i];

                obj.gameObject.SetActive(true);
                obj.DOScale(0, animationDuration).From().SetDelay(i * delayBetweenObjects);
            }

            Invoke(nameof(ShowPhrases), delayBetweenObjects * listOfButtons.Count);
        }

        public void ShowPhrases()
        {
            for (int i = 0; i < listOfPhrases.Count; i++)
            {
                listOfPhrases[i].StartText();
            }
        }

        public void HideObjects()
        {
            listOfButtons.ForEach(i => i.gameObject.SetActive(false));
            listOfPhrases.ForEach(i => i.DeleteText());
        }
    }
}
