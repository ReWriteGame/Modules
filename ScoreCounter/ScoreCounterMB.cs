using Modules.Score;
using UnityEngine;
using UnityEngine.Events;


public class ScoreCounterMB : MonoBehaviour
{
   [SerializeField] private ScoreCounter score;


   #region Events
   public UnityEvent<ScoreCounterData> OnChangeData;
   public UnityEvent<ScoreCounterData> OnChangeDataLastValue;
   public UnityEvent<float> OnChangeValue;
   public UnityEvent<float> OnChangeValueLastValue;
   public UnityEvent<float> OnIncreaseValue;
   public UnityEvent<float> OnDecreaseValue;
   public UnityEvent<float> OnCanNotIncreaseValue;
   public UnityEvent<float> OnCanNotDecreaseValue;
   public UnityEvent<Limit> OnChangeLimit;
   public UnityEvent<Limit> OnChangeLimitLastValue;
   public UnityEvent<float> OnChangeLimitMin;
   public UnityEvent<float> OnChangeLimitMinLastValue;
   public UnityEvent<float> OnIncreaseMinValue;
   public UnityEvent<float> OnDecreaseMinValue;
   public UnityEvent<float> OnChangeLimitMax;
   public UnityEvent<float> OnChangeLimitMaxLastValue;
   public UnityEvent<float> OnIncreaseMaxValue;
   public UnityEvent<float> OnDecreaseMaxValue;
   public UnityEvent OnReachMinValue;
   public UnityEvent OnReachMaxValue;
   
   #endregion
   
   public ScoreCounterData ScoreCounterData => score.Data;

   
   private void Awake()
   {
      SubscribeEvents();
   }

   private void OnDestroy()
   {
      UnsubscribeEvents();
   }

   

   public void IncreaseValue(float value)
   {
      score.IncreaseValue(value);
   }
   
   public void DecreaseValue(float value)
   {
      score.DecreaseValue(value);
   }
   
   public void IncreaseValueLimited(float value)
   {
      score.IncreaseValueLimited(value);
   }
   
   public void DecreaseValueLimited(float value)
   {
      score.DecreaseValueLimited(value);
   }
   

   public void IncreaseLimitMin(float value)
   {
      score.IncreaseLimitMin(value);
   }
   public void DecreaseLimitMin(float value)
   {
      score.DecreaseLimitMin(value);
   }
   public void IncreaseLimitMax(float value)
   {
      score.IncreaseLimitMax(value);
   }
   public void DecreaseLimitMax(float value)
   {
      score.DecreaseLimitMax(value);
   }
   
   
   #region SubscribeEvents
   private void SubscribeEvents()
   {
      score.OnChangeData += OnChangeData.Invoke;
      score.OnChangeDataLastValue += OnChangeDataLastValue.Invoke;
      score.OnChangeValue += OnChangeValue.Invoke;
      score.OnChangeValueLastValue += OnChangeValueLastValue.Invoke;
      score.OnIncreaseValue += OnIncreaseValue.Invoke;
      score.OnDecreaseValue += OnDecreaseValue.Invoke;
      score.OnCanNotIncreaseValue += OnCanNotIncreaseValue.Invoke;
      score.OnCanNotDecreaseValue += OnCanNotDecreaseValue.Invoke;
      score.OnChangeLimit += OnChangeLimit.Invoke;
      score.OnChangeLimitLastValue += OnChangeLimitLastValue.Invoke;
      score.OnChangeLimitMin += OnChangeLimitMin.Invoke;
      score.OnChangeLimitMinLastValue += OnChangeLimitMinLastValue.Invoke;
      score.OnIncreaseMinValue += OnIncreaseMinValue.Invoke;
      score.OnDecreaseMinValue += OnDecreaseMinValue.Invoke;
      score.OnChangeLimitMax += OnChangeLimitMax.Invoke;
      score.OnChangeLimitMaxLastValue += OnChangeLimitMaxLastValue.Invoke;
      score.OnIncreaseMaxValue += OnIncreaseMaxValue.Invoke;
      score.OnDecreaseMaxValue += OnDecreaseMaxValue.Invoke;
      score.OnReachMinValue += OnReachMinValue.Invoke;
      score.OnReachMaxValue += OnReachMaxValue.Invoke;
   }
   
   private void UnsubscribeEvents()
   {
      score.OnChangeData -= OnChangeData.Invoke;
      score.OnChangeDataLastValue -= OnChangeDataLastValue.Invoke;
      score.OnChangeValue -= OnChangeValue.Invoke;
      score.OnChangeValueLastValue -= OnChangeValueLastValue.Invoke;
      score.OnIncreaseValue -= OnIncreaseValue.Invoke;
      score.OnDecreaseValue -= OnDecreaseValue.Invoke;
      score.OnCanNotIncreaseValue -= OnCanNotIncreaseValue.Invoke;
      score.OnCanNotDecreaseValue -= OnCanNotDecreaseValue.Invoke;
      score.OnChangeLimit -= OnChangeLimit.Invoke;
      score.OnChangeLimitLastValue -= OnChangeLimitLastValue.Invoke;
      score.OnChangeLimitMin -= OnChangeLimitMin.Invoke;
      score.OnChangeLimitMinLastValue -= OnChangeLimitMinLastValue.Invoke;
      score.OnIncreaseMinValue -= OnIncreaseMinValue.Invoke;
      score.OnDecreaseMinValue -= OnDecreaseMinValue.Invoke;
      score.OnChangeLimitMax -= OnChangeLimitMax.Invoke;
      score.OnChangeLimitMaxLastValue -= OnChangeLimitMaxLastValue.Invoke;
      score.OnIncreaseMaxValue -= OnIncreaseMaxValue.Invoke;
      score.OnDecreaseMaxValue -= OnDecreaseMaxValue.Invoke;
      score.OnReachMinValue -= OnReachMinValue.Invoke;
      score.OnReachMaxValue -= OnReachMaxValue.Invoke;
   }
   
   #endregion
}

