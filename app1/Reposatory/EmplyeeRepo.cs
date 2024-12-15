using app1.Models;

namespace app1.Reposatory
{
	public class EmplyeeRepo:IEmployeRepo
	{
		ITIContext context;
		
		public string id { get; set; }

		public EmplyeeRepo(ITIContext _con)
        {
			context = _con;
			id=Guid.NewGuid().ToString();
        }
        public void add(Employee employee)
		{
			context.Add(employee);
			

		}
		public void update(Employee employee)
		{
			context.Update(employee);
		}
		public void delete(int id) 
		{ 
		Employee e=GetById(id);
		context.Remove(e);
		
		}
		public List<Employee> Getall()
		{
			return context.Employees.ToList();

		}
		public Employee GetById(int id) 
		{
			
			return context.Employees.FirstOrDefault(x => x.ID == id);
			
		}
       
        public void SaveChanges()
		{
			context.SaveChanges();
		}

        public Employee GetByName(string name)
        {
            return context.Employees.FirstOrDefault(x => x.Name == name);
        }

        public List<Employee> getbyDeptId(int deptid)
        {
			return context.Employees.Where(x=>x.DeptId==deptid).ToList();

        }
    }

}
