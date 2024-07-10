import { DoctorModel } from "./doctor.model";
import { PatientModel } from "./patient.model";

export class AppointmentModel{
    id: string = "";

    doctorId: string = "";
    doctor: DoctorModel = new DoctorModel();

    patientId: string ="";
    patient: PatientModel = new PatientModel();

    startDate: Date = new Date();
    endDate: Date = new Date();
    isCompleted: boolean = false;

    deletedDate?: string = "";
    isDeleted: boolean = false;
}