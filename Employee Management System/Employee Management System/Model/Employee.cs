namespace Employee_Management_System.Model
{
    public class Employee
    {
        public int Id { set; get; }
        public string FirstName { set; get; } = string.Empty;
        public string LastName {set; get; } = string.Empty;
        public string Email { set; get; } = string.Empty;
        public string PhoneNumber {  set; get; } = string.Empty;
        public string Department {  set; get; } = string.Empty;
        public string Designation {  set; get; } = string.Empty;
        public Decimal Salary {  set; get; }
        public DateOnly DateOfJoining { set; get; }
        public bool IsActive {  set; get; }=true;


    }
}
