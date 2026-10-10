using System;

namespace Bai5_4
{
    /// <summary>
    /// Lớp đối tượng Nhân viên.
    /// </summary>
    public class Employee
    {
        public string EmployeeId { get; set; }
        public string FullName { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }

        // Mã của nhóm (Node trên TreeView) mà nhân viên thuộc về
        public string GroupKey { get; set; }

        public Employee(string employeeId, string fullName, string position, DateTime hireDate, string groupKey)
        {
            EmployeeId = employeeId;
            FullName = fullName;
            Position = position;
            HireDate = hireDate;
            GroupKey = groupKey;
        }
    }
}
