using app1.Models;

namespace app1.Reposatory
{
	public class DepartmentRepo:IDepartmentRepo
	{

		ITIContext context;
		public DepartmentRepo(ITIContext _con)
		{
			context = _con;
		}
		public void add(Department db)
		{
			context.Add(db);

		}
		public void update(Department db)
		{
			context.Update(db);
		}
		public void delete(int id)
		{
			Department db = GetById(id);
			context.Remove(db);

		}
		public List<Department> Getall()
		{
			return context.Departments.ToList();

		}
		public Department GetById(int id)
		{

			return context.Departments.FirstOrDefault(x => x.Id == id);

		}

		public void SaveChanges()
		{
			context.SaveChanges();
		}
	}
}
