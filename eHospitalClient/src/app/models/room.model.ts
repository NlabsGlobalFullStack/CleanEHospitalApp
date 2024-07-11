import { DepartmentModel } from "./department.model";
import { RoomTypeEnum } from "./enums/room-type-enum.model";

export class RoomModel{
    id: string = "";
    createdUser: string = "";
    createdDate: string = "";

    updatedUser?: string = "";
    updatedDate?: string = "";
    isUpdated: boolean = false;

    deletedUser?: string = "";
    deletedDate?: string = "";
    isDeleted: boolean = false;

    number: string = "";

    departmentId: string = "";
    department?: DepartmentModel = new DepartmentModel();
    
    roomType: RoomTypeEnum = new RoomTypeEnum();
    roomTypeValue: number = 0;

    capacity: number = 1;
    
    isOccupied: boolean = false;
    
    isOutOfService: boolean = false;
}

