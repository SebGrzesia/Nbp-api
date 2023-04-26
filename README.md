# Nbp-api
To start the server, use debbuger built-in Visual-studio-community-2022


To query operation 1, use swagger or run this command: 
curl: https://localhost:7252/api/nbp/getExchangeRate?date=2023-04-03

The result should be:
[{"rates":[{"currency":"bat (Tajlandia)","mid":0.1255},{"currency":"dolar amerykański","mid":4.3168},{"currency":"dolar australijski","mid":2.8918},{"currency":"dolar Hongkongu","mid":0.5499},{"currency":"dolar kanadyjski","mid":3.1998},{"currency":"dolar nowozelandzki","mid":2.6917},{"currency":"dolar singapurski","mid":3.2407},{"currency":"euro","mid":4.6805},{"currency":"forint (Węgry)","mid":0.012308},{"currency":"frank szwajcarski","mid":4.7033},{"currency":"funt szterling","mid":5.3236},{"currency":"hrywna (Ukraina)","mid":0.1258},{"currency":"jen (Japonia)","mid":0.032345},{"currency":"korona czeska","mid":0.1994},{"currency":"korona duńska","mid":0.6283},{"currency":"korona islandzka","mid":0.031434},{"currency":"korona norweska","mid":0.4142},{"currency":"korona szwedzka","mid":0.4156},{"currency":"lej rumuński","mid":0.9472},{"currency":"lew (Bułgaria)","mid":2.3931},{"currency":"lira turecka","mid":0.2248},{"currency":"nowy izraelski szekel","mid":1.1997},{"currency":"peso chilijskie","mid":0.00543},{"currency":"peso filipińskie","mid":0.0789},{"currency":"peso meksykańskie","mid":0.2400},{"currency":"rand (Republika Południowej Afryki)","mid":0.2410},{"currency":"real (Brazylia)","mid":0.8525},{"currency":"ringgit (Malezja)","mid":0.9763},{"currency":"rupia indonezyjska","mid":0.00028835},{"currency":"rupia indyjska","mid":0.052416},{"currency":"won południowokoreański","mid":0.00328},{"currency":"yuan renminbi (Chiny)","mid":0.6266},{"currency":"SDR (MFW)","mid":5.7897}]}]


To query operation 2, use swagger or run this command:
curl: https://localhost:7252/api/nbp/minmax?currencyCode=GBP&daysBack=5
The result should be:
{"maxValue":5.2296,"minValue":5.1861}


To query operation 3, use swagger or run this command: 
curl: https://localhost:7252/api/nbp/bid?currencyCode=GBP&daysBack=100

The result should be:
0.1096
