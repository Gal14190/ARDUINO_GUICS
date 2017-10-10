#include "GUICS.h"

void GUIloop()
{
  typedef TOKEN TOKEN;

  int i;
  
  char DATA;
  bool BOOL_DATA;
  int INT_DATA;
  
  if(GUI.available() > 0){
    delay(30);
    switch(GUI.read()){
      case TOKEN::DIGITAL_SET:
        DATA = GUI.read();
        
        if(DATA == TOKEN::SET_INPUT){
          SetP_IN((int)GUI.read());
        }
        else if(DATA == TOKEN::SET_OUTPUT){
          SetP_OUT((int)GUI.read());
        }
      break;
      
      case TOKEN::DIGITAL_INPUT:
        BOOL_DATA = PIN((int)GUI.read());
        if(BOOL_DATA){
          DATA = '1';
        }
        else if(!BOOL_DATA){
          DATA = '0';
        }
        GUI.write(DATA);
      break;
      
      case TOKEN::DIGITAL_OUTPUT:
        DATA = GUI.read();
        
        if(DATA == TOKEN::SET_HIGH){
          POUT_H((int)GUI.read());
        }
        else if(DATA == TOKEN::SET_LOW){
          POUT_L((int)GUI.read());
        }
      break;
      
      case TOKEN::ANALOG_INPUT:
        delay(100);
        INT_DATA = analogRead((int)GUI.read());
        GUI.print(INT_DATA, DEC);
        GUI.write(TOKEN::END_CHAR);
      break;
    }
  }
}

