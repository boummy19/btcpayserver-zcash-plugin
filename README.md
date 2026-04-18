# BTCPay Server – ZCash Plugin (Per-Store Configuration)

This is a fork of the original [btcpay-zcash plugin](https://github.com/btcpay-zcash/btcpayserver-zcash-plugin), extended to support **per-store ZCash wallet configuration** in BTCPay Server multistore setups.

---

## The Problem

The original ZCash plugin works well for single-store BTCPay instances. But if you run multiple stores on one BTCPay Server instance, every store shares the same ZCash wallet. That means:

- You cannot tell which store received a ZCash payment
- Different store owners cannot use their own ZCash wallets
- There is no isolation between stores for ZCash payments

This is a real limitation for anyone hosting BTCPay Server for multiple merchants or running multiple independent stores on one server.

---

## What This Fork Does

This branch (`feature/per-store-zcash-config`) adds the ability to configure a separate ZCash viewing key and wallet per store, rather than using one shared wallet for the entire BTCPay instance.

Each store owner can:
- Enter their own ZCash unified full viewing key (UFVK)
- Set their own wallet birthday height
- Receive ZCash payments directly to their own wallet
- Operate independently from other stores on the same instance

---

## How It Works

Instead of one global wallet configuration, the plugin reads wallet settings at the store level. Each store provides its own viewing key through the BTCPay Store Settings → ZCash page.

The underlying `zcash-walletd` daemon handles payment detection using the provided viewing key, connecting to a public lightwalletd node (`zec.rocks`) — no full ZCash node required.

---

## Getting Started

### Requirements

- A running BTCPay Server instance (v2.3+)
- Ubuntu 22.04 or later
- Docker and Docker Compose
- At least 50GB free disk space
- A ZCash unified full viewing key (UFVK) from any compatible wallet (YWallet, Zingo, etc.)

### Installation

Follow the standard BTCPay Docker setup with ZCash enabled:

```sh
export BTCPAYGEN_CRYPTO1="btc"
export BTCPAYGEN_CRYPTO2="zec"
export BTCPAYGEN_EXCLUDE_FRAGMENTS=""
. ./btcpay-setup.sh -i
```

Then go to your store in BTCPay Server:

**Store → ZCash → Modify**

Enter your:
- **Wallet Viewing Key** (starts with `uview1...`)
- **Birth Height** (the ZCash block height when your wallet was created)
- Enable the wallet and save

### Getting Your Viewing Key

You can export a UFVK from:
- **YWallet** (Android/iOS) → Menu → More → Accounts → Export UFVK
- **Zingo** (Android) → Settings → Export Keys

---

## Configuration Reference

| Field | Description |
|---|---|
| Wallet Viewing Key | Your ZCash unified full viewing key (UFVK) starting with `uview1...` |
| Birth Height | The ZCash block height when your wallet was created |
| Enabled | Toggle to activate ZCash payments for this store |
| Confirmation Speed | How many confirmations before an invoice is marked settled |

---

## Grant Proposal

This project is being developed as part of a grant proposal to the ZCash community.

**Goal:** Fix a known limitation in the BTCPay ZCash plugin that prevents proper multistore usage, and deliver a working, documented, and maintainable solution that can be merged upstream.

**Deliverables:**
- Per-store ZCash wallet configuration (this branch)
- Documentation for installation and store setup
- Tested and working on a live BTCPay multistore instance
- Pull request submitted to the upstream repository

**Why this matters:** BTCPay Server is one of the most widely used self-hosted payment processors. Making ZCash work properly in multistore setups removes a real barrier for merchants who want to accept ZEC privately without running a dedicated server per store.

---

## Status

- [x] Fork created from upstream btcpay-zcash plugin
- [x] Per-store viewing key configuration working
- [x] Tested on live BTCPay multistore instance
- [x] ZCash invoices generating with correct shielded addresses
- [ ] Unit tests
- [ ] Pull request to upstream

---

## License

[MIT](LICENSE.md)
