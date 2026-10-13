# Telecom Subscription Manager

A desktop app for a phone and internet company. It keeps a list of clients, their plans and extra options, and works out each client's monthly bill.

Made in C# with Windows Forms (.NET 8), as my project for the *Windows Application Programming* course at the Bucharest University of Economic Studies (ASE).

> The course was in Romanian, so class names and screen text are in Romanian. Comments are in English. See the word list at the end.

## What it does

- Add, view and delete clients. The "add client" form checks the data before saving it.
- Work out the monthly bill: plan price + extra options + extra costs.
- Add the "Internet 5G" option to a client with one click.
- Keyboard shortcuts: `Ctrl+N` adds a client, `Ctrl+G` opens the chart.
- Save and load the client list as a text file or as an XML file.
- Drag a client onto the VIP panel to make them a VIP client.
- Show a bar chart of all client bills. I drew the chart myself, and it can be printed.

## Programming concepts used

| Concept | Where |
| --- | --- |
| Abstract class | `ServiciuTelecomunicatii`, used by `TipAbonament` |
| Interface | `ICalculabil`, used by `Clienti` to work out the bill |
| `ICloneable` and `IComparable` | `ExtraOptiuni` (sorted by price) and `Clienti` (sorted by ID) |
| Operator overloading | `>` and `<` compare options by price; `plan + option` adds an option to a plan |
| Indexer | `plan[i]` gives the option at position `i` |
| Own collection | `ColectieOptiuni` works with `foreach` |
| Delegate and event | the main window changes color when a client is added |

## Files

```
TelecomSubscriptionManager.sln
TelecomSubscriptionManager/
├── ModelAbonati.cs   # the data classes: plans, options, clients
├── Form1.cs          # main window: client list, menus, save/load, drag and drop
├── FormAdaugare.cs   # "add client" form
├── FormGrafic.cs     # bar chart and printing
└── Program.cs        # starts the app
```

## How to run it

You need Windows and the .NET 8 SDK. Open `TelecomSubscriptionManager.sln` in Visual Studio 2022 and press F5. Or run:

```
dotnet run --project TelecomSubscriptionManager
```

## Word list

| Romanian | English |
| --- | --- |
| Abonat / Client | Client |
| Abonament | Plan |
| Optiuni extra | Extra options |
| Pret | Price |
| Cost suplimentar | Extra cost |
| Factura | Bill |
| Adaugare | Add |
| Grafic | Chart |

