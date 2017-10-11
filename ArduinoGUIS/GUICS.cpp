/**
 * --------------------------------------------------------------------------
 * ArduinoGUICS[C#]: GUICS.cpp
 * author: Gal Ashkenazi
 * (https://github.com/Gal14190/ARDUINO_GUICS)
 * --------------------------------------------------------------------------
 */

#include "GUICS.h"

void GUIloop()
{
  typedef TOKEN TOKEN;

  int i;
  
  char DATA;
  bool BOOL_DATA;
  int INT_DATA;
  
  if(GUI.Available() > 0){
    delay(30);
    switch(GUI.Read()){
      case TOKEN::DIGITAL_SET:
        DATA = GUI.Read();
        
        if(DATA == TOKEN::SET_INPUT){
          SetP_IN((int)GUI.Read());
        }
        else if(DATA == TOKEN::SET_OUTPUT){
          SetP_OUT((int)GUI.Read());
        }
      break;
      
      case TOKEN::DIGITAL_INPUT:
        BOOL_DATA = PIN((int)GUI.Read());
        if(BOOL_DATA){
          DATA = '1';
        }
        else if(!BOOL_DATA){
          DATA = '0';
        }
        GUI.Write(DATA);
      break;
      
      case TOKEN::DIGITAL_OUTPUT:
        DATA = GUI.Read();
        
        if(DATA == TOKEN::SET_HIGH){
          POUT_H((int)GUI.Read());
        }
        else if(DATA == TOKEN::SET_LOW){
          POUT_L((int)GUI.Read());
        }
      break;
      
      case TOKEN::ANALOG_INPUT:
        delay(100);
        INT_DATA = AnalogInput((int)GUI.Read());
        GUI.print(INT_DATA, DEC);
        GUI.Write(TOKEN::END_CHAR);
      break;
    }
  }
}
