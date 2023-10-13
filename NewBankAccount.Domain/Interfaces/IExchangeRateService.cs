namespace NewBankAccount.Domain.Interfaces
{
    public  interface IExchangeRateService
    {
        /// <summary>
        /// API Service - Get The Exchange Values  (Live) !!!
        /// </summary>
        /// <param name="TargetCountry"></param>
        /// <returns></returns>
        double GetExchangeRate(string TargetCountry);
    }
}
