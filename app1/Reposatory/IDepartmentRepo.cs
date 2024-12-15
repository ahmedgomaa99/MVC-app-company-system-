using app1.Models;

namespace app1.Reposatory
{
	public interface IDepartmentRepo
	{

		public void add(Department db);


		public void update(Department db);


		public void delete(int id);


		public List<Department> Getall();


		public Department GetById(int id);



		public void SaveChanges();
		
	}
}
