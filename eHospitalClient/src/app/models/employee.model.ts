import { PersonalModel } from "./abstractions/personal.model";
import { DepartmentModel } from "./department.model";

export class EmployeeModel extends PersonalModel{
    // id: string = "";

    // userId: string = "";
    // user: UserModel | any;
    // fullName: string = "";
    // userImage: string = "";

    // appointments: AppointmentModel[] = [];
    // roomActions: RoomActionModel[] = [];
    // vehicleActions: VehicleActionModel[] = [];
    // vehicleMissions: VehicleMissionModel[] = [];

    // createdUser: string = "";
    // createdDate: string = "";

    // updatedUser?: string = "";
    // updatedDate?: string = "";
    // isUpdated: boolean = false;

    // deletedUser?: string = "";
    // deletedDate?: string = "";
    // isDeleted: boolean = false;

    departmentId: string = "";
    department: DepartmentModel = new DepartmentModel();
    departmentName: string = "";

    position: PositionModel = new PositionModel();
    positionValue: number = 0;
}

export class PositionModel{
    name: string = "";
    value: number = 0;
}