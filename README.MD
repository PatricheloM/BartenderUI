# Bartender
### This is a Windows application to help bartenders organising orders and invoices.
##### This application is purely dependent on Redis. This repository contains tools to understand its workflow. Such as a Bash script and a JavaScript SDK.

## Technologies used:
1. User Interface (*.NET Framework 4.7.2*)
   - Windows Forms for C# (*System.Windows.Forms*)
   - Component models for C# (*System.ComponentModel.Primitives*)
   - Drawing utilities for C# (*System.Drawing*)
   - Newtonsoft JSON library for C# (*Newtonsoft.Json*)
   - Excel data reader for C# (*ExcelDataReader*)
   - Excel data reader data set extension for C# (*ExcelDataReader.DataSet*)
   - A Redis client for C# (*StackExchange.Redis*)
2. Order tool (*Bash*) 
   - Mustache, a logic-less templating engine for Bash (*Mo*)
   - JSON interpreter for Bash (*jq*)
   - Redis client for Linux (*redis-cli*)
3. JavaScript SDK (*Node.js*)
   - Redis client for Node.js (*node-redis*)
   - Express.js application framework (*Express.js*)

## Main functionalities:
 - Customizable table distribution
 - Logging invoices on tables with a friendly, easy-to-understand business logic
 - Payment separation for invoices with a built in calculator to make receipts
 - Easy third party implementation

## Usage as a third party:
As I said this fullstack application's core is its user interface. It has the main code to communicate with Redis. So you can say it is the backend too. Kind of a monolith architecture. So to get the tools to fully function (or if you write your own frontend app with the js-sdk) you have to have the UI started. For example: you want to push an order to the database from a third party app. You have to publish a message on your Redis server to the ```new_orders``` channel with the following syntax: ```publish new_order {{ITEM}}|{{QUANTITY}}|{{TABLENUM}}|{{INVOICE}}```. This has to be validated in this third party app. So you have to make check if the item is indeed exists in the Redis DB, the quantity is a number and the table with that number exists. However if the answer to the above questins are yes and you published the message this does not mean you stored the order in the DB. This is where the backend functionality of the UI comes in. It will also check for only the syntax and then push the order into the system where it is visually shown that you got a new order.
