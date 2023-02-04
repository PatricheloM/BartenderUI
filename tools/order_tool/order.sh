#!/bin/bash

host=$(cat connection.json | jq '.host' | tr -d '"')
port=$(cat connection.json | jq '.port')
echo -n Password: 
read -s password
authComm=$(sed "s/#PASS/$password/g" command_templates/auth.redis)
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
read item
itemExistsComm=$(sed "s/#ITEM/$item/g" command_templates/item_check.redis)
resCode=$(redis-cli -h $host -p $port -a $password --no-auth-warning $itemExistsComm)
if [[ $resCode == 0 ]]
then
	echo Item does not exist
	echo
	exit 1
fi
echo -n Quantity: 
read quantity
re='^[0-9]+$'
if ! [[ $quantity =~ $re ]]
then
   echo "Not a number"
   exit 1
fi
echo -n Table: 
read table
tableExistsComm=$(sed "s/#TABLENUM/$table/g" command_templates/tablenum_check.redis)
resCode=$(redis-cli -h $host -p $port -a $password --no-auth-warning $tableExistsComm)
if [[ $resCode == 0 ]]
then
	echo Table does not exist
	echo
	exit 1
fi
echo -n Invoice: 
read invoice
publishComm=$(sed -e "s/#ITEM/$item/g" -e "s/#TABLENUM/$table/g" -e "s/#QUANTITY/$quantity/g" -e "s/#INVOICE/$invoice/g" command_templates/publish.redis)
resCode=$(redis-cli -h $host -p $port -a $password --no-auth-warning $publishComm)
exit 0
