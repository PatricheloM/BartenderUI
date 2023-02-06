const redis = require('redis')

const client = redis.createClient({
    url: 'redis://:password@localhost:6379'
});

module.exports = {
    getAllTables: async function () {
        await client.connect();
        const value = await client.sMembers('asztalok');
        
        let tables = []

        for(let i of value) {
            let item = await client.hGetAll('asztal_' + i);
            const invoices = await client.sMembers('szamlak_' + i);
            item["invoices"] = invoices;
            tables.push(item);
        }
        await client.disconnect();

        return tables;
    },
    getMenu: async function () {
        await client.connect();
        const res = await client.hGetAll('menu');
        await client.disconnect();
        return res;
    },
    order: async function(item, quantity, table, invoice) {
        await client.connect();
        const request = `${item}|${quantity}|${table}|${invoice}`;
        if (await client.hExists("menu", item) && typeof quantity === 'number' && await client.exists(`asztal_${table}`)) {
            await client.publish('new_order', request);
            console.log("[" + new Date().toJSON() + "]: Validation correct for message - " + request);
            await client.disconnect();
            return true;
        } else {
            console.log("[" + new Date().toJSON() + "]: Validation wrong for message - " + request);
            await client.disconnect();
            return false;
        }
    },
    getInvoice: async function (id) {
        await client.connect();
        const res = await client.hGetAll('szamla_' + id);
        await client.disconnect();
        return res;
    },
  };
