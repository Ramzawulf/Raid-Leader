using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar: MonoBehaviour
    {
        //TODO: Pimp up to go into the asset store
        public Image ForeGround;
        public Image BackGround;
        public Text ValueLabel;

        public float MaxValue = 100;
        private float _currentValue;
        private string _barName;
        public string BarName {
            get
            {
                return _barName;
            }
            set
            {
                _barName = value;
                UpdateBar();
            }
        }

        public void Awake ()
        {
            if (ForeGround == null)
                ForeGround = transform.Find ("Foreground").GetComponent<Image> ();
            if (BackGround == null)
                BackGround = transform.Find ("BackGround").GetComponent<Image> ();
            if (ValueLabel == null)
                ValueLabel = transform.Find ("ValueLabel").GetComponent<Text> ();
        }

        public float CurrentValue {
            get {
                return _currentValue;
            }
            set { 
                _currentValue = value;
                UpdateBar ();
            }
        }

        private void UpdateBar ()
        {
            if (MaxValue != 0)
                ForeGround.fillAmount = Mathf.Max (_currentValue / MaxValue);
            string labelValue = "";
            if (!string.IsNullOrEmpty(BarName))
                labelValue = BarName + ": ";
            labelValue += string.Format("{0}/{1}", CurrentValue, MaxValue);
            ValueLabel.text = labelValue;
        }
    }
}

