const int Sala_1=13;
const int Sala_2=12;

void setup()
{
  Serial.begin(9600);
  pinMode(Sala_1, OUTPUT);
  pinMode(Sala_2, OUTPUT);
}

void loop()
{
  if(Serial.available() > 0)
  {
    int abrir = Serial.read();
    if(abrir == '1')
    {
      digitalWrite(Sala_1, HIGH);
      delay(1000);
      digitalWrite(Sala_1, LOW);
    }
    if(abrir == '2')
    {
      digitalWrite(Sala_2, HIGH);
      delay(1000);
      digitalWrite(Sala_2, LOW);
    }
  }
}
