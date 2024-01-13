using UnityEngine;

public  static class ScreenConsole
{
    private static readonly ScreenConsolePrinter _printer = new GameObject().AddComponent<ScreenConsolePrinter>();
    
    public static void Print(string text) => _printer.SetMessage(text);

    private class ScreenConsolePrinter : MonoBehaviour
    {
        private string _textToPrint = string.Empty;
        
        private readonly Rect _rect = new(5, Screen.height - 25, Screen.width, 20);
        
        public void SetMessage(string text)
        {
            CancelInvoke(nameof(ClearMessage));
            
            _textToPrint = text;
            Invoke(nameof(ClearMessage), 3);
        }

        private void ClearMessage()
        {
            _textToPrint = string.Empty;
        }
        
        private void OnGUI()
        {
            if(!string.IsNullOrEmpty(_textToPrint))
            {
                GUI.color = Color.black;
                GUI.Label(_rect, _textToPrint);
            }
        }
    }
   
}