# Tutorial for alert setup
Setting up Vahti is  simpler if you don't want to use the mobile app. This tutorial assumes that you have Raspberry Pi (at 192.168.1.2) with BlueZ 5.48 (or later) installed on it and you want to get notifications as email.

1. Compile Vahti.App.Full (or use pre-built binaries)
2. Download Vahti.Server binaries: `wget https://github.com/ilpork/vahti/releases/latest/download/Vahti.Server-linux-arm.zip`
3. Extract the files: `tar -xzf Vahti.Server.zip`
4. Copy `config.template.json` as `config.json` and modify it to suit your configuation. See [Configuration](Configuration.md) for details.
4. Run the app with `./Vahti.Server`

## Example configuration 1
This example assumes that you have one RuuviTag.
```
{
  "mqttConfiguration": {
    "mqttServerEnabled": true
  },
  "dataBrokerConfiguration": {
    "dataBrokerEnabled": true,
    "mqttServerAddress": "192.168.1.2",
    "cloudPublishConfiguration": {
      "Enabled": false      
    },    
    "alertConfiguration": {  
      "enabled": true,    
      "emailNotifications": {
        "Enabled": true,
        "Sender": "John Doe <john.doe@domain.com>",
        "Recipients": [
          "John Doe <john.doe@domain.com>",
          "jane.doe@domain.com"
        ],
        "smtpServerAddress": "smtpa.mailserver.com",
        "smtpServerPort": "465",
        "smtpAuthentication": {
          "enabled": true,
          "UserName": "myusername",
          "Password": "mystrongpassword"
        }
      },
      "alerts": [        
        {
          "id": "garageTempLow",
          "description": "Garage temp is too low",
          "title": "Alert",
          "message": "Garage temp is under 15°C",
          "ruleSet": {
            "type": "AND",
            "rules": [
              {
                "location": "Garage",
                "sensorDeviceId": "ruuviGarage",
                "sensorId": "temperature",
                "operator": "IsLessThan",
                "value": "15"
              }
            ]
          }
        }
      ]
    }
  },
  "bluetoothGwConfiguration": {
    "bluetoothGwEnabled": true,
    "mqttServerAddress": "192.168.1.2",
    "scanIntervalSeconds": "60",
    "adapterName": "hci0",
    "sensorDevices": [
      {
        "id": "ruuviGarage",
        "address": "12:34:56:78:90:AB",
        "name": "RuuviTag in garage",
        "sensorDeviceTypeId": "RuuviTag",
        "location": "Garage"
      }      
    ],
    "sensorDeviceTypes": [
      {
        "id": "RuuviTag",
        "name": "RuuviTag",
        "manufacturer": "Ruuvi",
        "sensors": [
          {
            "id": "temperature",
            "name": "Temperature",
            "class": "temperature",
            "unit": "°C"
          },
          {
            "id": "humidity",
            "name": "Relative humidity",
            "class": "humidity",
            "unit": "%"
          },
          {
            "id": "pressure",
            "name": "Air pressure",
            "class": "pressure",
            "unit": "hPa"
          },
          {
            "id": "accelerationX",
            "name": "Acceleration (X)",
            "class": "accelerationX",
            "unit": "G"
          },
          {
            "id": "accelerationY",
            "name": "Acceleration (Y)",
            "class": "accelerationY",
            "unit": "G"
          },
          {
            "id": "accelerationZ",
            "name": "Acceleration (Z)",
            "class": "accelerationZ",
            "unit": "G"
          },
          {
            "id": "batteryVoltage",
            "name": "Battery voltage",
            "class": "batteryvoltage",
            "unit": "V"
          },
          {
            "id": "movementCounter",
            "name": "Movement counter",
            "class": "movementCounter",
            "unit": ""
          }
        ]
      }
    ]
  }
}
```

## Example configuration 2
If you don't have RuuviTag or other Bluetooth LE device, but some other source providing data (see [Add other data sources](AddOtherDataSources.md)), the configuration file is shorter. This example assumes that you have configured a sensor device with name `dhtGarage` to publish temperature data.

```
{
  "mqttConfiguration": {
    "mqttServerEnabled": true
  },
  "dataBrokerConfiguration": {
    "dataBrokerEnabled": true,
    "mqttServerAddress": "192.168.1.2",
    "cloudPublishConfiguration": {
      "Enabled": false      
    },    
    "alertConfiguration": {      
      "enabled": true,
      "emailNotifications": {
        "Enabled": true,
        "Sender": "John Doe <john.doe@domain.com>",
        "Recipients": [
          "John Doe <john.doe@domain.com>",
          "jane.doe@domain.com"
        ],
        "smtpServerAddress": "smtpa.mailserver.com",
        "smtpServerPort": "465",
        "smtpAuthentication": {
          "enabled": true,
          "UserName": "myusername",
          "Password": "mystrongpassword"
        }
      },
      "alerts": [        
        {
          "id": "garageTempLow",
          "description": "Garage temp is too low",
          "title": "Alert",
          "message": "Garage temp is under 15°C",
          "ruleSet": {
            "type": "AND",
            "rules": [
              {
                "location": "Garage",
                "sensorDeviceId": "dhtGarage",
                "sensorId": "temperature",
                "operator": "IsLessThan",
                "value": "15"
              }
            ]
          }
        }
      ]
    }
  }  
}
```
