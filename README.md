<p align="center">
  <h3 align="center">ArduinoGUICS[C#]</h3>

  <p align="center">
  -Add <b>U</b>ser <b>I</b>nterface to your Arduino projects
  <br>
  -Development in a one platform
  <br>
  -Use one language code
  <br>
  -Run in realTime without images and uploads the code evrey time
  <br>
  -OPEN SOURCE
</p>
</p>

<br>

## Table of contents

- [Quick start](#quick-start)
- [How to use](#how-to-use)
- [Library Arduino C++](#library-arduino-c++)

## Quick start

Download the latest release:

- [arduino IDE projects](https://github.com/Gal14190/ARDUINO_GUICS/archive/Arduino.zip) or: `git clone https://github.com/Gal14190/ARDUINO_GUICS.git`
- [Visual studio C# project](https://github.com/Gal14190/ARDUINO_GUICS/archive/Visual-Studio-C%23.zip) or: `git clone https://github.com/Gal14190/ARDUINO_GUICS.git`

- You can download all the project and exchange them to another platform.

## How to use
`Arduion C++` <br>
All you need to do is download and open the arduino project in "Arduino IDE", connect the device and upload the code without change the code.
<br><br>

`GUI C#` <br>
After debuging and uploading the Arduino code, download and open the VS project in "Microsoft Visual Studio".
<br>
Open the main.cs design and add some buttons and layers.<br>
Open the c# code by double click on the form (design) background and wite some code.<br>
you can drag the code to another platforms (ex. Console).

<br><br>
- It is OPEN SOURCE, all the project is open with the source code inside. You can try to change the code, fix bugs and add some stuff. If your's code improves the project please upload it and make it more useful.  

## Library Arduino C++
`GUIsetup`: Initialize baud(defult 115200) Serial port.<br>
Call it in `setup()` function:<br>
```
void setup()
{
  GUIsetup();
}
```
<br><br>
`GUIloop`: Run the prosses.<br>
Call it in `loop()` function:<br>
```
void loop()
{
  GUIloop();
}
```
<br><br>
## Library GUI C#
