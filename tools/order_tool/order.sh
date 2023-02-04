#!/bin/bash

host=$(cat connection.json | jq '.host' | tr -d '"')
port=$(cat connection.json | jq '.port')
echo -n Password: 
read -s PASS
authComm=$(PASS=$PASS mo command_templates/auth.mustache)
resCode=$(redis-cli -h $host -p $port $authComm)
if [[ "$resCode" != "OK" ]]
then
	echo Incorrect password
	echo
	exit 1
fi
echo $resCode
echo
echo -n Item: 
read ITEM
itemExistsComm=$(ITEM=$ITEM mo command_templates/item_check.mustache)
resCode=$(redis-cli -h $host -p $port -a $PASS --no-auth-warning $itemExistsComm)
if [[ $resCode == 0 ]]
then
	echo Item does not exist
	echo
	exit 1
fi
echo -n Quantity: 
read QUANTITY
re='^[0-9]+$'
if ! [[ $QUANTITY =~ $re ]]
then
   echo "Not a number"
   exit 1
fi
echo -n Table: 
read TABLENUM
tableExistsComm=$(TABLENUM=$TABLENUM mo command_templates/tablenum_check.mustache)
resCode=$(redis-cli -h $host -p $port -a $PASS --no-auth-warning $tableExistsComm)
if [[ $resCode == 0 ]]
then
	echo Table does not exist
	echo
	exit 1
fi
echo -n Invoice: 
read INVOICE
publishComm=$(ITEM=$ITEM QUANTITY=$QUANTITY TABLENUM=$TABLENUM INVOICE=$INVOICE mo command_templates/publish.mustache)
resCode=$(redis-cli -h $host -p $port -a $PASS --no-auth-warning $publishComm)
exit 0
