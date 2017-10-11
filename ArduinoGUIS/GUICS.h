/**
 * --------------------------------------------------------------------------
 * ArduinoGUICS[C#]: GUICS.h
 * author: Gal Ashkenazi
 * (https://github.com/Gal14190/ARDUINO_GUICS)
 * --------------------------------------------------------------------------
 */
 
#ifndef _GUICS_H
#define _GUICS_H

#include <Arduino.h>

#define BAUD 115200

#define GUI Serial 
#define GUIsetup() GUI.begin(BAUD)
#define Available() available()
#define Read() read()
#define Write(X) write(X)

#define SetP_IN(X) pinMode(X, INPUT_PULLUP)
#define SetP_OUT(X) pinMode(X, OUTPUT)

#define PIN(X) digitalRead(X) 

#define POUT_H(X) digitalWrite(X, HIGH)
#define POUT_L(X) digitalWrite(X, LOW)

#define AnalogInput(X) analogRead(X)


struct TOKEN
{
    static const char DIGITAL_SET = 'M';
      static const char SET_INPUT = 'I';
      static const char SET_OUTPUT = 'O';
      
    static const char DIGITAL_INPUT = 'I';
    
    static const char DIGITAL_OUTPUT = 'O';
      static const char SET_HIGH = 'H';
      static const char SET_LOW = 'L';
      
    static const char ANALOG_INPUT = 'A';

    static const char END_CHAR = '@';
};

void GUIloop();
#endif
