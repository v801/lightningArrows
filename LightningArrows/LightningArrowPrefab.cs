using System.IO;
using BepIn;
using JotunnLib.Entities;
using UnityEngine;

namespace LightningArrows
{
    public class LightningArrowPrefab : PrefabConfig
    {
        public LightningArrowPrefab() : base("ArrowLightning", "ArrowSilver")
        {

        }

        public override void Register()
        {
            ItemDrop item = Prefab.GetComponent<ItemDrop>();
            item.m_itemData.m_shared.m_itemType = ItemDrop.ItemData.ItemType.Ammo;
            item.m_itemData.m_shared.m_name = "Lightning Arrow";
            item.m_itemData.m_shared.m_description = "Shockingly fast.";
            item.m_itemData.m_dropPrefab = Prefab;
            item.m_itemData.m_shared.m_weight = 0.1f;
            item.m_itemData.m_shared.m_maxStackSize = 100;
            item.m_itemData.m_shared.m_variants = 1;
            item.m_itemData.m_shared.m_damages.m_pierce = 20;
            item.m_itemData.m_shared.m_damages.m_lightning = 40;
            item.m_itemData.m_shared.m_damages.m_spirit = 0;

           var LoadedAssetBundle = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "LightningArrows", "lightningarrows"));

           if (LoadedAssetBundle == null)
           { 
                Debug.Log("Failed to load AssetBundle!");
                return;
           }

           Texture2D icon = LoadedAssetBundle.LoadAsset<Texture2D>("lightningarrow-sprite.png");
           if (icon != null)
           {
               Sprite sprite = Sprite.Create(icon, new Rect(0f, 0f, icon.width, icon.height), Vector2.zero);
               //m_icons[0] is the actual sprite itself.
               item.m_itemData.m_shared.m_icons[0] = sprite;
           }

           MeshRenderer renderer = Prefab.GetComponentInChildren<MeshRenderer>();

           LoadedAssetBundle?.Unload(false);
        }
    }
}
