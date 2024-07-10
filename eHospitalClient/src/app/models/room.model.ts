import { DepartmentModel } from "./department.model";
import { EntityModel } from "./abstractions/entity.model";

export class RoomModel extends EntityModel{
    number: string = "";

    departmentId: string = "";
    department?: DepartmentModel = new DepartmentModel();
    
    roomType: RoomTypeModel = new RoomTypeModel();
    roomTypeValue: number = 0;

    capacity: number = 1;
    
    isOccupied: boolean = false;
    
    isOutOfService: boolean = false;
}

export class RoomTypeModel{
    name: string = "";
    value: number = 0;
}