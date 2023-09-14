using Services.Runtime.RemoteVariables;
using Services.Runtime.ServiceManagement;
using TMPro;
using UnityEngine;

public class RemoteVariablesDebugView : MonoBehaviour
{
    [SerializeField] private TMP_Text _intDebug;
    [SerializeField] private TMP_Text _floatDebug;
    [SerializeField] private TMP_Text _stringDebug;

   private void Start()
   {
       var remotes = ServiceLocator.GetService<RemoteVariablesService>();

       _intDebug.text = remotes.GetString("MENU_DEBUG_INT");
       _floatDebug.text = remotes.GetString("MENU_DEBUG_FLOAT");
       _stringDebug.text = remotes.GetString("MENU_DEBUG_STRING");
   }
}