using Microsoft.AspNetCore.Mvc;
using WalletMvc.Models;
using WalletMvc.Services;

namespace WalletMvc.Controllers
{
    public class WalletController : Controller
    {
        private readonly WalletService _walletService;

        public WalletController(WalletService walletService)
        {
            _walletService = walletService;
        }

        // Ana sayfa
        public IActionResult Index()
        {
            return View();
        }

        // Cüzdan oluşturma
        [HttpPost]
        public IActionResult CreateWallet()
        {
            var wallet = _walletService.CreateWallet();
            return Json(wallet);
        }

        // Para transferi
        [HttpPost]
        public IActionResult Transfer([FromBody] TransferRequest request)
        {
            var result = _walletService.Transfer(request);
            if (result)
            {
                return Json("Transfer başarılı.");
            }
            return Json("Transfer başarısız.");
        }

        // Cüzdan bakiye sorgulama sayfası
        public IActionResult CheckBalance()
        {
            return View();
        }

        // Cüzdan bakiye sorgulama API endpoint'i
        [HttpPost]
        public IActionResult GetBalance([FromBody] string walletId)
        {
            var wallet = _walletService.GetWallet(walletId);
            if (wallet != null)
            {
                return Json(new { success = true, balance = wallet.Balance });
            }
            return Json(new { success = false, message = "Cüzdan bulunamadı." });
        }
    }
}