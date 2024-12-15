using app1.Models;

namespace app1.Reposatory
{
	public interface IEmployeRepo
	{
		public string id { get; set; }
		public void add(Employee employee);

		public void update(Employee employee);

		public void delete(int id);

		public List<Employee> Getall();

        public Employee GetById(int id);
        public Employee GetByName(string name);

		public List<Employee> getbyDeptId(int deptid);

        public void SaveChanges();
	}
}
