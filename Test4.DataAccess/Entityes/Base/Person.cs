namespace Test4.DataAccess.Entityes.Base
{
    public abstract class Person : NamedEntity
    {
        public required string Surname { get; set; }
        public string Patronymic { get; set; } = string.Empty;
    }
}
