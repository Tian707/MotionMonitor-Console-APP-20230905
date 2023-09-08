const int trigPin = 11;
const int echoPin = 12;
const int LEDPin = 13;
const int servoPin = 8;
int lightCount = 0;
float duration, distance;

#include <Servo.h>
Servo myservo;
int pos = 0;

void setup(){
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(13, OUTPUT);
  pinMode(7, OUTPUT);
  myservo.attach(servoPin);
  Serial.begin(9600);
}

void loop(){
  digitalWrite(7, HIGH);
  digitalWrite(trigPin, LOW);
  delay(5);
  digitalWrite(trigPin, HIGH);
  delay(10);
  digitalWrite(trigPin, LOW);

  pinMode(echoPin, INPUT); 

  duration = pulseIn(echoPin, HIGH);
  distance = (duration / 29.1) / 2;
  delay(250);

  if(distance < 5){
    digitalWrite(LEDPin, HIGH);
    lightCount ++;

    Serial.println(distance);
    Serial.println(lightCount);

    for (pos = 0; pos <= 180; pos += 1) { 
      myservo.write(pos);              
      delay(15);                      
    }

    for (pos = 180; pos >= 0; pos -= 1) { 
      myservo.write(pos);              
      delay(15);  
      }
  }
  
  else{
    // Sweep the servo from 0 to 180 degrees and back
    digitalWrite(LEDPin, LOW);
  }
}