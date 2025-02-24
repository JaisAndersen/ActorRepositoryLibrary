namespace ActorRepositoryLibrary
{
    public class Actor
    {
        private string name;
        private int birthYear;

        public int Id { get; set; }
        public string Name
        {
            get => name;
            set
            {
                if (value == null)
                    throw new ArgumentNullException("Name is null");
                if (value.Length < 4)
                    throw new ArgumentOutOfRangeException("Name must be at least 4 characters");
                name = value;
            }
        }
        public int BirthYear
        {
            get => birthYear;
            set
            {
                if (value <= 1820)
                    throw new ArgumentOutOfRangeException("Year should be bigger then 1820");
                if (value > 9999)
                    throw new ArgumentOutOfRangeException("Year must not be longer then 4 charachters");
                birthYear = value;
            }    
        }
        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Birth Year: {BirthYear}";
        }
    }
}
