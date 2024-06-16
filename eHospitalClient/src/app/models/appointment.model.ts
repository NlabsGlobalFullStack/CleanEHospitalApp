export class AppointmentModel{
    id: string = "";
    doctorId: string = "";
    patientId: string ="";
    startDate: Date = new Date();
    endDate: Date = new Date();
    isCompleted: boolean = false;
}