
using GD.MinMaxSlider;
using Modules.Score;
using UnityEngine;
using UnityEngine.Events;


   public class ScoreCounterMB : MonoBehaviour
   {
      [SerializeField] private ScoreCounter health;
      [MinMaxSlider(5,10)][SerializeField] private Vector2 fhfg;
      [SerializeField]public Test d = new Test(4,3);
      
      
     
      
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

      public ScoreCounter ScoreCounter
      {
         get => health;
         set => health = value;
      }
      private void Awake()
      {
         health.OnChangeValue += OnChangeValue.Invoke;
         //OnChangeValueLastValue
         //OnIncreaseValue
         //OnDecreaseValue
         //OnCanNotIncreaseValue
         //OnCanNotDecreaseValue
         //OnChangeLimit
         //OnChangeLimitLastValue
         //OnChangeLimitMin
         //OnChangeLimitMinLastValue
         //OnIncreaseMinValue
         //OnDecreaseMinValue
         //OnChangeLimitMax
         //OnChangeLimitMaxLastValue
         //OnIncreaseMaxValue
         //OnDecreaseMaxValue
      }

      public void Increase(float value)
      {
         health.IncreaseValue(value);
      }
      
      public void IncreaseLim(float value)
      {
         health.IncreaseValueLimited(value);
      }
      
      public void Decrease(float value)
      {
         health.DecreaseValue(value);
      }
      
      public void DecreaseLim(float value)
      {
         health.DecreaseValueLimited(value);
      }

      public void IncreaseLimitMin(float value)
      {
         health.IncreaseLimitMin(value);
      }
        
      public void IncreaseLimitMax(float value)
      {
         health.IncreaseLimitMax(value);
      }
      public void DecreaseLimitMin(float value)
      {
         health.DecreaseLimitMin(value);
      }
        
      public void DecreaseLimitMax(float value)
      {
         health.DecreaseLimitMax(value);
      }
   }

