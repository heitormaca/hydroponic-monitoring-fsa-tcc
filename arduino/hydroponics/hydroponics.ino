#include <ArduinoJson.h>
#include <WiFi.h>
#include <HTTPClient.h>

const char* ssid = "HEITOR";
const char* password = "Familiams+2020";
const char* serverName = "http://hydroponics-api.azurewebsites.net/api/Medicao";
int httpResponseCode=0;
unsigned long lastTime = 0;
unsigned long timerDelay = 5000;

void setup() {
  Serial.begin(115200);

  WiFi.begin(ssid, password);
  Serial.println("Connecting");
  while(WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }
  Serial.println("");
  Serial.print("Connected to WiFi network with IP Address: ");
  Serial.println(WiFi.localIP());
  Serial.println("Timer set to 5 seconds (timerDelay variable), it will take 5 seconds before publishing the first reading.");
}

void loop() {
  if ((millis() - lastTime) > timerDelay) {
    do{
    if(WiFi.status()== WL_CONNECTED){
      HTTPClient http;
      http.begin(serverName);
      http.addHeader("Content-Type", "application/json");
      String valor = "";
//      const size_t capacity = JSON_OBJECT_SIZE(5);
//      DynamicJsonDocument doc(capacity);
//      doc["SensorTempBanc"] = String(float(random(0,10000))/1000, 2);
//      doc["SensorPh"] = String(float(random(0,10000))/100, 2);
//      doc["SensorTempSol"] = String(float(random(0,10000))/100, 2);
//      doc["SensorEc"] = String(float(random(0,10000))/100, 2);
//      doc["IdDispositivo"] = 1; 
      const size_t capacity = JSON_OBJECT_SIZE(7);
      DynamicJsonDocument doc(capacity);
      doc["SensorTempBanc"] = String(float(random(0,5001))/100, 2);
      doc["SensorTempSol"] = String(float(random(0,5001))/100, 2);
      doc["SensorPh"] = String(float(random(0,1401))/100, 2);
      doc["SensorEc"] = String(float(random(0,501))/100, 2);
      doc["IdDispositivo"] = 1;
      serializeJson(doc, valor);
      Serial.println(valor);
      httpResponseCode = http.POST(valor);
      Serial.print("HTTP Response code: ");
      Serial.println(httpResponseCode);
      http.end(); 
    }
     else {
      Serial.println("WiFi Disconnected");
      WiFi.begin(ssid, password);}
      delay(5000);
    } while(httpResponseCode!=200);  
      lastTime = millis();
    }  
  }
