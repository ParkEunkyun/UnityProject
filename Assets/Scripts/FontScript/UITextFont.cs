using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
/*
namespace Modules.Util
{
    public class UITextFont
    {
        public const string PATH_FONT_UITEXT_DONGLE = "Assets/Fonts/Dovemayo.ttf";
        public const string PATH_FONT_TEXTMESHPRO_DONGLE = "Assets/Fonts/Dovemayo SDF.asset";


       [MenuItem("CustomMenu/ChangeUITextFont(���� Scene �� UIText ��Ʈ�� DONGLE ��Ʈ�� ��ü��)")]

        public static void ChangeFontInUIText()
        {
            GameObject[] rootObj = GetSceneRootObjects();
            for (int i = 0; i < rootObj.Length; i++)
            {
                GameObject gbj = (GameObject)rootObj[i] as GameObject;
                Component[] com = gbj.transform.GetComponentsInChildren(typeof(Text), true);
                foreach (Text txt in com)
                {
                    txt.font = AssetDatabase.LoadAssetAtPath<Font>(PATH_FONT_UITEXT_DONGLE);
                }
            }
        }

       [MenuItem("CustomMenu/ChangeUITextFont(���� Scene �� TextMeshProGUI ��Ʈ�� DONGLE ��Ʈ�� ��ü��)")]

        public static void ChangeFontInTextMeshPro()
        {
            GameObject[] rootObj = GetSceneRootObjects();

            for (int i = 0; i < rootObj.Length; i++)
            {
                GameObject gbj = (GameObject)rootObj[i] as GameObject;
                Component[] com = gbj.transform.GetComponentsInChildren(typeof(TextMeshProUGUI), true);
                foreach (TextMeshProUGUI txt in com)
                {
                    txt.font = AssetDatabase.LoadAssetAtPath<TMP_FontAsset>(PATH_FONT_TEXTMESHPRO_DONGLE);
                }
            }
        }


        private static GameObject[] GetSceneRootObjects()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            return currentScene.GetRootGameObjects();
        }
    }

}
*/
