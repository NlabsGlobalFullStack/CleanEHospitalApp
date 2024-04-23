using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class DepartmentEnum : SmartEnum<DepartmentEnum>
{
    public static readonly DepartmentEnum Emergency = new("Emergency", 1);
    public static readonly DepartmentEnum Radiology = new("Radiology", 2);
    public static readonly DepartmentEnum Cardiology = new("Cardiology", 3);
    public static readonly DepartmentEnum Dermatology = new("Dermatology", 4);
    public static readonly DepartmentEnum Endocrinology = new("Endocrinology", 5);
    public static readonly DepartmentEnum Gastroenterology = new("Gastroenterology", 6);
    public static readonly DepartmentEnum GeneralSurgery = new ("General Surgery", 7);
    public static readonly DepartmentEnum GynecologyAndObstetrics = new("Gynecology and Obstetrics", 8);
    public static readonly DepartmentEnum Hematology = new("Hematology", 9);
    public static readonly DepartmentEnum InfectiousDiseases = new ("Infectious Diseases", 10);
    public static readonly DepartmentEnum Nephrology = new("Nephrology", 11);
    public static readonly DepartmentEnum Neurology = new("Neurology", 12);
    public static readonly DepartmentEnum Orthopedics = new("Orthopedics", 13);
    public static readonly DepartmentEnum Pediatrics = new("Pediatrics", 14);
    public static readonly DepartmentEnum Psychiatry = new("Psychiatry", 15);
    public static readonly DepartmentEnum Pulmonology = new("Pulmonology", 16);
    public DepartmentEnum(string name, int value) : base(name, value)
    {
    }
}
