using System;
using System.Collections.Generic;
using WalletMvc.Models;

namespace WalletMvc.Services
{
    public class WalletService
    {
        private readonly Dictionary<string, Wallet> _wallets = new Dictionary<string, Wallet>();

        public Wallet CreateWallet()
        {
            var wallet = new Wallet
            {
                Id = Guid.NewGuid().ToString(),
                Balance = 100
            };

            _wallets[wallet.Id] = wallet;
            return wallet;
        }

        public bool Transfer(TransferRequest request)
        {
            if (!_wallets.ContainsKey(request.FromWalletId) || !_wallets.ContainsKey(request.ToWalletId))
            {
                return false;
            }

            var fromWallet = _wallets[request.FromWalletId];
            var toWallet = _wallets[request.ToWalletId];

            if (fromWallet.Balance < request.Amount)
            {
                return false;
            }

            fromWallet.Balance -= request.Amount;
            toWallet.Balance += request.Amount;

            return true;
        }

        public Wallet GetWallet(string id)
        {
            return _wallets.ContainsKey(id) ? _wallets[id] : null;
        }
    }
}