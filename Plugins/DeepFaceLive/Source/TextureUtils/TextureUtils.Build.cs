// Copyright Alan Liu 2022-2023. All Rights Reserved.

using UnrealBuildTool;

public class TextureUtils : ModuleRules
{
	public TextureUtils(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		bUsePrecompiled = true;
		OptimizeCode = CodeOptimization.Never;
        bEnableUndefinedIdentifierWarnings = false;
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
                "Core",
                "OpenCV",
                "OpenCVHelper", 
				// ... add other public dependencies that you statically link with here ...
			}
		);


		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				"RHI",
				"RenderCore",
				"Renderer",
				"Projects",
				"D3D11RHI",
				// ... add private dependencies that you statically link with here ...	
			}
		);


		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
		);

		PublicAdditionalLibraries.AddRange(new string[] {"d3dcompiler.lib", "dxguid.lib"});
	}
}