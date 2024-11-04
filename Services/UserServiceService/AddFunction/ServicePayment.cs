public static class FuncUserService
{
    public static string CheckPaymentDue(this UserService user, DateTime lastPayMentDate)
    {
        if (DateTime.Now >= lastPayMentDate.AddMonths(1))
        {
            return $"Необходимо произвести оплату за следующий месяц.";
        }
        return $"Оплата не требуется в данный момент.";
    }
}