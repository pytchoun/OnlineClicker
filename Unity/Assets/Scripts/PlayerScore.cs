using TMPro;
using UnityEngine;

namespace clicker
{
    public class PlayerScore : MonoBehaviour
    {
        [SerializeField] private TMP_Text _textbox;
        private int _score;
        public int Amount;

        private void Start()
        {
            Amount = 1;
        }

        public int GetScore()
        {
            return _score;
        }

        private void OnEnable()
        {
            _textbox.SetText(_score.ToString());
        }

        public void IncreaseScore()
        {
            _score += Amount;
            _textbox.SetText(_score.ToString());
        }

        public void IncreaseScore(int value)
        {
            _score += value;
            _textbox.SetText(_score.ToString());
        }

        public void DecreaseScore(int value)
        {
            _score -= value;
            _textbox.SetText(_score.ToString());
        }
    }
}