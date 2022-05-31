using System.Net.Mime;
using UnityEngine;

public class Step : MonoBehaviour
{
    #region Variables

    public string DebugHeaderText;
    
    [TextArea(4, 8)]
    public string DescriptionText;
    
    [TextArea(4, 4)]
    public string ChoicesText;

    public string NameLocationText;

    public Sprite NameImage;
    
    public Step[] Choices;

    #endregion
    
}