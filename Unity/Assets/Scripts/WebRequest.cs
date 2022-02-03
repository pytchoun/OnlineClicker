using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using clicker;

public class WebRequest : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private GameObject _savingPanel;
    [SerializeField] private GameObject _loadPanel;
    [SerializeField] private TMP_Text _notificationText;
    [SerializeField] private TMP_Text _saveCodeText;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private PlayerScore _playerScore;
    [SerializeField] private ShopManager _shopManager;

    // Variables
    private string _saveUrl = "http://localhost/onlineclicker/saveData.php";
    private string _loadUrl = "http://localhost/onlineclicker/loadData.php";
    private bool _isSaving = false;

    public void ToggleSaving()
    {
        _savingPanel.SetActive(!_savingPanel.activeSelf);
    }

    public void ToggleLoading()
    {
        _loadPanel.SetActive(!_loadPanel.activeSelf);
        _inputField.text = "";
    }

    public void SaveData()
    {
        if (_isSaving)
            return;
        _isSaving = true;
        StartCoroutine(SaveData(_playerScore.GetScore(), _shopManager.GetClickLevel(), _shopManager.GetAutoGathererLevel()));
    }

    private IEnumerator SaveData(int score, int clickLevel, int autoGathererLevel)
    {
        WWWForm form = new WWWForm();
        form.AddField("score", score);
        form.AddField("clickLevel", clickLevel);
        form.AddField("autoGathererLevel", autoGathererLevel);

        using (UnityWebRequest www = UnityWebRequest.Post(_saveUrl, form))
        {
            ToggleSaving();
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                _notificationText.SetText(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                _saveCodeText.SetText("Code: " + www.downloadHandler.text);
                _notificationText.SetText("Save completed.");
            }

            WaitForSeconds timeToWait = new WaitForSeconds(0.5f);

            yield return timeToWait;
            ToggleSaving();
            _notificationText.gameObject.SetActive(!_notificationText.gameObject.activeSelf);

            yield return timeToWait;
            _notificationText.gameObject.SetActive(!_notificationText.gameObject.activeSelf);
            _isSaving = false;
        }
    }

    public void LoadData()
    {
        StartCoroutine(GetSaveData(_inputField.text));
    }

    private IEnumerator GetSaveData(string userSaveToken)
    {
        WWWForm form = new WWWForm();
        form.AddField("userSaveToken", userSaveToken);

        using (UnityWebRequest www = UnityWebRequest.Post(_loadUrl, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
                _notificationText.SetText(www.error);
            }
            else
            {
                //Debug.Log(www.downloadHandler.text);
                _notificationText.SetText("Load completed.");

                string saveData = www.downloadHandler.text;
                string[] arrayData = saveData.Split(' ');
                SetData(int.Parse(arrayData[0]), int.Parse(arrayData[1]), int.Parse(arrayData[2]));
                /*Debug.Log(arrayData[0]);
                Debug.Log(arrayData[1]);
                Debug.Log(arrayData[2]);*/
            }

            WaitForSeconds timeToWait = new WaitForSeconds(0.5f);

            //yield return timeToWait;
            _notificationText.gameObject.SetActive(!_notificationText.gameObject.activeSelf);

            yield return timeToWait;
            _notificationText.gameObject.SetActive(!_notificationText.gameObject.activeSelf);
        }
    }

    private void SetData(int score, int clickLevel, int autoGathererLevel)
    {
        _playerScore.SetScore(score);
        _shopManager.SetClickLevel(clickLevel);
        _shopManager.SetAutoGathererLevel(autoGathererLevel);
    }
}