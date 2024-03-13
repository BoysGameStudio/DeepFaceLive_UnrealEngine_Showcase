// Copyright Alan Liu 2022-2023. All Rights Reserved.

using System.IO;
using UnrealBuildTool;

public class ONNXInference : ModuleRules
{
	private string ModulePath
	{
		get { return ModuleDirectory; }
	}

	private string ThirdPartyPath
	{
		get { return Path.GetFullPath(Path.Combine(ModulePath, "../ThirdParty/")); }
	}

	public ONNXInference(ReadOnlyTargetRules Target) : base(Target)
	{
		OptimizeCode = CodeOptimization.Never;
        bEnableUndefinedIdentifierWarnings = false;

        bool doUseCuda = false;
		bool doUseTensorRT = false;
		bool doUseDirectML = true;
		bool doUseNNAPI = false;
		bool isFreeTrial = false;
		bUsePrecompiled = true;
		if (isFreeTrial)
		{
			PublicDefinitions.Add("FREE_TRIAL");
		}
		else
		{
			if (doUseCuda) PublicDefinitions.Add("USE_CUDA");
			if (doUseTensorRT) PublicDefinitions.Add("USE_TensorRT");
			if (doUseDirectML) PublicDefinitions.Add("USE_DirectML");
			if (doUseNNAPI) PublicDefinitions.Add("USE_NNAPI");
		}

		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		bEnableExceptions = true;

		var EngineDir = Path.GetFullPath(Target.RelativeEnginePath);

		PrivateIncludePaths.AddRange(
			new string[]
			{
				//required for FPostProcessMaterialInputs
				Path.Combine(EngineDir, "Source/Runtime/Renderer/Private")
			});

        PublicIncludePathModuleNames.AddRange(
            new string[]
            {
                "PlatformCrypto"
            }
        );

        PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core", "D3D12RHI", "PlatformCrypto","PlatformCryptoOpenSSL"
				// ... add other public dependencies that you statically link with here ...
			}
		);


		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Projects",
				"RHI",        
				"RenderCore",
				"Renderer", 

                // ... add private dependencies that you statically link with here ...	
			}
        );

		if (Target.Version.MajorVersion == 5)
			PrivateDependencyModuleNames.AddRange(
				new[]
				{
					"RHICore"
				}
			);

		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
		);

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			PrivateDependencyModuleNames.AddRange(new string[]
			{
				"D3D12RHI",
			});

			PrivateIncludePaths.AddRange(new string[]
			{
				Path.Combine(Path.GetFullPath(Target.RelativeEnginePath), "Source/Runtime/D3D12RHI/Private"),
				Path.Combine(Path.GetFullPath(Target.RelativeEnginePath), "Source/Runtime/D3D12RHI/Public"),
				Path.Combine(Path.GetFullPath(Target.RelativeEnginePath), "Source/Runtime/D3D12RHI/Private/Windows"),
			});

			AddEngineThirdPartyPrivateStaticDependencies(Target, "DX12");
		}

		if (Target.Platform == UnrealTargetPlatform.Win64)
		{
			string onnxruntimeDirWin = "onnxruntime";
			PublicDefinitions.Add("ONNX_RUNTIME_DIR_WIN=\"" + onnxruntimeDirWin + "\"");

			// required for delayed loading of dll
			PublicDefinitions.Add("ORT_API_MANUAL_INIT");

			// include
			PublicIncludePaths.AddRange(
				new string[]
				{
					// ... add public include paths required here ...
					Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "include"),
				}
			);

			// lib
			PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "lib", "onnxruntime.lib"));
			if (doUseCuda)
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "lib",
					"onnxruntime_providers_cuda.lib"));
			if (doUseTensorRT)
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "lib",
					"onnxruntime_providers_tensorrt.lib"));

			// dll 
			{
				PublicDelayLoadDLLs.Add("onnxruntime.dll");
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "bin", "onnxruntime.dll"));
			}
			if (doUseCuda)
			{
				//PublicDelayLoadDLLs.Add("onnxruntime_providers_cuda.dll");
				RuntimeDependencies.Add( /*"$(ProjectDir)/Binaries/Win64/onnxruntime_providers_cuda.dll",*/
					Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "bin", "onnxruntime_providers_cuda.dll"));
			}

			if (doUseTensorRT)
			{
				//PublicDelayLoadDLLs.Add("onnxruntime_providers_tensorrt.dll");
				RuntimeDependencies.Add( /*"$(ProjectDir)/Binaries/Win64/onnxruntime_providers_tensorrt.dll",*/
					Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "bin", "onnxruntime_providers_tensorrt.dll"));
			}

			if (doUseDirectML)
			{
				PublicDelayLoadDLLs.Add("DirectML.dll");
				RuntimeDependencies.Add( /*"$(ProjectDir)/Binaries/Win64/DirectML.dll",*/
					Path.Combine(ThirdPartyPath, onnxruntimeDirWin, "bin", "DirectML.dll"));
			}
		}
		else if (Target.Platform == UnrealTargetPlatform.Android)
		{
			// include
			PublicIncludePaths.Add(Path.Combine(ThirdPartyPath, "onnxruntime-mobile-1.8.1", "headers"));

			// lib
			PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, "onnxruntime-mobile-1.8.1", "jni", "arm64-v8a",
				"libonnxruntime.so"));
			PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, "onnxruntime-mobile-1.8.1", "jni", "armeabi-v7a",
				"libonnxruntime.so"));
			PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, "onnxruntime-mobile-1.8.1", "jni", "x86",
				"libonnxruntime.so"));
			PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, "onnxruntime-mobile-1.8.1", "jni", "x86_64",
				"libonnxruntime.so"));

			// models
			RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, "Models", "Dummy_1_256_256_3xByte_op12.all.ort"));

			// copy .so files to apk lib directory
			string PluginPath = Utils.MakePathRelativeTo(ModuleDirectory, Target.RelativeEnginePath);
			AdditionalPropertiesForReceipt.Add("AndroidPlugin", Path.Combine(PluginPath, "OnnxRuntime_APL.xml"));
		}
		else if (Target.Platform == UnrealTargetPlatform.Linux)
		{
			string onnxruntimeDirLinux = "onnxruntime-linux-1.11.0";

			// lib a
			if (doUseTensorRT)
			{
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libnvonnxparser_static.a"));
			}

			// include
			PublicIncludePaths.AddRange(
				new string[]
				{
					// ... add public include paths required here ...
					Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "include"),
					Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "include", "onnxruntime"),
					Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "include", "onnxruntime", "core"),
					Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "include", "onnxruntime", "core", "session"),
				}
			);

			// lib so
			{
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib", "libonnxruntime.so"));
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime.so"));
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime.so.1.11.0"));
				// PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib", "libonnxruntime.so.1.11.0"));
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime_providers_shared.so"));
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime_providers_shared.so"));
			}
			if (doUseCuda || doUseTensorRT)
			{
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime_providers_cuda.so"));
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime_providers_cuda.so"));
			}

			if (doUseTensorRT)
			{
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime_providers_tensorrt.so"));
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libonnxruntime_providers_tensorrt.so"));
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib", "libnvonnxparser.so"));
				PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libnvonnxparser.so"));
				RuntimeDependencies.Add(
					Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib", "libnvonnxparser.so.8"));
				// PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib", "libnvonnxparser.so.8"));
				RuntimeDependencies.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib",
					"libnvonnxparser.so.8.2.1"));
				// PublicAdditionalLibraries.Add(Path.Combine(ThirdPartyPath, onnxruntimeDirLinux, "lib", "libnvonnxparser.so.8.2.1"));
			}
		}

		PublicDefinitions.Add("WITH_NVAPI=0");
		PublicDefinitions.Add("NV_AFTERMATH=0");
		PublicDefinitions.Add("INTEL_EXTENSIONS=0");

        AddEngineThirdPartyPrivateStaticDependencies(Target, "OpenSSL");
    }
}