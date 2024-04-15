using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class DoctorSpecialtyEnum : SmartEnum<DoctorSpecialtyEnum>
{
    /// <summary>
    /// Op Dr
    /// </summary>
    public static readonly DoctorSpecialtyEnum Surgeon = new("Surgeon", 1);

    /// <summary>
    /// Uzman Dr
    /// </summary>
    public static readonly DoctorSpecialtyEnum Specialist = new("Specialist", 2);

    /// <summary>
    /// Yardımcı Doçent Dr
    /// </summary>
    public static readonly DoctorSpecialtyEnum AssistantProfessor = new("AssistantProfessor", 3);

    /// <summary>
    /// Professor Dr
    /// </summary>
    public static readonly DoctorSpecialtyEnum Professor = new("Professor", 4);

    /// <summary>
    /// Assistan Dr
    /// </summary>
    public static readonly DoctorSpecialtyEnum Assistant = new("Assistant", 5);
    public DoctorSpecialtyEnum(string name, int value) : base(name, value)
    {
    }
}
