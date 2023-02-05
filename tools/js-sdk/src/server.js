const express = require('express')
const repository = require('./lib/redisRepository')
const bodyParser = require("body-parser");
const app = express()
const PORT = 3000

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

app.get('/api/tables', async (req, res) => {
    console.log("[" + new Date().toJSON() + "]: Requested tables at /api/tables");
    res.status(200).json(await repository.getAllTables())
});

app.get('/api/menu', async (req, res) => {
    console.log("[" + new Date().toJSON() + "]: Requested menu at /api/menu");
    res.status(200).json(await repository.getMenu())
});

app.post('/api/order', async (req, res) => {
    console.log("[" + new Date().toJSON() + "]: Posted order at /api/order");
    if (await repository.order(req.body.item, req.body.quantity, req.body.table, req.body.invoice)) {
        res.status(201).send();
    } else {
        res.status(400).send();
    }
});

app.get('/api/invoice/:id', async function(req, res) {
    const id = req.params.id;
    console.log("[" + new Date().toJSON() + "]: Requested invoice for " + id + " at /api/invoice/" + id);
    res.status(200).json(await repository.getInvoice(id));
});

app.listen(PORT, () => {
  console.log(`Bartender RestfulAPI listening on port ${PORT}`)
})
