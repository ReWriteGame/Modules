#region Version scripts = 0.1

#endregion

using UnityEngine;
using UnityEngine.UI;

namespace Modules.Score.Visual
{
    public class ScoreCounterVisualBar : MonoBehaviour
    {
        [SerializeField] private Slider sliderValue;

        private ScoreCounter scoreCounter;

        private void OnDestroy() => Unsubscribe();
        
        public void SetScoreCounter(ScoreCounter scoreCounter)
        {
            if (this.scoreCounter != null) Unsubscribe();
            this.scoreCounter = scoreCounter;
            Subscribe();
            
            UpdateScore(scoreCounter.Value);
        }

        private void Subscribe()
        {
            if (scoreCounter == null) return;
            scoreCounter.OnChangeValue += UpdateScore;
        }

        private void Unsubscribe()
        {
            if (scoreCounter == null) return;
            scoreCounter.OnChangeValue -= UpdateScore;
        }

        private void UpdateScore(float value) => sliderValue.value = scoreCounter.GetValueInPercent();
    }
}