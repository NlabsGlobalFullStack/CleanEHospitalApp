import { DoctorModel } from "./doctor.model";
import { EmployeeModel } from "./employee.model";
import { NurseModel } from "./nurse.model";
import { PatientModel } from "./patient.model";

export class UserModel{
    id: string = "";
    image: string = "";
    identityNumber: string = "";
    firstName: string = "";
    lastName: string = "";
    fullName: string = "";
    gender: boolean = true;
    isMarried: boolean = false;
    dateOfBirth: Date | null = null;
    bloodType: string = "";
    city: string = "";
    town: string = "";
    fullAddress: string = "";
    email: string = "";
    userName: string = "";
    phoneNumber: string = "";
    userType: number = 0;

    role: string = "";

    doctorId?: string = "";
    doctor?: DoctorModel | any;

    nurseId?: string = "";
    nurse?: NurseModel | any;

    employeeId?: string = "";
    employee?: EmployeeModel | any;
    
    patientId?: string = "";
    patient?: PatientModel | any;

    isActive: boolean = true;
    isDeleted: boolean = false;    
}