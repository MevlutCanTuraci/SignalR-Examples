namespace SignalR.WebAPI.Model
{
    public class MyModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
    }


    public class MyResponse
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Status { get; set; }
    }


    public class LittleDataSet
    {
        private static string[] _names    = { "Mevlut", "Can", "Maria", "Anne", "Jack", "Johnny", "Su", "William", "Ben", "Jack", "Carl", "Arthur", "Dylan", "Joe" };
        private static string[] _surNames = { "Smith", "Johnson", "Jones", "Morgan", "Martin", "Perez", "Tennyson", "Carter", "Cruz", "Stewart", "Brooks", "Price", "Ross", "Rogers" };


        public static MyModel GeneratePerson()
        {
            var person = new MyModel
            {
                Id      = Random.Shared.Next(1, 1000),
                Name    = _names[Random.Shared.Next(_names.Length)],
                SurName = _surNames[Random.Shared.Next(_surNames.Length)]
            };

            return person;
        }


        public static List<MyModel> RangePerson(int min = 1, int max = 15)
        {
            return Enumerable.Range(min, max).Select(person => GeneratePerson()).ToList();
        }

    }

}