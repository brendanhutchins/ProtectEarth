//From bildr article: https://bildr.org/2012/08/rotary-encoder-arduino/

//these pins can not be changed 2/3 are special pins
int encoderPin1 = 2;
int encoderPin2 = 3;
int encoderSwitchPin = 4; //push button switch

volatile int lastEncoded = 0;   //the value can be changed by something beyond the control of the code section which it appears
volatile long encoderValue = 0;

long lastencoderValue = 0;  //extended size variable

int lastMSB = 0;
int lastLSB = 0;

//int inByte; // for incoming serial data

void setup() {
  Serial.begin (9600);

  pinMode(encoderPin1, INPUT);
  pinMode(encoderPin2, INPUT);
  pinMode(encoderSwitchPin, INPUT);

  digitalWrite(encoderPin1, HIGH); //turn pullup resistor on
  digitalWrite(encoderPin2, HIGH); //turn pullup resistor on
  digitalWrite(encoderSwitchPin, HIGH); //turn pullup resistor on

  //call updateEncoder() when any high/low changed seen
  //on interrupt 0 (pin 2), or interrupt 1 (pin 3)
  attachInterrupt(0, updateEncoder, CHANGE);
  attachInterrupt(1, updateEncoder, CHANGE);

}

void loop(){
  if(digitalRead(encoderSwitchPin)){
    //button is not being pushed
  }
  else{
    //button is being pushed
    encoderValue = 0;
  }
    Serial.println(encoderValue);
    delay(2);
  //if(Serial.available() > 0){
    //get incoming byte
    //inByte = Serial.read();
    //if ((57-inByte)==0){
      //after starting the game
      
    //}
    //else
    //  encoderValue = 0;
  //}
}

void updateEncoder(){
  int MSB = digitalRead(encoderPin1); //MSB = most significant bit
  int LSB = digitalRead(encoderPin2); //LSB = least significant bit

  int encoded = (MSB << 1) |LSB; //converting the 2 pin value to single number 
  int sum = (lastEncoded << 2) | encoded; //adding it to the previous encoded value 
  //          13              4                 2               11
  if(sum == 0b1101 || sum == 0b0100 || sum == 0b0010 || sum == 0b1011) encoderValue ++; //clockwise mvmt
  //          14              7                 1               8
  if(sum == 0b1110 || sum == 0b0111 || sum == 0b0001 || sum == 0b1000) encoderValue --; //counter-clockwise mvmt
  lastEncoded = encoded; //store this value for next time 
}
