import { DoctorModel } from "./doctor.model";
import { EmployeeModel } from "./employee.model";
import { NurseModel } from "./nurse.model";
import { PatientModel } from "./patient.model";
import { VehicleModel } from "./vehicle.model";

export class VehicleMissionModel{
    id: string = "";
    
    vehicleId: string = "";
    vehicle: VehicleModel = new VehicleModel();

    employeeId: string = "";
    employee: EmployeeModel = new EmployeeModel();
    
    doctorId: string = "";
    doctor: DoctorModel = new DoctorModel();

    nurseId: string = "";
    nurse: NurseModel = new NurseModel();

    patientId: string = "";
    patient: PatientModel = new PatientModel();

    patientRelative: string = "";
    
    traveledRouteInformation: string = "";
    destination: string = "";
    comments: string = "";
    missionDate: string = "";

    createdUser: string = "";
    createdDate: string = "";

    updatedUser: string = "";
    updatedDate: string = "";
    isUpdated: boolean = false;
}