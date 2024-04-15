using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class DepartmentEnum : SmartEnum<DepartmentEnum>
{
    /// <summary>
    /// AcilServis
    /// </summary>
    public static readonly DepartmentEnum Emergency = new("Emergency", 1);

    /// <summary>
    /// Radyoloji
    /// </summary>
    public static readonly DepartmentEnum Radiology = new("Radiology", 2);

    /// <summary>
    /// Kardiyoloji
    /// </summary>
    public static readonly DepartmentEnum Cardiology = new("Cardiology", 3);

    /// <summary>
    /// Dermatoloji
    /// </summary>
    public static readonly DepartmentEnum Dermatology = new("Dermatology", 4);

    /// <summary>
    /// Endokrinoloji
    /// </summary>
    public static readonly DepartmentEnum Endocrinology = new("Endocrinology", 5);

    /// <summary>
    /// GastroEnteroloji
    /// </summary>
    public static readonly DepartmentEnum Gastroenterology = new("Gastroenterology", 6);

    /// <summary>
    /// GenelCerrahi
    /// </summary>
    public static readonly DepartmentEnum GeneralSurgery = new ("General Surgery", 7);

    /// <summary>
    /// Jinekoloji Ve Obstetrik
    /// </summary>
    public static readonly DepartmentEnum GynecologyAndObstetrics = new("Gynecology and Obstetrics", 8);

    /// <summary>
    /// Hematoloji
    /// </summary>
    public static readonly DepartmentEnum Hematology = new("Hematology", 9);

    /// <summary>
    /// Enfeksiyon Ve Hastalıkları
    /// </summary>
    public static readonly DepartmentEnum InfectiousDiseases = new ("Infectious Diseases", 10);

    /// <summary>
    /// Nefroloji
    /// </summary>
    public static readonly DepartmentEnum Nephrology = new("Nephrology", 11);

    /// <summary>
    /// Nöroloji
    /// </summary>
    public static readonly DepartmentEnum Neurology = new("Neurology", 12);

    /// <summary>
    /// Ortopedi
    /// </summary>
    public static readonly DepartmentEnum Orthopedics = new("Orthopedics", 13);

    /// <summary>
    /// Pediatri
    /// </summary>
    public static readonly DepartmentEnum Pediatrics = new("Pediatrics", 14);

    /// <summary>
    /// Psikiyatri
    /// </summary>
    public static readonly DepartmentEnum Psychiatry = new("Psychiatry", 15);

    /// <summary>
    /// Pulmonoloji
    /// </summary>
    public static readonly DepartmentEnum Pulmonology = new("Pulmonology", 16);
    public DepartmentEnum(string name, int value) : base(name, value)
    {
    }
}
