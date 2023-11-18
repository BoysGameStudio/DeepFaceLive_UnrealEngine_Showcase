// Copyright Alan Liu 2022-2023. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class DeepFaceLive : ModuleRules
{
    private string ModulePath
    {
        get { return ModuleDirectory; }
    }

    private string AssetsPath
    {
        get { return Path.GetFullPath(Path.Combine(ModulePath, "../Assets/")); }
    }

    public DeepFaceLive(ReadOnlyTargetRules Target) : base(Target)
    {
        PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;

        OptimizeCode = CodeOptimization.Never;

        PublicIncludePaths.AddRange(
            new string[]
            {
                // ... add public include paths required here ...
            }
        );


        PrivateIncludePaths.AddRange(
            new string[]
            {
                // ... add other private include paths required here ...
            }
        );


        PublicDependencyModuleNames.AddRange(
            new string[]
            {
                "Core", "ONNXInference",
                // ... add other public dependencies that you statically link with here ...
            }
        );


        PrivateDependencyModuleNames.AddRange(
            new string[]
            {                
                "Projects",
                "CoreUObject",
                "Engine",
                "Slate",
                "SlateCore",  
                "OpenCV",
                "OpenCVHelper", 
                "TextureUtils",  
                "RHI",
                "RHICore",
                "RenderCore",
                "Renderer",
                // ... add private dependencies that you statically link with here ...	
            }
        );


        DynamicallyLoadedModuleNames.AddRange(
            new string[]
            {
                // ... add any modules that your module loads dynamically here ...
            }
        );

        var AIModels = Path.Combine(AssetsPath, "Models", "...");
        RuntimeDependencies.Add(Path.Combine(AIModels), StagedFileType.NonUFS);
    }
}