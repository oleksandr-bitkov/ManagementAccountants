namespace ManagementAccountants.DataAccess.Entityes.Base
{
    public abstract class Person : NamedEntity
    {
        public string Surname { get; set; } = string.Empty;
        public string Patronymic { get; set; } = string.Empty;
    }
}
