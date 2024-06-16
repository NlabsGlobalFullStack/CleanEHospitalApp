import { AppointmentModel } from "./appointment.model";
import { RoomAction } from "./room-action.model";
import { VehicleMissionModel } from "./vehicle-mission.model";

export class PatientModel{
    id: string = "";
    appointments: AppointmentModel[] = [];
    roomActions: RoomAction[] = [];
    vehicleMissions: VehicleMissionModel[] = [];
}