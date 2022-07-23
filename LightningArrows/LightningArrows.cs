using System;
using BepInEx;
using JotunnLib.Managers;
using JotunnLib.Entities;
using UnityEngine;

namespace LightningArrows
{
    [BepInPlugin("com.bepinex.plugins.lightningarrows", "LightningArrows", "0.1.1")]
    [BepInDependency("com.bepinex.plugins.jotunnlib")]
    public class LightningArrows : BaseUnityPlugin
    {
        private void Awake()
        {
            ObjectManager.Instance.ObjectRegister += registerObjects;
            PrefabManager.Instance.PrefabRegister += registerPrefabs;
        }

        private void registerPrefabs(object sender, EventArgs e)
        {
            PrefabManager.Instance.RegisterPrefab(new LightningArrowPrefab());
        }

        private void registerObjects(object sender, EventArgs e)
        {
            ObjectManager.Instance.RegisterItem("ArrowLightning");

            ObjectManager.Instance.RegisterRecipe(new RecipeConfig()
            {
                Name = "Recipe_LightningArrows",
                Item = "ArrowLightning",
                Amount = 20,
                CraftingStation = "piece_workbench",

                Requirements = new PieceRequirementConfig[]
                {
                    new PieceRequirementConfig()
                    {
                        Item = "Wood",
                        Amount = 8
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "Feathers",
                        Amount = 2
                    },
                    new PieceRequirementConfig()
                    {
                        Item = "HardAntler",
                        Amount = 1
                    },
                }
            });
        }
    }
}