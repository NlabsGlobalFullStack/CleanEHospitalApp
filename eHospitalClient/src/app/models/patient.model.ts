import { AppointmentModel } from "./appointment.model";
import { RoomActionModel } from "./room-action.model";
import { UserModel } from "./user.model";
import { VehicleActionModel } from "./vehicle-action.model";
import { VehicleMissionModel } from "./vehicle-mission.model";

export class PatientModel{
    id: string = "";

    userId: string = "";
    user: UserModel = new UserModel();
    fullName: string = "";
    userImage: string = "";

    appointments: AppointmentModel[] = [];
    roomActions: RoomActionModel[] = [];
    vehicleActions: VehicleActionModel[] = [];
    vehicleMissions: VehicleMissionModel[] = [];

    createdUser: string = "";
    createdDate: string = "";

    updatedUser?: string = "";
    updatedDate?: string = "";
    isUpdated: boolean = false;

    deletedUser?: string = "";
    deletedDate?: string = "";
    isDeleted: boolean = false;
}