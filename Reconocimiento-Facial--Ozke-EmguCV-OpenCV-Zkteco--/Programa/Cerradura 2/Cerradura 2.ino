const int Cerradura_1 = 13;
const int Cerradura_2 = 12;
const int Led_Sala_1 = 11;
const int Led_Sala_2 = 10;
const int Sala_1 = 9;
const int Sala_2 = 8;
const int Rostro = 7;
const int Huella = 6;
const int Pin = 5;

void setup()
{
  Serial.begin(9600);
  pinMode(Cerradura_1, OUTPUT);
  pinMode(Cerradura_2, OUTPUT);
  pinMode(Led_Sala_1, OUTPUT);
  pinMode(Led_Sala_2, OUTPUT);
  pinMode(Rostro, OUTPUT);
  pinMode(Huella, OUTPUT);
  pinMode(Sala_1, INPUT);
  pinMode(Sala_2, INPUT);
  pinMode(Pin, OUTPUT);
  digitalWrite(Led_Sala_1, LOW);
  digitalWrite(Led_Sala_2, LOW);
}

void loop()
{
  if (Serial.available() > 0)
  {
    int abrir = Serial.read();
    if (abrir == '1')
    {
      digitalWrite(Cerradura_1, HIGH);
      delay(3000);
      digitalWrite(Cerradura_1, LOW);
    }
    if (abrir == '2')
    {
      digitalWrite(Cerradura_2, HIGH);
      delay(3000);
      digitalWrite(Cerradura_2, LOW);
    }
    if (abrir == 'R')
    {
      digitalWrite(Rostro, HIGH);
      delay(2000);
    }
    if (abrir == 'T')
    {
      digitalWrite(Rostro, LOW);
      delay(2000);
    }
    if (abrir == 'H')
    {
      digitalWrite(Huella, HIGH);
      delay(2000);
    }
    if (abrir == 'J')
    {
      digitalWrite(Huella, LOW);
      delay(2000);
    }
    if (abrir == 'P')
    {
      digitalWrite(Pin, HIGH);
      delay(2000);
    }
    if (abrir == 'O')
    {
      digitalWrite(Pin, LOW);
      delay(2000);
    }
    if (abrir == 'X')
    {
      digitalWrite(Led_Sala_1, LOW);
      digitalWrite(Led_Sala_2, LOW);
      digitalWrite(Rostro, LOW);
      digitalWrite(Huella, LOW);
      digitalWrite(Pin, LOW);
      delay(2000);
    }
  }
  if (digitalRead(Sala_1) == HIGH)
  {
    digitalWrite(Led_Sala_1, HIGH);
    digitalWrite(Led_Sala_2, LOW);
    Serial.println("Sala De Redes 1");
    delay(1000);
  }
  if (digitalRead(Sala_2) == HIGH)
  {
    digitalWrite(Led_Sala_2, HIGH);
    digitalWrite(Led_Sala_1, LOW);
    Serial.println("Sala De Redes 2");
    delay(1000);
  }
}
