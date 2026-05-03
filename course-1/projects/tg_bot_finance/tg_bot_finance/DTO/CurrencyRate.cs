using System;
namespace tg_bot_finance.DTO
{
    public class CurrencyRate
    {
        public string CharCode { get; set; }
        public decimal Value { get; set; }
        public int Nominal { get; set; }
    }
}

