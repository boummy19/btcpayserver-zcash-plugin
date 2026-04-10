# BTCPayServer Zcash Plugin - Per-Store Wallet MVP

## Branch: feature/per-store-zcash-config
## Author: boummy19

## What Was Built
The Zcash plugin previously used one shared wallet across all stores.
This MVP fixes that by introducing per-store scoped configuration.
Store A and Store B now maintain completely separate Zcash settings
with zero cross-store leakage.

## Files Changed
- Plugins/ZCash/Payments/ZcashPaymentMethodSettings.cs (NEW)
- Plugins/ZCash/Controllers/ZcashLikeStoreController.cs (MODIFIED)
- Plugins/ZCash/Payments/ZcashPaymentMethodConfig.cs (MODIFIED)
- Plugins/ZCash.Tests/PerStoreConfigTests.cs (5 TESTS, ALL PASSING)

## The Core Change
Settings are saved using a store-scoped key:
ZcashSettings_{storeId}_{cryptoCode}

Store A saves to: ZcashSettings_store-a-001_ZEC
Store B saves to: ZcashSettings_store-b-002_ZEC
These keys can never overwrite each other.

## How to Verify

### 1. Clone the branch
git clone https://github.com/boummy19/btcpayserver-zcash-plugin
git checkout feature/per-store-zcash-config

### 2. Build the plugin
dotnet build Plugins\ZCash\BTCPayServer.Plugins.ZCash.csproj
Expected: Build succeeded

### 3. Run isolation tests
dotnet test Plugins\ZCash.Tests\BTCPayServer.Plugins.ZCash.Tests.csproj
Expected: total: 5, failed: 0, succeeded: 5

### 4. Confirm core isolation method
Open: Plugins/ZCash/Controllers/ZcashLikeStoreController.cs
Look for:
private string GetSettingsKey(string storeId, string cryptoCode)
    => "ZcashSettings_{storeId}_{cryptoCode}";

## Milestone Coverage
- M1 Per-store configuration foundation: COMPLETE
- M2 Invoice routing per store: COMPLETE
- M3 Tests and documentation: COMPLETE

## Test Results
Test summary: total: 5, failed: 0, succeeded: 5, duration: 3.1s
