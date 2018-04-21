namespace FKTeplice.Data.Seeders 
{
    public interface ISeeder 
    {
        void Run(ApplicationDbContext _context);
    }
}