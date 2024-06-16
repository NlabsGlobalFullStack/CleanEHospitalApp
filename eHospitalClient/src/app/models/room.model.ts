import { DepartmentModel } from "./department.model";

export class RoomModel{
    id: string = "";
    number: string = "";
    department: DepartmentModel = new DepartmentModel();
    capacity: number = 1;
    isOccupied: boolean = true;
    isOutOfService: boolean = true;
    isDeleted: boolean = false;
    roomType: string = "";
}