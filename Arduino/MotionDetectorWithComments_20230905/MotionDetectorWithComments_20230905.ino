const int trigPin = 11;
const int echoPin = 12;
const int LEDPin = 13;
const int servoPin = 8;
int lightCount = 0;
float duration, distance;

#include <Servo.h>
// create servo object to control a servo
Servo myservo;
// variable to store the servo position
int pos = 0;

void setup(){
  //Define inputs and outputs
  pinMode(trigPin, OUTPUT);
  pinMode(echoPin, INPUT);
  pinMode(13, OUTPUT);

  // Sets pin 7 as an output for powering the servo
  pinMode(7, OUTPUT);

  // attaches the servo on pin 8 to the servo object
  myservo.attach(servoPin);

  //Serial Port begin
  Serial.begin(9600);
}

void loop(){

  // Powers the servo
  digitalWrite(7, HIGH);
  
  // The sensor is triggered by a HIGH pulse of 10 or more microseconds.
  // Give a short LOW pulse beforehand to ensure a clean HIGH pulse:
  digitalWrite(trigPin, LOW);
  delay(5);
  digitalWrite(trigPin, HIGH);
  delay(10);
  digitalWrite(trigPin, LOW);
  
  // Read the signal from the sensor: a HIGH pulse whose
  // duration is the time (in microseconds) from the sending
  // of the ping to the reception of its echo off of an object.
  pinMode(echoPin, INPUT); // Set the echoPin as an input to receive the echo signal

  // Use the pulseIn() function to measure the duration of a HIGH pulse on the echoPin
  duration = pulseIn(echoPin, HIGH);
  //HIGH is specified as the state to measure the duration for. In this context, 
  //it's waiting for the echo signal to go HIGH, 
  //which happens when the ultrasonic pulse bounces back after hitting an object.

  // Convert the time into a distance
  distance = (duration / 29.1) / 2;
  //Serial.print("Distance: ");
  
 
  delay(250);

  if(distance < 15)
  {
    // If the distance is less than 5 centimeters:
    // Light up the LED on pin 13
    digitalWrite(LEDPin, HIGH);
    // Control lightCount
  lightCount ++;
 // Show how many times the LED has been lit up
  //Serial.print("Light count: ");

  // only print when distance is less than 150cm
  Serial.print(distance);
  Serial.print(", ");
  Serial.println(lightCount);


    // Sweep the servo from 0 to 180 degrees and back
    for (pos = 0; pos <= 180; pos += 1) { // goes from 0 degrees to 180 degrees
    // in steps of 1 degree
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);                       // waits 15ms for the servo to reach the position
     //introduce a 15-millisecond delay with delay(15);
     //This delay gives the servo motor some time to physically move to the specified position before the next iteration of the loop.
     //Using this delay is important because servo motors do not instantly change their position; 
     //they require some time to move from one position to another. 
     //The specific duration of the delay may vary depending on the servo and its characteristics, 
     //but in this case, a 15-millisecond delay is used to provide adequate time for the servo to reach the desired angle.
    }
    for (pos = 180; pos >= 0; pos -= 1) { // goes from 180 degrees to 0 degrees
    myservo.write(pos);              // tell servo to go to position in variable 'pos'
    delay(15);                       // waits 15ms for the servo to reach the position
    }

    // myservo.write(0);              
    // delay(100);                       
    // myservo.write(90);  
    // delay(500);       

    // myservo.write(135);  
    // delay(100);   

    // myservo.write(180);  
    // delay(500);        

  }
  else{
    // Sweep the servo from 0 to 180 degrees and back
    digitalWrite(LEDPin, LOW);

  }
}