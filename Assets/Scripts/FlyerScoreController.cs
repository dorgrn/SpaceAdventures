using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace VRStandardAssets.Common
{


    public class FlyerScoreController : MonoBehaviour
    {
        [SerializeField]
        private int m_StartingScore = 0;
        [SerializeField]
        private Text m_ScoreText;

        void Start()
        {
            if (m_ScoreText == null)
            {
                Debug.Log("Score text not set");
                return;
            }

            m_ScoreText.text = m_StartingScore.ToString();



        }

        public void OnScoreChange(int difference)
        {
            if (m_ScoreText != null)
            {
                m_ScoreText.text = "SCORE: " + (SessionData.Score + difference).ToString();
            }
        }
    }
}