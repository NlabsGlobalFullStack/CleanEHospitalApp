import { DoctorModel } from "./doctor.model";
import { EmployeeModel } from "./employee.model";
import { NurseModel } from "./nurse.model";
import { PatientModel } from "./patient.model";
import { VehicleModel } from "./vehicle.model";

export class VehicleMissionModel{
    id: string = "";
    
    vehicleId: string = "";
    vehicle: VehicleModel | any;

    employeeId: string = "";
    employee: EmployeeModel | any;
    
    doctorId: string = "";
    doctor: DoctorModel | any;

    nurseId: string = "";
    nurse: NurseModel | any;

    patientId: string = "";
    patient: PatientModel | any;

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