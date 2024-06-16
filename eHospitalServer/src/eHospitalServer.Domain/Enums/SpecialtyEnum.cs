using Ardalis.SmartEnum;

namespace eHospitalServer.Domain.Enums;
public sealed class SpecialtyEnum : SmartEnum<SpecialtyEnum>
{
    public static readonly SpecialtyEnum Surgeon = new("Surgeon", 1);
    public static readonly SpecialtyEnum Specialist = new("Specialist", 2);
    public static readonly SpecialtyEnum AssistantProfessor = new("Assistant Professor", 3);
    public static readonly SpecialtyEnum Professor = new("Professor", 4);
    public static readonly SpecialtyEnum Assistant = new("Assistant", 5);
    public SpecialtyEnum(string name, int value) : base(name, value)
    {
    }
}
