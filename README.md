# SOHNE | Colorblindness
[![Unity Version](https://img.shields.io/badge/Unity-2018.4%20LTS+-green.svg?logo=unity&style=for-the-badge&colorA=000000)](https://store.unity.com/download?ref=personal)

[![Release](https://badgen.net/github/release/SOHNE/Colorblindness)][releases]  [![TODOs](https://badgen.net/https/api.tickgit.com/badgen/github.com/SOHNE/Colorblindness)](https://www.tickgit.com/browse?repo=github.com/SOHNE/Colorblindness) ![License](https://badgen.net/github/license/SOHNE/Colorblindness) ![Contributors](https://badgen.net/github/contributors/SOHNE/Colorblindness)

![Colorblindness demonstration][colorblindness-gif]

Using the [Channel Mixer] *Override*, includes eight color blindness profiles, based on this [Color Blindness Simulation].

Currently, it only works with the following [Scriptable Render Pipeline]:
  - Universal RP (**URP**) / Lightweight RP (**LWRP**)
  - High Definition RP (**HDRP**)

---


### Todos

- [x] ~~Unity Package~~
- [ ] Optimizations
- [ ] Polishing
- [ ] Documentation
- [ ] Samples
- [ ] Support for the ***standard Unity renderer + [Post-processing stack]*** (?)

---

### Features

  - Eight different types of color blindness simulation;
  - Load color filter profile in runtime pressing **F1**(*default key*) on keyboard;
  - Saving the current filter via *[PlayerPrefs]*;
  - Automatically apply filters to volumes when migrating to a new scene.

### Filter types as resources
> :warning: ***Studies and tests with colorblind people are lacking to confirm the effectiveness of this solution.***

 1. Protanopia;
 2. Protanomaly;
 3. Deuteranopia;
 4. Deuteranomaly;
 5. Tritanopia;
 6. Tritanomaly;
 7. Achromatopsia;
 8. Achromatomaly.
 
## Installation

 - \***.unitypackage**
	 0. Import the customized package found in the [releases].
- [Unity’s Package Manager]
	1. `"com.sohne.colorblindness": "https://github.com/SOHNE/Colorblindness.git#upm"` to your project's package manifest file in dependencies section.
	2. `Package Manager > Add package from git URL...` and paste this URL: `https://github.com/SOHNE/Colorblindness.git#upm`

---

### Implementation recommendations

- [Input System]
- [Addressables]

MIT License
----

Copyright 2020 SOHNE (leandroperes@protonmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

-----
**Live long and prosper \V/,**

[//]: # (External links)

[colorblindness-gif]: <https://github.com/SOHNE/Colorblindness/blob/develop/__misc__/demo.gif?raw=true>
[Channel Mixer]: <https://docs.unity3d.com/Packages/com.unity.render-pipelines.universal@7.2/manual/Post-Processing-Channel-Mixer.html>
[Color Blindness Simulation]: <https://web.archive.org/web/20081014161121/http:/www.colorjack.com/labs/colormatrix/>
[Scriptable Render Pipeline]: <https://docs.unity3d.com/Manual/ScriptableRenderPipeline.html>
[PlayerPrefs]: <https://docs.unity3d.com/ScriptReference/PlayerPrefs.html>
[Post-processing stack]: <https://docs.unity3d.com/2018.3/Documentation/Manual/PostProcessing-Stack.html>
[releases]: <https://github.com/SOHNE/Colorblindness/releases>
[Unity’s Package Manager]: <https://docs.unity3d.com/Manual/Packages.html>
[Input System]: <https://docs.unity3d.com/Manual/com.unity.inputsystem.html>
[Addressables]: <https://docs.unity3d.com/Manual/com.unity.addressables.html>
