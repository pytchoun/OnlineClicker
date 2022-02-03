using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using clicker;

public class ShopManager : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _shopPanel;
    [SerializeField] private TMP_Text _clickLevel;
    [SerializeField] private TMP_Text _clickGain;
    [SerializeField] private TMP_Text _autoGathererLevel;
    [SerializeField] private TMP_Text _autoGathererGain;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private TileManager _tileManager;

    // Variables
    private int _currentClickLevel;
    private int _currentAutoGathererLevel;

    public int GetClickLevel()
    {
        return _currentClickLevel;
    }

    public void SetClickLevel(int level)
    {
        _currentClickLevel = level;

        _clickLevel.SetText("Level " + _currentClickLevel.ToString());
        double value = PowerOfTwo(_currentClickLevel);
        _playerScore.Amount = (int)value;
        _clickGain.SetText(value + " per click");
    }

    public int GetAutoGathererLevel()
    {
        return _currentAutoGathererLevel;
    }

    public void SetAutoGathererLevel(int level)
    {
        _currentAutoGathererLevel = level;

        _autoGathererLevel.SetText("Level " + _currentAutoGathererLevel.ToString());
        double value = PowerOfTwo(_currentAutoGathererLevel, true);
        _autoGathererGain.SetText(value + " evey 5s");
    }

    private void Start()
    {
        Init();
        StartCoroutine(AutoGatherer(5));
    }

    private void Init()
    {
        _currentClickLevel = 0;
        _currentAutoGathererLevel = 0;

        _clickLevel.SetText("Level " + _currentClickLevel.ToString());
        double value = PowerOfTwo(_currentClickLevel);
        _clickGain.SetText(value + " per click");

        _autoGathererLevel.SetText("Level " + _currentAutoGathererLevel.ToString());
        value = PowerOfTwo(_currentAutoGathererLevel, true);
        _autoGathererGain.SetText(value + " evey 5s");
    }

    private IEnumerator AutoGatherer(float waitTime)
    {
        WaitForSeconds timeToWait = new WaitForSeconds(waitTime);
        while (true)
        {
            double value = PowerOfTwo(_currentAutoGathererLevel, true);
            _playerScore.IncreaseScore((int)value);
            yield return timeToWait;
        }
    }

    public void ToggleMenu()
    {
        _shopPanel.SetActive(!_shopPanel.activeSelf);
    }

    private double PowerOfTwo(int value, bool subtract = false)
    {
        if (subtract)
        {
            value--;
            if (value < 0)
            {
                return 0;
            }
            return Math.Pow(2, value);
        }
        else
        {
            return Math.Pow(2, value);
        }   
    }

    public void ClickUpgrade()
    {
        if (_playerScore.GetScore() >= 20 && _currentClickLevel < 10)
        {
            _playerScore.DecreaseScore(20);
            _currentClickLevel++;
            _clickLevel.SetText("Level " + _currentClickLevel.ToString());
            double value = PowerOfTwo(_currentClickLevel);
            _playerScore.Amount = (int)value;
            _clickGain.SetText(value + " per click");
        }
    }

    public void AutoGathererUpgrade()
    {
        if (_playerScore.GetScore() >= 20 && _currentAutoGathererLevel < 10)
        {
            _playerScore.DecreaseScore(20);
            _currentAutoGathererLevel++;
            _autoGathererLevel.SetText("Level " + _currentAutoGathererLevel.ToString());
            double value = PowerOfTwo(_currentAutoGathererLevel, true);
            _autoGathererGain.SetText(value + " evey 5s");
        }
    }

    public void BuyTree(GameObject tree)
    {
        if (_playerScore.GetScore() >= 20)
        {
            GameObject title = _tileManager.GetTile();
            if (title != null)
            {
                _playerScore.DecreaseScore(20);
                SpawnTree(tree, title);
            }  
        }
    }

    private void SpawnTree(GameObject tree, GameObject tile)
    {
        Instantiate(tree, tile.transform.position + new Vector3(0f, 0.5f, 0f), Quaternion.identity, tile.transform);
    }
}