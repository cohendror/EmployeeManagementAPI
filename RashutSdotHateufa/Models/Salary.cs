namespace RashutSdotHateufa.Models
{
    public class Salary
    {
        public int SalaryId { get; set; }
        public int EmployeeId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }

}
