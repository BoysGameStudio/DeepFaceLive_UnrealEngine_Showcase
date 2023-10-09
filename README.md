## Introduction

[![IMAGE ALT TEXT HERE](./Docs/Preview.png)](https://www.youtube.com/watch?v=DnxTEbqjnOc)

You can swap your face from a webcam or the face in the video using trained face models in UnrealEngine.
This plugin is based on Face Swap(DFM) and implements a complete face swapping workflow in Unreal Engine using C++ and ONNXRuntime with DirectML(DX12) and Compute Shader. Therefore, it offers better performance than DeepFaceLive.

This plugin includes all the source code but does not provide face-swapping models. You can download test models from DeepFaceLive or train new models using DeepFaceLab.

https://github.com/iperov/DeepFaceLive

https://github.com/iperov/DeepFaceLab

Currently, only Windows operating system and DirectX12 are supported.
I'm in the process of ongoing refactoring and optimizing the effects.
## Getting Started
### System Requirements
Before you begin, ensure that your system meets the following requirements:
- **Operating System**: Windows 10/11
- **Processor**: Intel Core i7 or equivalent
- **Memory (RAM)**: 16 GB or more
- **Graphics**: Any graphics card that supports DirectX12.
### Download Pretrained Face Models
Choose a face from the table below that you'd like to replace, and then download the corresponding DFM model.

| Name      | Download Url |
| ----------- | ----------- |
|Albica Johns| https://github.com/iperov/DeepFaceLive/releases/download/ALBICA_JOHNS/Albica_Johns.dfm|
|Amber Song| https://github.com/iperov/DeepFaceLive/releases/download/AMBER_SONG/Amber_Song.dfm|
|Ava de Addario| https://github.com/iperov/DeepFaceLive/releases/download/AVA_DE_ADDARIO/Ava_de_Addario.dfm|
|Bryan Greynolds| https://github.com/iperov/DeepFaceLive/releases/download/BRYAN_GREYNOLDS/Bryan_Greynolds.dfm|
|David Kovalniy| https://github.com/iperov/DeepFaceLive/releases/download/DAVID_KOVALNIY/David_Kovalniy.dfm|
|Dean Wiesel| https://github.com/iperov/DeepFaceLive/releases/download/DEAN_WIESEL/Dean_Wiesel.dfm|
|Dilraba Dilmurat| https://github.com/iperov/DeepFaceLive/releases/download/DILRABA_DILMURAT/Dilraba_Dilmurat.dfm|
|Emily Winston| https://github.com/iperov/DeepFaceLive/releases/download/EMILY_WINSTON/Emily_Winston.dfm|
|Ewon Spice| https://github.com/iperov/DeepFaceLive/releases/download/EWON_SPICE/Ewon_Spice.dfm|
|Irina Arty| https://github.com/iperov/DeepFaceLive/releases/download/IRINA_ARTY/Irina_Arty.dfm|
|Jackie Chan| https://github.com/iperov/DeepFaceLive/releases/download/JACKIE_CHAN/Jackie_Chan.dfm|
|Jesse Stat 320| https://github.com/iperov/DeepFaceLive/releases/download/JESSE_STAT/Jesse_Stat_320.dfm|
|Joker| https://github.com/iperov/DeepFaceLive/releases/download/JOKER/Joker.dfm|
|Keanu Reeves| https://github.com/iperov/DeepFaceLive/releases/download/KEANU_REEVES/Keanu_Reeves.dfm|
|Keanu Reeves 320| https://github.com/iperov/DeepFaceLive/releases/download/KEANU_REEVES_320/Keanu_Reeves_320.dfm|
|Kim Jarrey| https://github.com/iperov/DeepFaceLive/releases/download/KIM_JARREY/Kim_Jarrey.dfm|
|Liu Lice| https://github.com/iperov/DeepFaceLive/releases/download/LIU_LICE/Liu_Lice.dfm|
|Matilda Bobbie| https://github.com/iperov/DeepFaceLive/releases/download/MATILDA_BOBBIE/Matilda_Bobbie.dfm|
|Meggie Merkel| https://github.com/iperov/DeepFaceLive/releases/download/MEGGIE_MERKEL/Meggie_Merkel.dfm|
|Millie Park| https://github.com/iperov/DeepFaceLive/releases/download/MILLIE_PARK/Millie_Park.dfm|
|Mr. Bean| https://github.com/iperov/DeepFaceLive/releases/download/MR_BEAN/Mr_Bean.dfm|
|Natalie Fatman| https://github.com/iperov/DeepFaceLive/releases/download/NATALIE_FATMAN/Natalie_Fatman.dfm|
|Natasha Former| https://github.com/iperov/DeepFaceLive/releases/download/NATASHA_FORMER/Natasha_Former.dfm|
|Nicola Badge| https://github.com/iperov/DeepFaceLive/releases/download/NICOLA_BADGE/Nicola_Badge.dfm|
|Rob Doe| https://github.com/iperov/DeepFaceLive/releases/download/ROB_DOE/Rob_Doe.dfm|
|Silwan Stillwone| https://github.com/iperov/DeepFaceLive/releases/download/SILWAN_STILLWONE/Silwan_Stillwone.dfm|
|Tina Shift| https://github.com/iperov/DeepFaceLive/releases/download/TINA_SHIFT/Tina_Shift.dfm|
|Tim Chrys| https://github.com/iperov/DeepFaceLive/releases/download/TIM_CHRYS/Tim_Chrys.dfm|
|Tim Norland| https://github.com/iperov/DeepFaceLive/releases/download/TIM_NORLAND/Tim_Norland.dfm|
|Yohanna Coralson| https://github.com/iperov/DeepFaceLive/releases/download/YOHANNA_CORALSON/Yohanna_Coralson.dfm|
|Zahar Lupin| https://github.com/iperov/DeepFaceLive/releases/download/ZAHAR_LUPIN/Zahar_Lupin.dfm|

### Test the Face Swap Effect Using Pre-built Package
This is a package built from the current Unreal Engine project.
DeepFaceLiveShowcase.zip
https://drive.google.com/file/d/1DPUP7bI8J10DQY9tBE6yE36EGdlY8Iva/view

### Start Face Swapping for Developer
#### Deep Face Live for Unreal Engine
https://www.unrealengine.com/marketplace/en-US/product/deep-face-live

You can purchase the source code of the Deep Face Live plugin from the link above and then place it in the Plugins directory of the current demo project.

## Troubleshooting & Technical Support
If you encounter issues while using Deep Face Live, or for technical assistance and inquiries, please contact our support team at [alan.liuhongliang@gmail.com](mailto:alan.liuhongliang@gmail.com).
