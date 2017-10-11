<p align="center">
  <h3 align="center">ArduinoGUICS[C#]</h3>

  <p align="center">
  -Add <b>U</b>ser <b>I</b>nterface to your Arduino projects
  <br>
  -Run in realTime without images and uploads the code evrey time
  <br>
  -Multi Tasking
  <br>
  -Development in a one platform
  <br>
  -Use one language code
  <br>
  -OPEN SOURCE
</p>
</p>

<br>

## Table of contents

- [Quick start](#quick-start)
- [How to use](#how-to-use)
- [Library Arduino C++](#library-arduino-c)
- [Library GUI C#](#library-gui-c)
- [Developer](#developer)

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
`GUIsetup`: Initialize baud(default 115200) Serial port.<br>
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
class `GUICS_LIB`: create new object to use this library.<br>
Getting SerialPort part.(you dont need to use it if you dont know, it call automatic in start)<br>
exemple to use:
```
GUICS_LIB ARDUINO = new GUICS(serialCOM);

//now you can call to all functions in this class

/*
ARDUINO.DIGITAL_MODE...
ARDUINO.DIGITAL_SET...
ARDUINO.DIGITAL_GET...
...
*/
```
<br><br>
`DIGITAL_MODE`: setup digital GPIO is output or input.<br>
Getting pin number and `SET.OUTPUT` for setting pin output OR `SET.INPUT` for setting input.
<br><br>
`DIGITAL_SET`: set digital GPIO logic level HIGH or LOW.<br>
Getting pin number and `SET.HIGH` for logic pin HIGH(5v) OR `SET.LOW` for logic low(0v).
<br><br>
`DIGITAL_GET`: get digital GPIO status.<br>
Getting pin number, and return bool (TRUE or FALSE) according to the status.<br>
NOTE: the default is HIGH (pullup)
<br>
```
ARDUINO.DIGITAL_MODE(13, SET.OUTPUT); //setting GPIO 13 to OUTPUT.
ARDUINO.DIGITAL_SET(13, HIGH); //GPIO 13 out HIGH level

ARDUINO.DIGITAL_MODE(12, SET.INPUT); //setting GPIO 12 to INPUT
if(ARDUINO.DIGITAL_GET(12) == true)
{
  //some code...
}
else
{
  //some else code...
}
```
<br><br>
`ANALOG_GET`: get analog input.<br>
Getting analog pin number and return number(string) between 0 and 1023. (0 value = 0v input) and (1023 value = 5v input).
```
if(ARDUINO.ANALOG_GET(1) == "511") //if the analog input 1 = 2.5v
{
  //some code...
}

//can convert to int numer(DEC)
if(Convert.toInt16(ARDUINO.ANALOG_GET(1)) > 511) //if the analog input bigger then 2.5v
{
  //some code...
}
```
<br><br>

`GUI` class:<br>
`delay`: Mack the program sleep to milliseconds.<br>
Getting milliseconds.<br>
```
//some code...
GUI.delay(1000); //stop the program to 1 second
//some code...
```
<br><br>
`text`: change inner text for label.<br>
Getting label part and content.<br>
```
GUI.Text(label1, "HELLOW WORLD");
```

<br><br>
`color`: change background color for part.<br>
Getting part name and `Color`.<br>
```
GUI.Color(button1, Color.Red);
```

<br><br>

class `MultiTask`: create new object to multi task (run in the background).<br>
Getting one functions, run in the background (infinity).<br>
NOTE: find `//init mutiTask` in the main program.<br>
```
//init mutiTask
multiTask task = new multiTask(() => ARDUINOsetup());
...

void ARDUINOloop()
{
  ARDUINO.DIGITAL_SET...
  //some code...
}
```

## Developer
@Gal Ashkenazi(Gal14190)
