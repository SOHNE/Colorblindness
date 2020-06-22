
# Unity Colorblind
[![Unity Version](https://img.shields.io/badge/Unity-2019.4%20LTS-green.svg?logo=unity&style=for-the-badge&colorA=000000)](https://store.unity.com/download?ref=personal)

Using the Channel Mixer component, includes eight color blindness profiles, based on this [Color Blindness Simulation][color-matrix].

Currently, it only works with the following customizable render pipeline:
  - Universal Render Pipeline (URP)
  - High Definition Render Pipeline (HDRP) 

# Features

  - Load color filter profile in runtime pressing **F1** on keyboard.
  - Saving the current filter via [_PlayerPrefs_][playerprefs].

### Todos

- [ ] Optimizations
- [ ] Polishing
- [ ] Documentation

# Implementation recommendations

- [Input System][inputsystem]
- [Addressables][addressables]

License
----

Copyright 2020 SOHNE (leandroperes@protonmail.com)

Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

-----
**Live long and prosper \V/,**

[//]: # (References)

[color-matrix]: <https://web.archive.org/web/20081014161121/http:/www.colorjack.com/labs/colormatrix/>
[playerprefs]: <https://docs.unity3d.com/ScriptReference/PlayerPrefs.html>
[inputsystem]: <https://docs.unity3d.com/Manual/com.unity.inputsystem.html>
[addressables]: <https://docs.unity3d.com/Manual/com.unity.addressables.html>
