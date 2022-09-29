using UnityEditor;
using UnityEditor.Callbacks;

namespace Coimbra.Editor.UPM
{
    internal sealed class UPMAuthenticatorAssetPostprocessor : AssetPostprocessor
    {
        [RunAfterClass(typeof(UPMAuthenticator))]
        private static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
        {
            UPMAuthenticator.Update();
        }
    }
}
