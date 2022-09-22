using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NaughtyAttributes;
using TMPro;
using UnityEngine;

namespace Modules.Score.Visual
{
    [ExecuteInEditMode]
    public class ScoreCounterTextVisual : MonoBehaviour
    {
        [SerializeField] private Behaviour objectForVisual;

        [Dropdown(nameof(scoreNameFields))] [SerializeField]
        private string nameField;

        [SerializeField] private TextMeshProUGUI scoreLabel;
        [SerializeField] private TextMeshProUGUI scoreLimitMinLabel;
        [SerializeField] private TextMeshProUGUI scoreLimitMaxLabel;
        [SerializeField] private string scoreFormat = "00.00";
        [SerializeField] private bool showValueInPercent = false;


        private List<Tuple<ScoreCounter, string>> fields;
        private List<string> scoreNameFields = new List<string> {"Null"};
        private List<ScoreCounter> scoreFields;
        private ScoreCounter scoreCounter;
        private int indexVisual;

        private void OnEnable()
        {
            SelectAndApplyIndex();
            if (!IsNullOrEmpty()) scoreCounter = scoreFields[indexVisual];

            if (scoreCounter != null)
            {
                UpdateScoreCounter(scoreCounter.Value);
                UpdateLimitMin(scoreCounter.MinValue);
                UpdateLimitMax(scoreCounter.MaxValue);


                scoreCounter.OnChangeValue += UpdateScoreCounter;
                scoreCounter.OnChangeLimitMin += UpdateLimitMin;
                scoreCounter.OnChangeLimitMax += UpdateLimitMax;
            }
        }

        private void OnDisable()
        {
            if (scoreCounter != null)
            {
                scoreCounter.OnChangeValue -= UpdateScoreCounter;
                scoreCounter.OnChangeLimitMin -= UpdateLimitMin;
                scoreCounter.OnChangeLimitMax -= UpdateLimitMax;
            }
        }

        private void Update()
        {
            if (!Application.isPlaying) SelectAndApplyIndex();
        }

        private void Reset()
        {
            scoreNameFields = new List<string> {"Null"};
        }

        private void UpdateScoreCounter(float value)
        {
            ShowValue(scoreLabel, scoreCounter.Value, scoreFormat);
        }

        private void UpdateLimitMin(float value)
        {
            ShowValue(scoreLimitMinLabel, scoreCounter.MinValue, scoreFormat);
        }

        private void UpdateLimitMax(float value)
        {
            ShowValue(scoreLimitMaxLabel, scoreCounter.MaxValue, scoreFormat);
        }

        private void ShowValue(TextMeshProUGUI label, float value, string format = "00.00")
        {
            if (label == null || scoreCounter == null)
            {
                return;
            }

            if (showValueInPercent) value = ShowInPercent(value, scoreCounter.MinValue);
            label.text = value.ToString(format: $"{format}");
        }

        private float ShowInPercent(float value, float minValue)
        {
            float sizeLimit = scoreCounter.Data.ValueLimit.GetLengthLimit();
            float valueInLimit = scoreCounter.Data.LengthCurrentScoreToMinimum();
            float percentValue = sizeLimit / valueInLimit;
            return 100 / percentValue;
            //todo make this metods in scorecounter
        }

        private void FindAllFieldsObject()
        {
            fields = ReflectionAllFieldsObject(objectForVisual);
            if (!IsNullOrEmpty())
            {
                scoreFields = fields.Select(x => x.Item1).ToList();
                scoreNameFields = fields.Select(x => x.Item2).ToList();
            }
            else
            {
                Debug.LogWarning("Object dont contain ScoreCounters");
                Reset();
            }
        }

        private void SelectAndApplyIndex()
        {
            if (objectForVisual)
            {
                FindAllFieldsObject();
                if (IsNullOrEmpty()) indexVisual = scoreNameFields.FindIndex(a => a.Contains(nameField));
            }
        }

        private List<Tuple<ScoreCounter, string>> ReflectionAllFieldsObject(object obj) // scans all fields of an object
        {
            return obj.GetType()
                .GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                .Where(x => x.FieldType == typeof(ScoreCounter))
                .Select(x => Tuple.Create(x.GetValue(obj) as ScoreCounter, x.Name)).ToList();
        }

        private bool IsNullOrEmpty()
        {
            return !fields?.Any() == true;
        }
    }
}
//initialized on start(cannot be changed in playMode)