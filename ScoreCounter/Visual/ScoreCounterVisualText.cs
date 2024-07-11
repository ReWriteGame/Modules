#region Version scripts = 0.3 // test script

#endregion

using System;
using TMPro;
using UnityEngine;

namespace Modules.Score.Visual
{
    public class ScoreCounterVisualText : MonoBehaviour
    {
        [SerializeField] private Label valueLabel;
        [SerializeField] private Label valueMinLabel;
        [SerializeField] private Label valueMaxLabel;
        [SerializeField] private bool showValueInPercent;

        private ScoreCounter scoreCounter;

        private void OnDestroy() => Unsubscribe();

        public void SetScoreCounter(ScoreCounter scoreCounter)
        {
            if (this.scoreCounter != null) Unsubscribe();
            this.scoreCounter = scoreCounter;
            Subscribe();
            UpdateScore();
        }

        public void UpdateScore()
        {
            UpdateScore(scoreCounter.Value);
            UpdateLimitMin(scoreCounter.MinValue);
            UpdateLimitMax(scoreCounter.MaxValue);
        }

        private void Subscribe()
        {
            if (scoreCounter == null) return;
            scoreCounter.OnChangeValue += UpdateScore;
            scoreCounter.OnChangeLimitMin += UpdateLimitMin;
            scoreCounter.OnChangeLimitMax += UpdateLimitMax;
        }

        private void Unsubscribe()
        {
            if (scoreCounter == null) return;
            scoreCounter.OnChangeValue -= UpdateScore;
            scoreCounter.OnChangeLimitMin -= UpdateLimitMin;
            scoreCounter.OnChangeLimitMax -= UpdateLimitMax;
        }

        private void UpdateScore(float value) => ShowLabel(valueLabel.label, showValueInPercent,
            $"{scoreCounter.GetValueInPercent() * 100}", ShowValue(value, valueLabel.textFormat, valueLabel.centerSymbol));

        private void UpdateLimitMin(float value) => ShowLabel(valueMinLabel.label, showValueInPercent,
            $"{0}", ShowValue(value, valueMinLabel.textFormat, valueMinLabel.centerSymbol));

        private void UpdateLimitMax(float value) => ShowLabel(valueMaxLabel.label, showValueInPercent,
            $"{100}", ShowValue(value, valueMaxLabel.textFormat, valueMaxLabel.centerSymbol));

        private string ShowValue(float value, string format = "00.00", string replaceSymbol = ".") =>
            value.ToString(format: $"{format}").Replace(",", $"{replaceSymbol}");

        private void ShowLabel(TextMeshProUGUI label, bool isPercent, string value1, string value2)
        {
            if (label == null || scoreCounter == null) return;
            label.text = (isPercent) ? value1 : value2;
        }

        [Serializable]
        private class Label
        {
            public TextMeshProUGUI label;
            public string textFormat = "00.00";
            public string centerSymbol = ".";
        }
    }
}