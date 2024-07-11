import { AppointmentModel } from "./appointment.model";
import { DepartmentModel } from "./department.model";
import { RoomActionModel } from "./room-action.model";
import { UserModel } from "./user.model";
import { VehicleActionModel } from "./vehicle-action.model";
import { VehicleMissionModel } from "./vehicle-mission.model";

export class NurseModel{
    id: string = "";

    userId: string = "";
    user: UserModel | any;
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

    shift: ShiftModel = new ShiftModel();
    shiftValue: number = 0;

    departmentId: string = "";
    department: DepartmentModel = new DepartmentModel();
    departmentName: string = "";
}

export class ShiftModel{
    name: string = "";
    value: number = 0;
}