using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NaughtyAttributes;
using DG.Tweening;

namespace ScreenSetup
{
    public enum ScreenType
    {
        Panel,
        Info_Panel,
        Ranking,
        Shop
    }
    public class ScreenBase : MonoBehaviour
    {
        public ScreenType screenType;
        public List<Transform> listOfObjects;
        public List<Typper> listOfPhrases;

        public Image uiBackground;

        public bool startHide = false;

        [Header("Animations")]
        public float animationDuration;
        public float delayBetweenObjects;

        private void Awake()
        {
            if (startHide)
            {
                Hide();
            }
        }

        [Button]
        public void Show()
        {
            if (uiBackground != null) uiBackground.enabled = true;
            ShowObjects();
        }

        [Button]
        public void Hide()
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

            Invoke(nameof(ShowPhrases), delayBetweenObjects * listOfObjects.Count);
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
            listOfObjects.ForEach(i => i.gameObject.SetActive(false));
            listOfPhrases.ForEach(i => i.DeleteText());
            if(uiBackground != null) uiBackground.enabled = false;
        }
    }
}
