namespace app1.Models
{
	public class Student_BL
	{
		public List<STUDENT> sTUDENTs;

        public Student_BL()
        {
			sTUDENTs = new List<STUDENT>();
			sTUDENTs.Add(new STUDENT() { Id = 1, Name = "ahmed", IMGurl = "1.ico" });
			sTUDENTs.Add(new STUDENT() { Id = 2, Name = "mohamed", IMGurl = "2.ico" });
			sTUDENTs.Add(new STUDENT() { Id = 3, Name = "ali", IMGurl = "3.png" });
		}

		public List<STUDENT> Getall()
		{

			return sTUDENTs;
		}
		public STUDENT getbyid(int id)
		{
			return sTUDENTs.FirstOrDefault(x => x.Id==id);
		}
	}
}
