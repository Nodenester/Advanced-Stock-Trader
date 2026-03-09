# Advanced Stock Trader

> **Archived** — This project is no longer maintained. It was built in November 2021 as a learning project.

An automated stock trading bot built with ASP.NET 5 (Blazor Server) and the Alpaca Markets API. The bot analyzes historical price data to identify trading frequencies, calculates optimal buy prices using high/low pattern detection, and executes trades automatically via Alpaca's paper trading environment.

## How It Works

1. **Stock Analysis** — Fetches historical bar data from Alpaca Markets and identifies high/low price cycles at various frequencies
2. **Frequency Selection** — Tests multiple time frequencies to find the most profitable pattern (profit-to-stability ratio)
3. **Order Creation** — Calculates predicted next low price using recent trend direction and places buy orders when the risk/reward ratio exceeds the configured threshold
4. **Order Execution** — Monitors pending orders, checks current price and short-term direction (3-minute momentum), and executes market orders when conditions are met
5. **Position Sizing** — Allocates buying power across active orders weighted by risk score
6. **Price Updates** — Continuously updates tracked stock prices from live market data

## Tech Stack

- **Framework**: ASP.NET 5.0 / Blazor Server
- **Trading API**: [Alpaca Markets](https://alpaca.markets/) (paper trading)
- **Database**: SQL Server via Dapper ORM
- **Language**: C# 9

## Configuration

The bot reads settings (API keys, risk tolerance, buy percentage, analysis window) from a SQL Server database. Update `appsettings.json` with your connection string, then populate the `Settings` table with your Alpaca API credentials.

## Project Structure

```
Trader/
  Api/              — Alpaca API wrappers (market data, account, transactions)
  Data/             — Data models (Stock, Order, Settings, Frequency)
  DataBase/         — SQL Server access via Dapper (DB, GetDB, SetDB)
  MainFuncs/
    MakeOrder.cs          — Order creation logic
    ExacuteOrder.cs       — Order execution logic
    UpdateStockPrice.cs   — Live price updater
    MakeOrderMath/        — Analysis: high/low detection, frequency scoring, buy price prediction, trend direction
    ExacuteOrderMath/     — Execution: current price/direction/volume checks, position sizing
```

## Timeline

- **Created**: November 4, 2021
- **Last modified**: November 30, 2021

## License

MIT
