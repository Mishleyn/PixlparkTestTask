using EmailSendingServer;

partial class Program
{
    static void Main(string[] args)
    {
        var context = new Context();
        var lastId = context.Users.OrderByDescending(u => u.Id).FirstOrDefault()?.Id ?? 0;

        while (true)
        {
            using (var transaction = context.Database.BeginTransaction())
            {
                try
                {
                    var newUsers = context.Users.Where(u => u.Id > lastId).ToList();

                    if (newUsers.Any())
                    {
                        foreach(var user in newUsers)
                        {
                            Console.WriteLine($"New user: Id: {user.Id} Email: {user.Email} " +
                                $"Confirmation Code: {user.ConfirmationCode}");
                        }

                        lastId = newUsers.Last().Id;
                    }

                    transaction.Commit();
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Errors: {ex.Message}");
                    transaction.Rollback();
                }
            }
            Task.Delay(5000).Wait();
        }
    }
}
