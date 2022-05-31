using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    #region Variables

    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI _headerLabel;
    [SerializeField] private TextMeshProUGUI _descriptionLabel;
    [SerializeField] private TextMeshProUGUI _choicesLabel;
    [SerializeField] private TextMeshProUGUI _namelocationLabel;
    [SerializeField] private Image _image;
    [SerializeField] private Button _menuButton;

    [Header("Initial Setup")]
    [SerializeField] private Step _startStep;

    [Header("External Components")]
    [SerializeField] private SceneLoader _sceneLoader;
    [SerializeField] private string _menuSceneName;
    [SerializeField] private string _gameOverSceneName;

   

    private Step _currentStep;

    #endregion


    #region Unity lifecycle

    private void Start()
    {
        _menuButton.onClick.AddListener(MenuButtonClicked);
        SetCurrentStep(_startStep);
    }

    private void Update()
    {

        CheckGameOver();
        int choiceIndex = GetPressedButtonIndex();

        if (!IsIndexValid(choiceIndex))
            return;
        
        SetCurrentStep(choiceIndex);
    }

    #endregion


    #region Private methods

    private void CheckGameOver()
    {
        if (!Input.GetKeyDown(KeyCode.Return))
            return;
        if (_currentStep.Choices.Length == 0)
            _sceneLoader.LoadScene(_gameOverSceneName);
    }

    private bool IsIndexValid(int choiceIndex) => 
    
        choiceIndex >= 0;

    private void SetCurrentStep(int choiceIndex)
    {
        if (_currentStep.Choices.Length <= choiceIndex) 
            return;
        Step nextStep = _currentStep.Choices [choiceIndex];
        SetCurrentStep(nextStep);
    }

    private int GetPressedButtonIndex()
    {
        int pressButtonIndex = NumButtonHelper.GetPressButtonIndex();
        return pressButtonIndex - 1;
    }

    private void SetCurrentStep(Step step)
    {
        if (step == null)
            return;
        
        _currentStep = step;

        _image.sprite = step.NameImage;
        _headerLabel.text = step.DebugHeaderText;
        _descriptionLabel.text = step.DescriptionText;
        _choicesLabel.text = step.ChoicesText;
        _namelocationLabel.text = step.NameLocationText;
        
    }

    private void MenuButtonClicked() =>
        _sceneLoader.LoadScene(_menuSceneName);

    #endregion
}