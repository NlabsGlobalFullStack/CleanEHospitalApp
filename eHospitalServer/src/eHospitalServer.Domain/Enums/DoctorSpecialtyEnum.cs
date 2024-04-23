using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class DoctorSpecialtyEnum : SmartEnum<DoctorSpecialtyEnum>
{
    public static readonly DoctorSpecialtyEnum Surgeon = new("Surgeon", 1);
    public static readonly DoctorSpecialtyEnum Specialist = new("Specialist", 2);
    public static readonly DoctorSpecialtyEnum AssistantProfessor = new("Assistant Professor", 3);
    public static readonly DoctorSpecialtyEnum Professor = new("Professor", 4);
    public static readonly DoctorSpecialtyEnum Assistant = new("Assistant", 5);
    public DoctorSpecialtyEnum(string name, int value) : base(name, value)
    {
    }
}
