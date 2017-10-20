using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Flyer
{
    // This script controls the flow of the flyer
    // game and how all the other controllers work
    // together.
    public class FlyerGameController : MonoBehaviour
    {
        [SerializeField] private int m_GameDuration = 30;                                   // The duration of the game
        //[SerializeField] private Reticle m_Reticle;                                         // The reticle so it can be turned on to aim at the selection slider.
        [SerializeField] private FlyerHealthController m_HealthController;                  // The flyer's health so it can be reset.
        [SerializeField] private FlyerAlignmentChecker m_AlignmentChecker;                  // The script to check ring alignments, it should only be on whilst the game runs.
        [SerializeField] private FlyerMovementController m_FlyerMovementController;         // The script controlling the movement of the flyer.
        [SerializeField] private EnvironmentController m_EnvironmentController;             // This needs to know when to start and stop spawning the environment.
        [SerializeField] private UIController m_UIController;                               // This needs to know when specific pieces of UI should be shown.
        //[SerializeField] private GUIArrows m_GuiArrows;                                     // The GUI Arrows shown at the start.
        [SerializeField] private Image m_TimerBar;                                          // Timer slider to indicate time remaining.                                
        [SerializeField] private SelectionRadial m_SelectionRadial;                         // Used to restart the game.
        

        private float m_EndTime;                                                            // The time at the point the game should end.
        private float m_TimeRemaining;                                                      // The time until the game should end.
        private bool m_IsGameRunning;                                                       // Whether the game is currently running.


        public bool IsGameRunning { get { return m_IsGameRunning; } }


        private IEnumerator Start()
        {
            while (true)
            {
                yield return StartCoroutine (StartPhase ());
                yield return StartCoroutine (PlayPhase ());
                yield return StartCoroutine (EndPhase ());
            }
        }


        private IEnumerator StartPhase ()
        {
            m_HealthController.StopGame ();
            yield return null;
        }


        private IEnumerator PlayPhase ()
        {
            // The game is now running.
            m_IsGameRunning = true;

            // Start the various controllers.
            m_AlignmentChecker.StartGame ();
            m_HealthController.StartGame ();
            m_FlyerMovementController.StartGame ();
            m_EnvironmentController.StartEnvironment();

            // The end of the game is the current time + the length of the game.
            m_EndTime = Time.time + m_GameDuration;

            // Each frame while the flyer is alive and there is time remaining...
            do
            {
                // Calculate the time remaining set the timer bar to fill by the normalised time remaining.
                m_TimeRemaining = m_EndTime - Time.time;
                m_TimerBar.fillAmount = m_TimeRemaining / m_GameDuration;

                // Wait until the next frame.
                yield return null;
            }
            while (m_TimeRemaining > 0f && !m_HealthController.IsDead);
            
            // Upon reaching this point either the time has run out or the flyer is dead, either way the game is no longer running.
            m_IsGameRunning = false;
        }


        private IEnumerator EndPhase ()
        { 
            // Show the required UI like the arrows and the radial.
            //m_GuiArrows.Show ();
            //m_SelectionRadial.Show ();

            // Show the outro UI.
           // StartCoroutine(m_UIController.ShowOutroUI());

            // Stop the various controllers.
            m_AlignmentChecker.StopGame();
            m_HealthController.StopGame();
            m_FlyerMovementController.StopGame();
            m_EnvironmentController.StopEnvironment();

            yield return null;
        }
    }
}