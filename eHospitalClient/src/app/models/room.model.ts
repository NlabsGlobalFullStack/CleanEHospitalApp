import { DepartmentModel } from "./department.model";

export class RoomModel{
    id: string = "";

    number: string = "";

    departmentId: string = "";
    department?: DepartmentModel = new DepartmentModel();
    
    roomTypeValue: number = 0;
    roomType?: RoomTypeEnum = new RoomTypeEnum();

    capacity: number = 1;
    
    isOccupied: boolean = false;
    
    isOutOfService: boolean = false;

    createdUser?: string = "";
    createdDate?: string = "";

    updatedUser?: string = "";
    updatedDate?: string = "";
    isUpdated: boolean = false;
    
    deletedUser?: string = "";
    deletedDate?: string = "";
    isDeleted: boolean = false;
}

export class RoomTypeEnum{
    name: string = "";
    value: number = 0;
}